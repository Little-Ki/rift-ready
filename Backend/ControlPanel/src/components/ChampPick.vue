<template>
    <popup position="center" v-model:visible="visible" width="90%" height="90%">
        <div class="pick-content">
            <div class="search-area">
                <input title="keyword" v-model="searchForm.keyword" class="hero-search" placeholder="输入关键词"
                    @input="onKeywordChage" />
                <div class="close icon-wrong" @click="() => visible = false"></div>
            </div>

            <vue-scrollbar width="100%" height="calc(100% - 56px)" scroll-y>
                <div class="hero-list">
                    <transition-group name="elem">
                        <div class="empty" v-if="heroList.length == 0" key="empty">什么也没有</div>
                        <div class="dummy" v-if="heroList.length != 0">
                            <div :style="{
                                paddingTop: `${100 * Math.ceil(heroList.length / 8)}%`
                            }"></div>
                        </div>
                        <div class="item" v-if="heroList.length != 0" v-for="(it, index) of heroList" :key="it.heroId">
                            <div class="padding" :style="{
                                transform: `translate(${index % 8 * 100}%, ${(Math.floor(index / 8) + 1) * 100}%)`
                            }">
                                <div class="content" @click="() => select(it)">
                                    <img class="icon" :src="getImage(it.alias, 'png')" />
                                    <div class="name">
                                        {{ it.name }}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </transition-group>
                </div>
            </vue-scrollbar>
        </div>
    </popup>
</template>

<script lang="ts" setup>
import Api from '@/api'
import type { Hero } from '@/api/heros'
import { reactive, ref } from 'vue'
import Images from "@/assets/images"

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

const getImage = (name: string, format: string) => {
    const key = name as keyof typeof Images.mapping;

    if (Images.mapping[key]) {
        for (var i of Images.mapping[key]) {
            var file = Images.files[i];

            if (file.format === format) {
                return `data:image/${file.format};base64,${file.base64}`;
            }
        }
    }

    return ""
}

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
.pick-content {
    display: flex;
    flex-direction: column;
    height: 100%;
    width: 100%;
    background: #f0f0f0;
    border-radius: 0.5rem;
    overflow: hidden;
    justify-content: space-between;
}

.search-area {
    display: flex;
    height: 48px;

    .hero-search {
        width: calc(100% - 48px);
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

.hero-list {
    display: flex;
    flex-wrap: wrap;
    position: relative;

    .dummy {
        width: 12.5%;
    }

    .item {
        width: 12.5%;
        position: absolute;
        transform: translateY(-100%);

        .padding {
            width: 100%;
            padding-top: 100%;
            transition: all 0.25s ease;
        }

        .content {
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

        .icon {
            position: absolute;
            left: 1px;
            top: 1px;
            right: 1px;
            bottom: 1px;
            border-radius: 0.25rem;
            width: 100%;
        }

        .name {
            position: absolute;
            left: 0;
            right: 0;
            bottom: 0;
            background: #FFFFFF40;
            color: white;
            text-align: center;
        }
    }

    .empty {
        width: 100%;
        text-align: center;
        margin-top: 1rem;
        font-size: 1rem;
        position: absolute;
    }
}

.elem-move,
.elem-enter-active,
.elem-leave-active {
    transition: all 0.25s ease;

    .content {
        transition: all 0.25s ease;
    }
}

.elem-leave-to {
    opacity: 0;

    .content {
        transform: scale(0.9);
        transition: all 0.25s ease;
    }
}

.elem-enter-from {
    opacity: 0;

    .content {
        transition: all 0.25s ease;
        transform: scale(1.1);
    }
}
</style>