<template>
    <div class="view-content">
        <title-view value="自动禁用" :buttons="['reload', 'plus']" @button="onButton">
            <switcher :value="config.data.autoBan.enable" @switch="switchEnable" />
        </title-view>
        <vue-scrollbar width="100%" height="calc(100% - 48px)" background="white" radius="0.25rem" scroll-y>
            <transition-group name="list">
                <div class="list-empty" v-if="config.data.autoBan.championIds.length == 0" key="none">什么也没有</div>
                <li class="list-item" v-else v-for="(it, index) of config.data.autoBan.championIds" :key="it">
                    <div class="list-item-content">
                        <div class="item-title">
                            {{ findHero(it)?.name }}
                        </div>
                        <div class="item-control">
                            <div class="control-button icon-arrow-up" @click="() => raiseBan(it)">
                            </div>
                            <div class="control-button  icon-arrow-down" @click="() => declineBan(it)">
                            </div>
                            <div class="control-button icon-delete" @click="() => removeBan(it)">
                            </div>
                        </div>
                    </div>
                </li>
            </transition-group>

        </vue-scrollbar>
        <champ-pick @pick="createBan" ref="refPicker" />
    </div>
</template>

<script lang="ts" setup>
import Api from '@/api';
import type { Hero } from '@/api/heros';
import { useConfigStore } from '@/stores';
import { computed, onMounted, ref } from 'vue';

import VueScrollbar from '@/components/scrollbar/vue-scrollbar.vue';
import ChampPick from '@/components/ChampPick.vue';
import Switcher from '@/components/Switcher.vue';
import TitleView from '@/components/TitleView.vue';

const config = useConfigStore()

const heroList = ref([] as Hero[])

const isEnable = computed(() => config.data.autoBan.enable);

const refPicker = ref();

const onButton = (index: number) => {
    if (index === 0) {
        fetchData()
    }
    if (index === 1) {
        refPicker.value.show()
    }
}

const fetchHeros = () =>
    Api.heros.list().then(({ data }) => {
        heroList.value = data.data
    })

const fetchConfig = () =>
    Api.config.get().then(({ data }) => {
        config.patch(data.data)
    })

const createBan = (hero: Hero) => {
    const tempList = [...config.data.autoBan.championIds]
    tempList.push(Number.parseInt(hero.heroId));

    Api.config.set({
        ...config.data,
        autoBan: {
            enable: isEnable.value,
            championIds: tempList
        }
    }).then(({ data }) => {
        config.patch(data.data)
    })
}

const findHero = (id: string | number) =>
    heroList.value.find((x) => x.heroId == id)

const fetchData = () => fetchHeros().then(fetchConfig).catch(() => { })

const removeBan = (id: number) => {
    const temp = [...config.data.autoBan.championIds]
    const index = temp.findIndex((it) => it == id)

    if (index !== -1) {
        temp.splice(index, 1)
        Api.config.set({
            ...config.data,
            autoBan: {
                enable: isEnable.value,
                championIds: temp
            }
        }).then(({ data }) => {
            config.patch(data.data)
        })
    }
}

const raiseBan = (id: number) => {
    const temp = [...config.data.autoBan.championIds]
    const index = temp.findIndex((it) => it == id)

    if (index === -1 || index === 0) return

    [temp[index], temp[index - 1]] = [temp[index - 1], temp[index]]

    Api.config.set({
        ...config.data,
        autoBan: {
            enable: isEnable.value,
            championIds: temp
        }
    }).then(({ data }) => {
        config.patch(data.data)
    })
}

const declineBan = (id: number) => {
    const temp = [...config.data.autoBan.championIds]
    const index = temp.findIndex((it) => it == id)

    if (index === -1 || index === temp.length - 1) return

    [temp[index], temp[index + 1]] = [temp[index + 1], temp[index]]

    Api.config.set({
        ...config.data,
        autoBan: {
            enable: isEnable.value,
            championIds: temp
        }
    }).then(({ data }) => {
        config.patch(data.data)
    })
}

const switchEnable = (value: boolean) => {
    Api.config.set({
        ...config.data,
        autoBan: {
            enable: value,
            championIds: config.data.autoBan.championIds
        }
    }).then(({ data }) => {
        config.patch(data.data)
    })
}

onMounted(fetchData)
</script>

<style lang="less" scoped>
.header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 0.5rem;
    height: 2rem;

    .title {
        font-size: 1.1rem;
        font-weight: bold;
    }

    .control {
        display: flex;

        .add-button {
            padding: 0.5rem;
            font-size: 1.2rem;
            border-radius: 0.25rem;
            line-height: 1;
            transition: all 0.25s ease;
            margin-left: 0.5rem;
        }

        .add-button:active,
        .add-button:hover {
            background: #d0d0d0;
        }
    }
}

.list-item {
    display: flex;
    flex-direction: column;
    padding: 0.4rem 1rem 0.25rem 0.5rem;
}

.list-empty {
    width: 100%;
    text-align: center;
    margin-top: 1rem;
    font-size: 1rem;
}

.list-item-content {
    display: flex;
    padding: 0.3rem 0.75rem;
    background: #e0e0e0;
    border-radius: 0.25rem;
    justify-content: space-between;
    align-items: center;

    .item-title {
        font-size: 1rem;
        margin-left: 1rem;
    }

    .item-control {
        display: flex;

        .control-button {
            width: 2rem;
            height: 2rem;
            display: flex;
            align-items: center;
            justify-content: center;
            transition: all 0.25s ease;
            border-radius: 50%;
            color: #404040
        }

        .control-button:hover {
            color: #256FCF;
        }

        .control-button:not(:first-child) {
            margin-left: 0.1rem;
        }
    }
}

.list-move,
.list-enter-active,
.list-leave-active {
    transition: all 0.5s ease;
}

.list-enter-from {
    opacity: 0;
    transform: translateX(-30px);
}

.list-leave-to {
    opacity: 0;
    transform: translateX(30px);
}

.list-leave-active {
    position: absolute;
    width: 100%;
}
</style>