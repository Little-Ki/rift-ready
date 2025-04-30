<template>
    <div class="view-content">
        <title-view value="辅助功能" :buttons="['reload']" @button="fetchConfig">
        </title-view>
        <div class="feature-line">
            <div class="feature-title">
                自动接受对局
            </div>

            <switcher :value="config.data.feature.autoAcceptMM"
                @switch="(value: boolean) => switchKey(value, 'autoAcceptMM')" />
        </div>
    </div>
</template>
<script lang="ts" setup>
import Api from '@/api';
import Switcher from '@/components/Switcher.vue';
import { useConfigStore } from '@/stores';
import { onMounted } from 'vue';

import TitleView from '@/components/TitleView.vue';

const config = useConfigStore()

const switchKey = (value: boolean, name: string) => {
    const temp = { ...config.data }
    const key = name as keyof typeof temp.feature;
    if (Object.keys(temp.feature).includes(name)) {
        temp.feature[key] = value

        Api.config.set(temp).then(({ data }) => {
            config.patch(data.data)
        })
    }
}


const fetchConfig = () =>
    Api.config.get().then(({ data }) => {
        config.patch(data.data)
    })

onMounted(fetchConfig)

</script>

<style lang="less" scoped>
.header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 0.5rem;

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

.feature-line {
    display: flex;
}

.feature-title {
    font-size: 1.1rem;
    width: 8rem;
}
</style>