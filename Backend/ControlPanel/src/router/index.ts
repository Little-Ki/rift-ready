import { createRouter, createWebHistory } from 'vue-router'
import IndexView from '../views/IndexView.vue'
import AboutView from '../views/AboutView.vue'
import BanView from '@/views/BanView.vue'
import PickView from '@/views/PickView.vue'
import FeatureView from '@/views/FeatureView.vue'
import ChampView from '@/views/ChampView.vue'
import GameView from '@/views/GameView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'index',
      component: IndexView,
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView,
    },
    {
      path: '/ban',
      name: 'ban',
      component: BanView,
    },
    {
      path: '/pick',
      name: 'pick',
      component: PickView,
    },
    {
      path: '/feature',
      name: 'feature',
      component: FeatureView,
    },
    {
      path: '/champ',
      name: 'champ',
      component: ChampView,
    },
    {
      path: '/game',
      name: 'game',
      component: GameView,
    },
  ],
})

export default router
