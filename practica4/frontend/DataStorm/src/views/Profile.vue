<script setup>
import { authStore } from '@/stores/auth'
import PerfilCard from '@/components/PerfilCard.vue'
import PerfilStats from '@/components/PerfilStats.vue'
import PerfilEquipos from '@/components/PerfilEquipos.vue'

const auth = authStore()

// Simulación de stats y equipos, reemplaza por tus datos reales
const stats = {
  operaciones: 5,
  equipos: auth.user?.equipos?.length || 0,
  agentes: 8
}
const equipos = auth.user?.equipos || []
</script>

<template>
  <section class="max-w-3xl mx-auto mt-10">
    <h2 class="text-3xl font-bold mb-6">Mi Perfil</h2>
    <PerfilCard :agente="auth.user" />
    <PerfilStats :stats="stats" />
    <PerfilEquipos :equipos="equipos" />
  </section>
</template>