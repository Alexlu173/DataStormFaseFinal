<script setup>
defineProps({
  equipos: {
    type: Array,
    required: true
  }
})
</script>

<template>
  <div class="mt-8">
    <h3 class="text-xl font-bold mb-4">Mis Equipos</h3>
    <div v-if="equipos.length" class="grid md:grid-cols-2 gap-4">
      <div v-for="equipo in equipos" :key="equipo.id" class="bg-base-100 rounded shadow p-4">
        <div class="font-semibold text-primary mb-1">{{ equipo.nombre }}</div>
        <div class="text-sm text-gray-500 mb-1">Especialidad: {{ equipo.especialidad }}</div>
        <router-link :to="`/equipos/${equipo.id}`" class="btn btn-xs btn-outline mt-2">Ver equipo</router-link>
      </div>
    </div>
    <div v-else class="text-gray-400">No perteneces a ningún equipo.</div>
  </div>
</template>