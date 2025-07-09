import './assets/main.css'
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import './assets/tailwind.css'
import { authStore } from '@/stores/auth'

import App from './App.vue'
import router from './router'

const app = createApp(App)

app.use(createPinia())
app.use(router)

const auth = authStore()
if(auth.token){
     auth.fetchCurrentUser().catch(() => auth.logout())
}

app.mount('#app')
