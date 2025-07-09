<script setup>
import { useRouter } from 'vue-router'
import FormularioRegister from '../components/FormularioRegister.vue'
import { authStore } from '@/stores/auth'
import { reactive } from 'vue'
const router = useRouter()
const store = authStore()

async function handleRegister(data) {
  await store.register(data)
  console.log('Datos de registro:', data)

  setTimeout(() => {
    alert('Registro exitoso')
    router.push('/login')
  }, 1000)
}

</script>

<template>
  <section class="max-w-md mx-auto mt-16  p-6 rounded shadow">
    <h2 class="text-2xl font-bold mb-4">Registrarse</h2>

    <FormularioRegister @register="handleRegister" />

    <p class="mt-4 text-sm text-center">
      ¿Ya tienes cuenta?
      <router-link to="/login" class="text-blue-600 hover:underline">Inicia sesión</router-link>
    </p>
  </section>
</template>
