<template>
  <div class="main-content">
    <div class="router">
      <div class="status-icon" :class="{
        on: gameStatus.isOpen
      }">
      </div>
      <div class="router-item icon-home" @click="() => routeTo('index')" :class="{ active: routerName === 'index' }">
      </div>
      <div class="router-item icon-ban" @click="() => routeTo('ban')" :class="{ active: routerName === 'ban' }">
      </div>
      <div class="router-item icon-picker" @click="() => routeTo('pick')" :class="{ active: routerName === 'pick' }">
      </div>
      <div class="router-item icon-wrench" @click="() => routeTo('feature')"
        :class="{ active: routerName === 'feature' }">
      </div>
      <div class="router-item icon-sword" @click="() => routeTo('champ')" :class="{ active: routerName === 'champ' }">
      </div>
      <div class="router-item icon-lobby" @click="() => routeTo('game')" :class="{ active: routerName === 'game' }">
      </div>
      <div class="router-item icon-info" @click="() => routeTo('about')" :class="{ active: routerName === 'about' }">
      </div>
    </div>
    <div class="router-view">
      <router-view v-slot="{ Component }">
        <transition name="fade">
          <keep-alive>
            <component :is="Component" />
          </keep-alive>
        </transition>
      </router-view>
    </div>
  </div>

</template>

<script setup lang="ts">
import { RouterView, useRouter } from 'vue-router'
import { computed, onMounted, ref } from 'vue';
import type { GameStatus } from '@/api/status'
import Api from './api';

const router = useRouter();

const routerName = computed(() => router.currentRoute.value.name);

const gameStatus = ref({} as GameStatus)

const fetchStatus = () => Api.status.get().then(({ data }) => {
  gameStatus.value = data.data
})

const routeTo = (name: string) => {
  router.replace({
    name
  })
}
onMounted(() => {
  setInterval(fetchStatus, 2000);
})
</script>

<style lang="less" scoped>
.main-content {
  display: flex;
  height: 100%;
  width: 100%;
  overflow: hidden;
}

.router {
  padding: 1rem 0.5rem;
  width: 50px;
  display: flex;
  flex-direction: column;
  align-items: center;
  background: #f0f0f0;
  border-right: 1px solid #e0e0e0;
  user-select: none;
}

.router-item {
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

.router-item.active {
  background: #e0e0e0;
}


.router-item:hover,
.router-item:active {
  background: #e0e0e0;
}

.router-view {
  display: flex;
  flex-direction: column;
  width: calc(100% - 51px);
  position: relative;
}

.status-icon {
  border-radius: 50%;
  width: 1.2rem;
  height: 1.2rem;
  margin-bottom: 1.5rem;
  background: radial-gradient(circle, rgba(255, 0, 0, 1) 0%, rgba(232, 144, 30, 1) 100%);
  position: relative;

  &::after {
    position: absolute;
    content: "";
    transition: all 0.5s;
    border-radius: 50%;
    width: 1.2rem;
    height: 1.2rem;
    background: radial-gradient(circle, rgba(57, 171, 29, 1) 0%, rgba(48, 255, 93, 1) 100%);
    opacity: 0;
  }

  &.on::after {
    opacity: 1;
  }
}


.router-bar {
  display: flex;
}

.fade-enter-active,
.fade-leave-active {
  transition: all 1s ease;
}


.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>