<template>
    <div :style="{
        width,
        height,
        background,
        borderRadius: radius
    }" class="scroll-wrapper" ref="refWrapper" @wheel="onWheel">
        <div class="scroll-area" :class="{
            transAll: !dragging
        }" ref="refArea" :style="{
            marginLeft: `${context.x}px`,
            marginTop: `${context.y}px`,
        }" :key="randomKey">
            <slot></slot>
        </div>

        <vertical-scrollbar v-if="scrollY" ref="refSY" :area="context.areaHeight" :wrapper="context.wrapperHeight"
            v-model:scrolling="context.y" v-model:dragging="dragging" />
        <horizontal-scrollbar v-if="scrollX" ref="refSX" :area="context.areaWidth" :wrapper="context.wrapperWidth"
            v-model:scrolling="context.x" v-model:dragging="dragging" />
    </div>
</template>

<script lang="ts" setup>
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import VerticalScrollbar from './vertical-scrollbar.vue';
import HorizontalScrollbar from './horizontal-scrollbar.vue';

const props = defineProps({
    width: {
        type: String,
        default: 'auto',
    },
    height: {
        type: String,
        default: 'auto',
    },
    speed: {
        type: Number,
        default: 50
    },
    background: {
        type: String,
        default: null
    },
    radius: {
        type: String,
        default: null
    },
    scrollX: {
        type: Boolean,
        default: false
    },
    scrollY: {
        type: Boolean,
        default: false
    }
})

const randomKey = ref(0);

const refSX = ref();
const refSY = ref();

const refWrapper = ref();
const refArea = ref();

const dragging = ref(false)

const context = reactive({
    x: 0,
    y: 0,
    areaHeight: 0,
    areaWidth: 0,
    wrapperHeight: 0,
    wrapperWidth: 0
})

const onWheel = (e: WheelEvent) => {
    e.preventDefault();

    const { speed } = props

    const shifted = e.shiftKey

    if (shifted) return;

    const deltaY = (e.deltaY > 0 ? -speed : speed)
    const deltaX = (e.deltaX > 0 ? -speed : speed)

    refSY.value?.scrollOffset(deltaY)
    refSX.value?.scrollOffset(deltaX)
}

const measureSize = () => {
    if (refArea.value && refWrapper.value) {
        context.areaWidth = refArea.value.clientWidth;
        context.areaHeight = refArea.value.clientHeight;
        context.wrapperWidth = refWrapper.value.clientWidth;
        context.wrapperHeight = refWrapper.value.clientHeight;
    }
}

onMounted(() => {
    new ResizeObserver(measureSize).observe(refArea.value);
    new ResizeObserver(measureSize).observe(refWrapper.value);
    measureSize();
})

watch(() => dragging, (prev, next) => {
    randomKey.value = Math.floor(Math.random() * 10000)
})
</script>

<style lang="less" scoped>
.scroll-wrapper {
    position: relative;
    overflow: hidden;
}

.scroll-area.transAll {
    transition: margin-top 0.25s;
}
</style>