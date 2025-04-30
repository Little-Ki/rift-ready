<template>
  <div class="popup" :class="{
    show: visible,
  }" :style="{
    zIndex,
  }" v-on:click.stop="maskClicked" @touchmove.stop @wheel.stop @mouseenter="mouseEnter" @dragleave="mouseLeave">
    <div v-if="position === 'left'" class="popup-content left" :style="{ width, height, ...styles }" @click.stop>
      <slot></slot>
    </div>
    <div v-if="position === 'top'" class="popup-content top" :style="{ width, height, ...styles }" @click.stop>
      <slot></slot>
    </div>
    <div v-if="position === 'right'" class="popup-content right" :style="{ width, height, ...styles }" @click.stop>
      <slot></slot>
    </div>
    <div v-if="position === 'bottom'" class="popup-content bottom" :style="{ width, height, ...styles }" @click.stop>
      <slot></slot>
    </div>
    <div v-if="position === 'center'" class="popup-content center" :style="{ width, height, ...styles }" @click.stop>
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { computed } from 'vue'

const props = defineProps({
  visible: {
    type: Boolean,
    default: false,
  },
  position: {
    type: String,
    default: 'center',
  },
  width: {
    type: String,
    default: 'auto',
  },
  height: {
    type: String,
    default: 'auto',
  },
  styles: {
    type: Object,
    default: {},
  },
  maskClose: {
    type: Boolean,
    default: false,
  },
  zIndex: {
    type: Number,
    default: 0,
  },
})

const mouseEnter = (e: MouseEvent) => {
  console.log('enter')
}

const mouseLeave = (e: MouseEvent) => {

  console.log('leave')
}


const emits = defineEmits(['update:visible', 'cancel'])

const visible = computed({
  get: () => props.visible,
  set: (value: boolean) => {
    emits('update:visible', value)
  },
})

const maskClicked = (e: MouseEvent) => {
  if (props.maskClose) {
    visible.value = false
    emits('cancel')
  }
}
</script>

<style lang="less" scoped>
.popup {
  position: fixed;
  left: 0;
  top: 0;
  right: 0;
  bottom: 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background: transparent;
  transition: all 0.25s ease;
  pointer-events: none;

  .popup-content {
    display: flex;
    flex-direction: column;
    opacity: 0;
  }

  .left {
    position: absolute;
    left: 0;
    top: 0;
    bottom: 0;
    transform: translateX(-100%);
    transition: all 0.25s ease;
  }

  .top {
    position: absolute;
    left: 0;
    top: 0;
    right: 0;
    transform: translateY(-100%);
    transition: all 0.25s ease;
  }

  .right {
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    transform: translateX(100%);
    transition: all 0.25s ease;
  }

  .bottom {
    position: absolute;
    left: 0;
    bottom: 0;
    right: 0;
    transform: translateY(100%);
    transition: all 0.25s ease;
  }

  .center {
    transform: scale(75%);
    transition: all 0.25s ease;
  }
}

.popup.show {
  background: #00000064;
  pointer-events: unset;

  .popup-content {
    opacity: 1;
  }

  .left {
    transform: translateX(0);
  }

  .top {
    transform: translateY(0);
  }

  .right {
    transform: translateX(0);
  }

  .bottom {
    transform: translateY(0);
  }

  .center {
    transform: scale(100%);
  }
}
</style>
