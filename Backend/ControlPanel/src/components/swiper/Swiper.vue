<template>
    <div class="swiper-wrapper" :style="{
        width
    }" ref="refSwiper">
        <div class="swiper-padding" :style="{
            paddingTop: aspect
        }">
            <div class="swiper">
                <ul ref="refElems" :style="{
                    marginLeft: `${- currentIndex * 100}%`
                }">
                    <slot></slot>
                </ul>
            </div>
            <div class="swiper-button">
                <div class="btn icon-left-arrow-1" @click="() => changeIndex(-1)"></div>
                <div class="btn icon-right-arrow-1" @click="() => changeIndex(1)"></div>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { onMounted, ref, watch } from 'vue';

const props = defineProps({
    width: {
        type: String,
        default: 'auto'
    },
    aspect: {
        type: String,
        default: 'auto'
    }
})

const refElems = ref(null as unknown as Element)

const refSwiper = ref(null as unknown as Element)

const childCount = ref(0)

const currentIndex = ref(0)

const changeIndex = (move: number) => {
    currentIndex.value = Math.max(0, Math.min(childCount.value - 1, currentIndex.value + move))
}

const autoUpdate = () => {
    const { clientWidth } = refSwiper.value;
    const _childCount = refElems.value.children.length
    const changed = _childCount !== childCount.value
    childCount.value = refElems.value.children.length

    if (changed) {
        currentIndex.value = 0
    } else {
        currentIndex.value = Math.max(0, Math.min(childCount.value - 1, currentIndex.value))
    }

    for (var it of refElems.value.children) {
        it.setAttribute("style", `width: ${clientWidth}px;`)
    }
}

onMounted(() => {
    new MutationObserver(autoUpdate).observe(refElems.value, { subtree: false, childList: true })
    new ResizeObserver(autoUpdate).observe(refSwiper.value);
})

</script>

<style lang="less" scoped>
.swiper-wrapper {
    display: flex;
    flex-direction: column;
    position: relative;
    background: #a0a0a0;
    border-radius: 0.25rem;
    overflow: hidden;

    .swiper {
        position: absolute;
        left: 0;
        top: 0;
        right: 0;
        bottom: 0;
        overflow: hidden;

        >ul {
            position: relative;
            display: flex;
            float: left;
            list-style: none;
            padding: 0;
            height: 100%;
            transition: all 0.25s ease;
        }
    }

    .swiper-button {
        position: absolute;
        bottom: 0;
        left: 0;
        right: 0;
        background: #ffffff40;
        height: 10%;
        display: flex;
        justify-content: space-between;
        align-items: center;

        .btn {
            color: white;
            padding: 0 1rem;
            transition: all 0.25s ease;
        }

        .btn:active,
        .btn:hover {
            color: #d0d0d0;
        }
    }

}
</style>