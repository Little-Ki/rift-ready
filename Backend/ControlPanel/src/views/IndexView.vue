<template>
  <div class="view-content">
    <div class="header">
      <div class="title">Rift Ready</div>
      <div class="sub-title">欢迎使用</div>
    </div>

    <div class="line"></div>
    <a
      href="https://github.com/Little-Ki/rift-ready"
      class="github icon-github"
      target="_blank"
      rel="noopener noreferrer"
      ></a
    >
  </div>
</template>

<script lang="ts" setup></script>

<style lang="less" scoped>
.view-content {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.header {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 0.5rem;

  .title {
    font-size: 1.5rem;
    font-weight: bold;
  }

  .sub-title {
    font-size: 1.1rem;
  }
}

.line {
  border-bottom: 1px dashed #808080;
  margin: 16px 0;
  width: calc(50%);
}

.github {
  font-size: 2rem;
}
</style>
