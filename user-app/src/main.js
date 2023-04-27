import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import PrimeVue from "primevue/config";

import './assets/main.css'

//Primeflex
import "primeflex/primeflex.css";

//Primevue styles
import "primevue/resources/themes/lara-light-indigo/theme.css";
import "primevue/resources/primevue.min.css";

//Primevue Components
import Button from "primevue/button";
import InputText from "primevue/inputtext";
import Password from "primevue/password";

const app = createApp(App)

app.use(PrimeVue, { ripple: true })
app.use(createPinia())
app.use(router)

app.component("pv-button", Button);
app.component("pv-input-text", InputText);
app.component("pv-password", Password);

app.mount('#app')
