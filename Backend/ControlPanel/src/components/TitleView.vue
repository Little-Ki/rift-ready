<template>
    <div class="title-view">
        <div class="title">
            {{ value }}
        </div>
        <div class="control">
            <slot></slot>
            <div v-for="(it, index) of buttons" :class="`button icon-${it}`" :key="index"
                @click="() => emits('button', index)">

            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>

defineProps({
    value: {
        type: String,
        default: null
    },
    buttons: {
        type: Array<string>,
        default: []
    }
})

const emits = defineEmits(['button'])
</script>

<style lang="less" scoped>
.title-view {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 0.5rem;
    min-height: 2rem;
    height: 2rem;

    .title {
        font-size: 1.1rem;
        font-weight: bold;
    }

    .control {
        display: flex;

        .button {
            padding: 0.25rem;
            font-size: 1.2rem;
            border-radius: 0.25rem;
            line-height: 1;
            transition: all 0.25s ease;
            margin-left: 0.5rem;
        }

        .button:active,
        .button:hover {
            background: #d0d0d0;
        }
    }
}
</style>