<template>
  <custom-toolbar></custom-toolbar>
  <div class="app flex justify-content-center align-items-center">
    <router-view></router-view>
  </div>
</template>

<script>
import CustomToolbar from './userapp/components/custom-toolbar.vue';
export default {
  components: {
    CustomToolbar,
  }
}
</script>

<style scoped>
.app {
  height: calc(100vh - 65px);
}
</style>