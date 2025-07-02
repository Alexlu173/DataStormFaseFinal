<script setup>
defineProps(['operacion'])

function formatDate(date) {
    return new Date(date).toLocaleDateString()
}
</script>

<template>
    <div class="card bg-base-100 shadow-md border p-4 hover:shadow-lg transition">
        <h3 class="text-xl font-bold mb-1 text-primary">{{ operacion.nombre }}</h3>
        <p class="text-sm text-gray-500">Estado: {{ operacion.estado }}</p>
        <p class="text-sm text-gray-500">Inicio: {{ formatDate(operacion.fechaInicio) }}</p>
        <p class="text-sm text-gray-500">Fin: {{ formatDate(operacion.fechaFin) }}</p>
    </div>
</template>
