<template>
    <div class="horizontal-bar" :style="{ width: `${context.trackSize}px` }" @click.stop="jump">
        <div class="thumb" :class="{
            transAll: !dragging,
            dragging
        }" :style="{
            width: `${context.thumbSize}px`,
            marginLeft: `${thumbIndent}px`
        }" @click.stop @mousedown="startDrag">

        </div>
    </div>
</template>

<script lang="ts" setup>
import { computed, nextTick, onMounted, onUnmounted, reactive, watch } from 'vue';

const emits = defineEmits(["scroll", "update:scrolling", "update:dragging"])

const props = defineProps({
    area: {
        type: Number,
        default: 0
    },
    wrapper: {
        type: Number,
        default: 0
    },
    scrolling: {
        type: Number,
        default: 0
    },
    dragging: {
        type: Boolean,
        default: false
    }
})

const context = reactive({
    areaSize: 0,
    wrapperSize: 0,
    scrollable: false,
    scrollSize: 0,
    trackSize: 0,
    thumbSize: 0,
    spaceSize: 0
})

const calculateSize = () => {
    context.areaSize = props.area;
    context.wrapperSize = props.wrapper;
    context.scrollable = context.wrapperSize < context.areaSize;
    context.scrollSize = Math.max(context.areaSize - context.wrapperSize, 0)
    context.trackSize = context.wrapperSize - 8;
    context.thumbSize = Math.max(context.trackSize * 0.2, context.trackSize - context.scrollSize)
    context.spaceSize = context.trackSize - context.thumbSize
}

const scrolling = computed({
    get: () => props.scrolling,
    set: (value: number) => emits("update:scrolling", value)
})

const dragging = computed({
    get: () => props.dragging,
    set: (value: boolean) => emits("update:dragging", value)
})

var startAt = 0;

const thumbIndent = computed(() => context.scrollable ? - (scrolling.value / context.scrollSize * context.spaceSize) : 0)

const scrollPercent = (percent: number) => {
    if (!isNaN(percent)) {
        percent = Math.max(0.0, Math.min(1.0, percent))
        const move = context.scrollSize * percent
        scrolling.value = -move
    }
}

const jump = (e: MouseEvent) => {
    if (context.scrollable) {
        const offset = Math.min(Math.max(0, e.layerY - context.thumbSize / 2), context.spaceSize)
        const percent = offset / context.spaceSize
        scrollPercent(percent)
    }
}

const santilize = (value: number) => {
    scrolling.value = Math.max(-context.scrollSize, Math.min(0, value))
}

const scrollOffset = (delta: number) => {
    var next = Math.max(-context.scrollSize, Math.min(0, scrolling.value + delta))
    santilize(next);
}

const registEvent = () => {
    document.addEventListener("mouseup", stopDrag)
    document.addEventListener("mousemove", onDrag)
}

const removeEvent = () => {
    document.removeEventListener("mouseup", stopDrag)
    document.removeEventListener("mousemove", onDrag)
}

const onDrag = (e: MouseEvent) => {
    e.preventDefault();
    e.stopPropagation();
    if (dragging.value) {
        const offset = e.pageX - startAt;
        const percent = offset / context.spaceSize
        const abs = context.scrollSize * percent
        santilize(scrolling.value - abs);
        startAt = e.pageX
    }
}

const stopDrag = (e: MouseEvent) => {
    e.preventDefault();
    e.stopPropagation();
    dragging.value = false;
    removeEvent()
}

const startDrag = (e: MouseEvent) => {
    if (!dragging.value) {
        dragging.value = true;
        startAt = e.pageX
        registEvent()
    }
}


onMounted(() => {
    calculateSize()
})


watch(() => [props.wrapper, props.area], (prev, next) => {
    if (prev != next) {
        nextTick(() => {
            calculateSize()
            santilize(scrolling.value)
        })
    }
}, { immediate: true })

defineExpose({ scrollOffset })

</script>

<style lang="less" scoped>
.horizontal-bar {
    position: absolute;
    bottom: 0;
    left: 0;
    height: 8px;

    .thumb {
        opacity: 0.25;
    }
}

.horizontal-bar:hover {
    .thumb {
        opacity: 1;
    }
}

.thumb {
    height: 8px;
    border-radius: 100px;
    background: #00000080;
    transition: opacity 0.25s;
}

.thumb.dragging,
.thumb:hover {
    opacity: 1;
    background: #000000B0;
}

.thumb.transAll {
    transition: all 0.25s;
}
</style>