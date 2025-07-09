<script setup>
import { ref, onMounted } from 'vue'
import { authStore } from '@/stores/auth'
const isDarkMode = ref(false)

function applyTheme(theme) {
  document.documentElement.setAttribute('data-theme', theme)
  localStorage.setItem('theme', theme)
  isDarkMode.value = theme === 'dark'
}

function toggleTheme() {
  const newTheme = isDarkMode.value ? 'dark' : 'light'
  applyTheme(newTheme)
}

onMounted(() => {
  const savedTheme = localStorage.getItem('theme')

  if (savedTheme) {
    // Si el usuario ya eligió un tema y esta guardado en el localstorage, se aplica ese
    applyTheme(savedTheme)
  } else {
    // Si no hay preferencia guardada, detecta la del sistema
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches
    const theme = prefersDark ? 'dark' : 'light'
    applyTheme(theme)
  }
})
const auth = authStore()

function handleLogout() {
  auth.logout()
  window.location.reload()
}
</script>

<template>
  <div class="navbar bg-base-100 px-4">
    <!-- Logo y título -->
    <div class="flex-1">
      <router-link to="/" class="btn btn-ghost normal-case text-xl">DataStorm</router-link>
    </div>
    <!-- Links -->
    <div class="flex grow justify-end px-2">
      <div class="hidden md:flex items-center gap-4">
        <router-link to="/" class="btn btn-ghost">Inicio</router-link>
        <template v-if="!auth.isAuthenticated">
          <router-link to="/operaciones" class="btn btn-ghost">Operaciones</router-link>
          <router-link to="/login" class="btn btn-ghost">Login</router-link>
          <router-link to="/register" class="btn btn-ghost">Registro</router-link>
          <label class="toggle text-base-content">
            <input type="checkbox" v-model="isDarkMode" class="theme-controller" @change="toggleTheme" />

            <svg aria-label="sun" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
              <g stroke-linejoin="round" stroke-linecap="round" stroke-width="2" fill="none" stroke="currentColor">
                <circle cx="12" cy="12" r="4"></circle>
                <path d="M12 2v2"></path>
                <path d="M12 20v2"></path>
                <path d="m4.93 4.93 1.41 1.41"></path>
                <path d="m17.66 17.66 1.41 1.41"></path>
                <path d="M2 12h2"></path>
                <path d="M20 12h2"></path>
                <path d="m6.34 17.66-1.41 1.41"></path>
                <path d="m19.07 4.93-1.41 1.41"></path>
              </g>
            </svg>
            <svg aria-label="moon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
              <g stroke-linejoin="round" stroke-linecap="round" stroke-width="2" fill="none" stroke="currentColor">
                <path d="M12 3a6 6 0 0 0 9 9 9 9 0 1 1-9-9Z"></path>
              </g>
            </svg>
          </label>
        </template>
        <template v-else>
          <router-link to="/operaciones" class="btn btn-ghost">Operaciones</router-link>
          <div class="dropdown dropdown-end" v-if="auth.user">
            <div tabindex="0" role="button"
              class="avatar avatar-placeholder bg-neutral text-neutral-content w-8 rounded-full">{{ auth.user.nombre }}
            </div>
            <ul tabindex="0" class="menu dropdown-content bg-base-200 rounded-box z-1 mt-4 w-52 p-2 shadow-sm">
              <li><router-link to="/perfil">Perfil</router-link></li>
              <li><a @click="handleLogout">Cerrar sesión</a></li>
            </ul>
          </div>
        </template>
      </div>
      <!-- Menú móvil -->
      <div class="dropdown dropdown-end md:hidden">
        <label tabindex="0" class="btn btn-ghost">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
          </svg>
        </label>
        <ul tabindex="0" class="menu dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52">
          <li><router-link to="/">Inicio</router-link></li>
          <template v-if=true>
            <li><router-link to="/login">Login</router-link></li>
            <li><router-link to="/register">Registro</router-link></li>
          </template>
          <template v-else>
            <li><router-link to="/todolist">Tareas</router-link></li>
            <li><a @click="logout">Cerrar sesión</a></li>
          </template>
        </ul>
      </div>
    </div>
  </div>
</template>
