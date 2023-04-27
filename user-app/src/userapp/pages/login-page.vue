<template>
  <div class="login">
    <form action="" class="flex flex-column align-items-center gap-2 p-fluid">
      <div class="field">
        <div class="p-float-label">
          <pv-input-text v-model="username" />
          <label for="username">Username</label>
        </div>
      </div>
      <div class="field">
        <div class="p-float-label">
          <pv-password v-model="password" :feedback="false"/>
          <label for="password">Password</label>
        </div>
      </div>
      <label for="">Not signed? <router-link to="/">Register</router-link> </label>
      <pv-button label="Log In" />
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: "",
      password: ""
    };
  },
}
</script>

<style scoped>
.login {
  
}
</style>