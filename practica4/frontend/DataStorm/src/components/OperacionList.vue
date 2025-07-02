<script setup>
import { onMounted } from 'vue'
import { useOperacionStore } from '../stores/operaciones'
import { computed } from 'vue'
import OperacionItem from './OperacionItem.vue'

const store = useOperacionStore()

const operaciones = computed(() => store.operaciones)

const loading = store.loading

onMounted(() => {
    if (!operaciones.length) store.fetchOperaciones()
})
</script>
<template>
    <div>
        <h2 class="text-2xl font-bold mb-4 text-center">Operaciones disponibles</h2>
        
        <div v-if="loading" class="text-center my-6">
            <span class="loading loading-spinner text-primary"></span>
        </div>

        <div v-else-if="operaciones.length === 0" class="text-center text-gray-500">
            No hay operaciones disponibles.
        </div>

        <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
            <OperacionItem v-for="op in operaciones" :key="op.id" :operacion="op" />
        </div>
    </div>
</template>
