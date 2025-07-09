<script setup>
const props = defineProps({
    agente: Object
})
const emit = defineEmits(['edit', 'delete'])
</script>

<template>
    <div class="card bg-base-100 shadow-md border border-gray-200">
        <div class="card-body">
            <h2 class="card-title text-lg text-primary">{{ agente.nombre }}</h2>
            <p class="text-sm text-gray-600">Rango: {{ agente.rango }}</p>
            <p class="text-sm text-gray-500" v-if="agente.activo">🟢 Activo</p>
            <p class="text-sm text-gray-400" v-else>🔴 Inactivo</p>

            <div class="card-actions justify-end mt-2">
                <button class="btn btn-xs btn-outline btn-info" @click="$emit('edit', agente)">✏️ Editar</button>
                <button class="btn btn-xs btn-outline btn-error" @click="$emit('delete', agente)">🗑️ Eliminar</button>
            </div>
        </div>
    </div>
</template>
