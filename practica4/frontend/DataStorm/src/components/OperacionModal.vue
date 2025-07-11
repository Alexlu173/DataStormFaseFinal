<script setup>
import { ref, watch } from 'vue'
import { ESTADO_OPERACIONES } from '../services/Constants'

const emit = defineEmits(['create', 'close'])
const props = defineProps({
    open: Boolean,
    editing: Object
})

const nombre = ref('')
const estado = ref('Planificada')
const fechaInicio = ref('')
const fechaFin = ref('')

// Cargar datos si es edición
watch(() => props.editing, (val) => {
    if (val) {
        nombre.value = val.nombre
        estado.value = val.estado
        fechaInicio.value = val.fechaInicio?.slice(0, 10)
        fechaFin.value = val.fechaFin?.slice(0, 10)
    } else {
        nombre.value = ''
        estado.value = 'Planificada'
        fechaInicio.value = ''
        fechaFin.value = ''
    }
}, { immediate: true })

function handleSubmit() {
    emit('create', {
        nombre: nombre.value,
        estado: estado.value,
        fechaInicio: fechaInicio.value,
        fechaFin: fechaFin.value
    })
}
</script>

<template>
    <dialog class="modal" v-if="open" open>
        <div class="modal-box">
            <h3 class="font-bold text-lg mb-4">
                {{ editing ? 'Editar operación' : 'Crear nueva operación' }}
            </h3>

            <form @submit.prevent="handleSubmit" class="space-y-3">
                <input v-model="nombre" class="input input-bordered w-full" placeholder="Nombre de la operación"
                    required />

                <select v-model="estado" class="select select-bordered w-full" required>
                    <option v-for="estado in ESTADO_OPERACIONES" :key="estado" :value="estado">
                        {{ estado }}
                    </option>
                </select>

                <div class="flex gap-2">
                    <input type="date" v-model="fechaInicio" class="input input-bordered w-full" required />
                    <input type="date" v-model="fechaFin" class="input input-bordered w-full" required />
                </div>

                <div class="modal-action">
                    <button class="btn" type="button" @click="$emit('close')">Cancelar</button>
                    <button class="btn btn-primary" type="submit">
                        {{ editing ? 'Guardar cambios' : 'Crear' }}
                    </button>
                </div>
            </form>
        </div>
    </dialog>
</template>
