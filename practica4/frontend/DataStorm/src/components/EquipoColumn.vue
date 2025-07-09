<script setup>
defineProps({
  equipo: Object
})
</script>
<template>
  <div class="bg-base-200 p-4 rounded-lg shadow">
    <router-link :to="`/equipos/${equipo.id}`" class="font-bold text-lg mb-2 text-primary hover:underline">
      {{ equipo.nombre }}
    </router-link>
    <p class="text-sm text-gray-500 mb-3">Especialidad: {{ equipo.especialidad }}</p>

    <ul class="space-y-2">
      <li v-for="agente in equipo.agentes" :key="agente.id" class="rounded p-2 shadow text-sm">
        {{ agente.nombre }} <span class="text-gray-400">({{ agente.rango }})</span>
      </li>
    </ul>
  </div>
</template>
