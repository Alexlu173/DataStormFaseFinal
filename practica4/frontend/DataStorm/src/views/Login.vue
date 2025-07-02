<script setup>
import { useRouter } from 'vue-router'
import FormularioLogin from '@/components/FormularioLogin.vue'

const router = useRouter()

</script>

<template>
  <section class="max-w-md mx-auto mt-16 p-6 rounded shadow">
    <h2 class="text-2xl font-bold mb-4">Iniciar Sesión</h2>

    <FormularioLogin @login="handleLogin" />

    <p class="mt-4 text-sm text-center">
      ¿No tienes cuenta?
      <router-link to="/register" class="text-blue-600 hover:underline">Regístrate</router-link>
    </p>
  </section>
</template>
