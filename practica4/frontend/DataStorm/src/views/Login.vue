<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { authStore } from '@/stores/auth'
import { storeToRefs } from 'pinia'
import FormularioLogin from '@/components/FormularioLogin.vue'

const store = authStore()
const { loading: storeLoading } = storeToRefs(store)

const localLoading = ref(false)
const router = useRouter()

async function handleLogin(data) {
  localLoading.value = true
  await store.login(data)

  setTimeout(() => {
    localLoading.value = false
    router.push('/operaciones')
  }, 1000)
}
</script>

<template>
  <section class="max-w-md mx-auto mt-16 p-6 rounded shadow">
    <h2 class="text-2xl font-bold mb-4">Iniciar Sesión</h2>

    <FormularioLogin @login="handleLogin" />

    <div v-if="storeLoading || localLoading" class="text-center my-6">
      <span class="loading loading-spinner text-primary"></span>
    </div>

    <p class="mt-4 text-sm text-center">
      ¿No tienes cuenta?
      <router-link to="/register" class="text-blue-600 hover:underline">Regístrate</router-link>
    </p>
  </section>
</template>
