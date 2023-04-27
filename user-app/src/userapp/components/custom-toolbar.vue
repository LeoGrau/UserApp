<template>
  <div class="toolbar flex justify-content-between align-items-center">
    <h1>UserApp</h1>
    <ul class="flex gap-2">
      <li><router-link to="">Home</router-link></li>
      <li><router-link to="">Edit</router-link></li>
    </ul>
  </div>
</template>

<script>
export default {}
</script>

<style scoped>
.toolbar {
  padding: 20px 100px;
  height: 65px;
  width: 100%;
  background-color: crimson;
  color: white;
}
:deep(a) {
  color: white;
}
</style>
