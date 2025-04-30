<template>
    <div class="switcher-wrapper">
        <div class="switcher" @click="() => value = !value" :class="{ on: value }">
        </div>

        <div v-if="props.label" class="switcher-label">
            {{ props.label }}
        </div>
    </div>
</template>

<script lang="ts" setup>
import { computed } from 'vue';

const props = defineProps({
    value: {
        type: Boolean,
        default: false
    },
    label: {
        type: String,
        default: ""
    },
    onSwitch: {
        type: Function,
        default: null
    }
})

const emits = defineEmits(['update:value'])

const value = computed({
    get: () => props.value,
    set: (val: number) => {
        emits('update:value', val)
        if (props.onSwitch) props.onSwitch(val)
    }
})

</script>

<style lang="less" scoped>
.switcher {
    display: flex;
    height: 1.7rem;
    width: 4rem;
    border-radius: 100px;
    box-shadow: inset 0px 0px 2px gray, 0px 0px 1px black;
    position: relative;
    overflow: hidden;

    &::before {
        content: "";
        height: 100%;
        width: 0.85rem;
        background: #256fcf;
        transition: all 0.25s ease;
        opacity: 0.5;
    }

    &::after {
        content: "";
        position: absolute;
        left: 0;
        top: 0;
        width: 1.7rem;
        height: 1.7rem;
        background: white;
        transition: all 0.25s ease;
        border-radius: 50%;
        box-shadow: inset 0px 0px 3px gray;
    }
}


.switcher.on {

    &::before {
        width: calc(100% - 0.85rem);
    }

    &::after {
        left: calc(100% - 1.7rem);
    }
}


.padding {
    transition: all 0.25s ease;
}

.switcher-wrapper {
    display: flex;
    align-items: center;
}

.switcher-label {
    margin-left: 0.5rem;
    font-size: 1.1rem;
}
</style>