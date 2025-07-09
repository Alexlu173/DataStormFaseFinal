import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Register from '@/views/Register.vue'
import Operaciones from '@/views/Operaciones.vue'
import Equipos from '@/views/Equipos.vue'
import Agentes from '@/views/Agentes.vue'
import OperacionTablero from '../views/OperacionTablero.vue'
import EquipoDetail from '@/views/EquipoDetail.vue'
import { authStore } from '@/stores/auth'

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
      meta: {
        requiresAuth: true, // Protege esta ruta
      }
    },
    {
      path: '/operaciones/:id',
      name: 'operacion-tablero',
      component: OperacionTablero,
      meta: {
        requiresAuth: true, // Protege esta ruta
      }
    },
    {
      path: '/equipos',
      name: 'equipos',
      component: Equipos,
      meta: {
        requiresAuth: true,

      }
    },
    {
      path: '/equipos/:id',
      nanme: 'EquipoDetail',
      component: EquipoDetail,
      meta: {
        requiresAuth: true, // Protege esta ruta
      }
    },
    {
      path: '/agentes',
      name: 'agentes',
      component: Agentes,
    }
  ],
})

router.beforeEach((to, from, next) => {
  const auth = authStore()
  const requiresAuth = to.meta.requiresAuth

  if (requiresAuth && !auth.token) {
    return next('/login')
  }

  next()
})


export default router
