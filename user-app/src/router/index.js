import { createRouter, createWebHistory } from 'vue-router'
import HomeView from "../userapp/pages/home-page.vue";
import LoginView from "../userapp/pages/login-page.vue";
import RegisterView from "../userapp/pages/register-page.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: "/register",
      name: "register",
      component: RegisterView

    },
    {
      path: "/auth",
      name: "auth",
    }
  ]
})

// router.beforeEach((to, from, next) => {
//   const requireAuth = to.matched.some(record => record.meta.req);
// })

export default router
