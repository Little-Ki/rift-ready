import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Config } from '@/api/config'

export const useConfigStore = defineStore('config', () => {
  const data = ref({
    autoBan: {
      enable: false,
      championIds: []
    },
    autoPick: {
      enable: false,
      championIds: []
    },
    feature: {
      autoAcceptMM: false
    }
  } as Config)

  function patch(value: Config) {
    data.value = value
  }

  return { data, patch }
})
