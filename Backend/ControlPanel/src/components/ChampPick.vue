<template>
    <popup position="center" v-model:visible="visible" width="90%" height="90%">
        <div class="content">
            <div class="search-area">
                <input title="keyword" v-model="searchForm.keyword" class="hero-search" placeholder="输入关键词"
                    @input="onKeywordChage" />
                <div class="close icon-wrong" @click="() => visible = false"></div>
            </div>

            <div class="list-area">
                <vue-scrollbar width="100%" height="calc(100% - 0.5rem)" scroll-y>
                    <div class="hero-list">
                        <transition-group name="elem" @before-leave="beforeLeave">
                            <div class="hero-empty" v-if="heroList.length == 0" key="empty">什么也没有</div>
                            <div class="hero-item" v-else v-for="(it, index) of heroList" :key="it.heroId">
                                <div class="hero-item-padding">
                                    <div class="hero-item-content" @click="() => select(it)">
                                        <img class="hero-icon"
                                            :src="`https://game.gtimg.cn/images/lol/act/img/champion/${it.alias}.png`" />
                                        <div class="hero-name">
                                            {{ it.name }}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </transition-group>
                    </div>
                </vue-scrollbar>
            </div>
        </div>
    </popup>
</template>

<script lang="ts" setup>
import Api from '@/api'
import type { Hero } from '@/api/heros'
import { reactive, ref } from 'vue'

import VueScrollbar from "@/components/scrollbar/vue-scrollbar.vue"
import Popup from './Popup.vue'

const visible = ref(false);

const searchForm = reactive({
    keyword: '',
    id: '',
})

const heroList = ref([] as Hero[])

const lateUpdate = ref(0)

const emits = defineEmits(['pick'])

const fetchHeros = () =>
    Api.heros.list(searchForm.keyword).then(({ data }) => {
        heroList.value = data.data
    })

const onKeywordChage = () => {
    if (lateUpdate.value != null) {
        clearTimeout(lateUpdate.value)
    }

    lateUpdate.value = setTimeout(fetchHeros, 100)
}

const beforeLeave = (e: Element) => {
    const el = e as HTMLElement
    const { marginLeft, marginTop, width, height } = window.getComputedStyle(el)

    el.style.left = `${el.offsetLeft - parseFloat(marginLeft)}px`
    el.style.top = `${el.offsetTop - parseFloat(marginTop)}px`
    el.style.width = width
    el.style.height = height
}

const select = (hero: Hero) => {
    emits('pick', hero)
    visible.value = false;
}

const show = () => {
    searchForm.keyword = ''
    searchForm.id = ''
    fetchHeros().then(() => visible.value = true)
}

defineExpose({
    show
})

</script>

<style lang="less" scoped>
.content {
    display: flex;
    flex-direction: column;
    height: 100%;
    width: 100%;
    background: #f0f0f0;
    border-radius: 0.5rem;
    overflow: hidden;
}

.search-area {
    display: flex;
    height: 48px;
    padding-bottom: 0.1rem;

    .hero-search {
        width: calc(100% - 48px);
        height: 100%;
        outline: none;
        border: none;
        padding: 0.5rem 1rem;
        font-size: 0.9rem;
    }

    .close {
        width: 48px;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 1rem;
        background: #c0c0c0;
        transition: all 0.25s ease;
        color: white;
    }


    .close:active,
    .close:hover {
        background: #b0b0b0;
    }
}

.list-area {
    height: calc(100% - 48px);
    padding-top: 0.4rem;

    .scroll-area {
        overflow-y: scroll;
        border-radius: 0.5rem;
        background: #e0e0e0;
        height: 100%;
    }
}

.hero-list {
    display: flex;
    flex-wrap: wrap;
    position: relative;

    .hero-item {
        width: 12.5%;

        .hero-item-padding {
            width: 100%;
            position: relative;
            padding-top: 100%;

            .hero-item-content {
                position: absolute;
                left: 0.5rem;
                top: 0.5rem;
                right: 0.5rem;
                bottom: 0.5rem;
                background: #a0a0a0;
                border-radius: 0.25rem;
                display: flex;
                align-items: center;
                justify-content: center;
                font-size: 0.75rem;
                text-wrap: nowrap;
                overflow: hidden;
            }

            .hero-icon {
                position: absolute;
                left: 1px;
                top: 1px;
                right: 1px;
                bottom: 1px;
                border-radius: 0.25rem;
                width: 100%;
            }

            .hero-name {
                position: absolute;
                left: 0;
                right: 0;
                bottom: 0;
                background: #FFFFFF40;
                color: white;
                text-align: center;
            }
        }
    }

    .hero-empty {
        width: 100%;
        text-align: center;
        margin-top: 1rem;
        font-size: 1rem;
    }
}

.elem-move,
.elem-enter-active,
.elem-leave-active {
    transition: all 0.5s ease;
}

.elem-leave-to {
    opacity: 0;
    transform: scale(0.9);
}

.elem-enter-from {
    opacity: 0;
    transform: scale(1.1);
}

.elem-leave-active {
    position: absolute;
}
</style>