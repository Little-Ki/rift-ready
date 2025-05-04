<template>
  <div class="main-content">
    <div class="router">
      <div class="status-icon" :class="{
        on: gameStatus.isOpen
      }">
      </div>
      <router-button icon="home" name="index" />
      <router-button icon="ban" name="ban" />
      <router-button icon="picker" name="pick" />
      <router-button icon="wrench" name="feature" />
      <router-button icon="sword" name="champ" />
      <router-button icon="lobby" name="game" />
      <router-button icon="info" name="about" />
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

import RouterButton from './components/RouterButton.vue';

const router = useRouter();


const gameStatus = ref({} as GameStatus)

const fetchStatus = () => Api.status.get().then(({ data }) => {
  gameStatus.value = data.data
})

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