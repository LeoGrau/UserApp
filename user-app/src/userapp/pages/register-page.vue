<template>
  <div class="register">
    <form action="" class="flex flex-column align-items-center gap-3">
      <div class="grid">
        <div class="col-6">
          <div class="field mb-4">
            <div class="p-float-label">
              <pv-input-text v-model="username" />
              <label for="username">Username</label>
            </div>
          </div>
          <div class="field">
            <div class="p-float-label">
              <pv-password v-model="password" :feedback="false" />
              <label for="password">Password</label>
            </div>
          </div>
        </div>
        <div class="col-6">
          <div class="field mb-4">
            <div class="p-float-label">
              <pv-password v-model="password" :feedback="false" />
              <label for="password">Firstname</label>
            </div>
          </div>
          <div class="field">
            <div class="p-float-label">
              <pv-password v-model="lastname" :feedback="false" />
              <label for="password">Lastname</label>
            </div>
          </div>
        </div>
      </div>
      <label for="">Already registered? <router-link to="/">Sign In</router-link> </label>
      <pv-button label="Sign In" />
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: '',
      firstname: '',
      lastname: ''
    }
  }
}
</script>

<style></style>
