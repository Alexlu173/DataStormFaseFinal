<script setup>
defineProps({ equipos: Array })
defineEmits(['add'])
import EquipoColumn from './EquipoColumn.vue'
</script>

<template>
    <div class="flex justify-between items-center mb-6">
        <h2 class="text-2xl font-bold">Equipos</h2>
        <!-- Botón para añadir equipo como columna -->
        <button class="btn btn-primary" @click="$emit('add')">➕ Añadir Equipo</button>
    </div>
    <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
        <!-- Equipos -->
        <EquipoColumn v-for="equipo in equipos" :key="equipo.id" :equipo="equipo" />
    </div>
</template>
