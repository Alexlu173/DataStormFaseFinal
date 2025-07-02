import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Register from '@/views/Register.vue'
import Operaciones from '@/views/Operaciones.vue'
import Equipos from '@/views/Equipos.vue'
import Agentes from '@/views/Agentes.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/login',
      name: Login,
      component: Login,
    },
    {
      path: '/register',
      name: 'register',
      component: Register,
    },
    {
      path: '/operaciones',
      name: 'operaciones',
      component: Operaciones,
    },
    {
      path: '/equipos',
      name: 'equipos',
      component: Equipos,
    },
    {
      path: '/agentes',
      name: 'agentes',
      component: Agentes,
    }
  ],
})

export default router
