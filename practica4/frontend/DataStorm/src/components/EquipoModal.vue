<!-- components/EquipoModal.vue -->
<script setup>
import { ref } from 'vue'
import { ESPECIALIDAD_EQUIPOS } from '@/services/Constants'

const emit = defineEmits(['create', 'close'])
const props = defineProps({ operacionId: Number })

const nombre = ref('')
const especialidad = ref('Reconocimiento')

function handleSubmit() {
    emit('create', {
        nombre: nombre.value,
        especialidad: especialidad.value,
        operacionId: props.operacionId
    })
    // Reset
    nombre.value = ''
    especialidad.value = 'Reconocimiento'
}
</script>

<template>
    <dialog class="modal" open>
        <div class="modal-box">
            <h3 class="font-bold text-lg mb-4">Crear nuevo equipo</h3>
            <form @submit.prevent="handleSubmit" class="space-y-4">
                <input v-model="nombre" placeholder="Nombre del equipo" class="input input-bordered w-full" required />

                <select v-model="especialidad" class="select select-bordered w-full" required>
                    <option v-for="esp in ESPECIALIDAD_EQUIPOS" :key="esp" :value="esp">{{ esp }}</option>
                </select>

                <div class="modal-action">
                    <button type="button" class="btn" @click="$emit('close')">Cancelar</button>
                    <button type="submit" class="btn btn-primary">Crear</button>
                </div>
            </form>
        </div>
    </dialog>
</template>
