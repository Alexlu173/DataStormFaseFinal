<script setup>
import { ref } from 'vue'
import EquipoColumn from './EquipoColumn.vue'
import AssignEquipoModal from './AssignEquipoModal.vue'

defineProps({ equipos: Array, operacionId: [String, Number] })
defineEmits(['add'])

const showAssignModal = ref(false)
</script>

<template>
    <div>
        <div class="flex justify-between items-center mb-4">
            <h2 class="text-2xl font-bold">Equipos en esta operación</h2>
            <div class="flex gap-2">
                <button @click="showAssignModal = true" class="btn btn-outline btn-info">📥 Asignar Equipo</button>
            </div>
        </div>

        <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
            <EquipoColumn v-for="equipo in equipos" :key="equipo.id" :equipo="equipo" />
        </div>

        <AssignEquipoModal v-if="showAssignModal" :operacion-id="operacionId" :open="showAssignModal" @close="showAssignModal = false"/>
    </div>
</template>
