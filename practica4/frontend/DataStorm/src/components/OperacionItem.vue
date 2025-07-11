<script setup>
defineProps(['operacion'])
defineEmits(['edit', 'delete'])

function formatDate(date) {
  return new Date(date).toLocaleDateString()
}
</script>

<template>
  <div class="relative group">
    <router-link :to="`/operaciones/${operacion.id}`" class="block">
      <div class="card bg-base-100 shadow-md border p-4 hover:shadow-lg transition">
        <h3 class="text-xl font-bold mb-1 text-primary">{{ operacion.nombre }}</h3>
        <p class="text-sm text-gray-500">Estado: {{ operacion.estado }}</p>
        <p class="text-sm text-gray-500">Inicio: {{ formatDate(operacion.fechaInicio) }}</p>
        <p class="text-sm text-gray-500">Fin: {{ formatDate(operacion.fechaFin) }}</p>
      </div>
    </router-link>

    <!-- Botones de acción -->
    <div class="absolute top-2 right-2 flex gap-2 opacity-0 group-hover:opacity-100 transition">
      <button class="btn btn-sm btn-warning" @click.stop="$emit('edit', operacion)">✏️</button>
      <button class="btn btn-sm btn-error" @click.stop="$emit('delete', operacion.id)">🗑️</button>
    </div>
  </div>
</template>
