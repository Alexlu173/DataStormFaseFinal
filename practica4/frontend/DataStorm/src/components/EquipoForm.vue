<script setup>
import { ref } from 'vue'
import { useEquiposStore } from '@/stores/equipos'
import { ESPECIALIDAD_EQUIPOS } from '@/services/Constants'

const props = defineProps({
    operacionId: [Number, String]
})
const emit = defineEmits(['close'])

const store = useEquiposStore()

const nombre = ref('')
const especialidad = ref('')

async function handleSubmit() {
    if (!nombre.value || !especialidad.value) return

    await store.crearEquipo({
        nombre: nombre.value,
        especialidad: especialidad.value,
        operacionId: Number(props.operacionId) // asignación directa
    })

    emit('close')
}
</script>

<template>
    <dialog open class="modal">
        <div class="modal-box">
            <h3 class="font-bold text-lg mb-4">Crear nuevo equipo</h3>

            <form @submit.prevent="handleSubmit" class="space-y-4">
                <input v-model="nombre" placeholder="Nombre del equipo" class="input input-bordered w-full" required />

                <select v-model="especialidad" class="select select-bordered w-full" required>
                    <option value="" disabled selected>Seleccione una especialidad</option>
                    <option v-for="especialidad in ESPECIALIDAD_EQUIPOS" :key="especialidad" :value="especialidad">
                        {{ especialidad }}
                    </option>
                </select>

                <div class="modal-action">
                    <button type="button" class="btn" @click="$emit('close')">Cancelar</button>
                    <button type="submit" class="btn btn-primary">Crear equipo</button>
                </div>
            </form>
        </div>
    </dialog>
</template>
