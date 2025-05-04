<template>
    <div :class="`router-button icon-${icon} ${routerName === name ? 'active' : ''}`" @click="() => routeTo(name)">
    </div>
</template>

<script lang="ts" setup>
import { computed } from 'vue';
import { useRouter } from 'vue-router';


defineProps({
    name: {
        type: String,
        default: null
    },
    icon: {
        type: String,
        default: null
    }
})

const router = useRouter()

const routerName = computed(() => router.currentRoute.value.name);

const routeTo = (name: string) => {
    router.replace({
        name
    })
}
</script>

<style lang="less" scoped>
.router-button {
    font-size: 1.25rem;
    padding: 0.5rem;
    line-height: 1;
    border-radius: 0.25rem;
    margin-bottom: 0.25rem;
    transition: all 0.25s;
    user-select: none;
    -webkit-user-drag: none;
    cursor: pointer;
    transition: all 0.5s ease;
}

.router-button.active {
    background: #e0e0e0;
}


.router-button:hover,
.router-button:active {
    background: #e0e0e0;
}
</style>