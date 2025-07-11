<script setup>
import { ref, computed, onMounted } from 'vue'
import { useEquiposStore } from '@/stores/equipos'

const props = defineProps({
    operacionId: Number,
    open: Boolean
})
const emit = defineEmits(['close'])

const store = useEquiposStore()
const equipoSeleccionado = ref(null)

const equiposDisponibles = computed(() =>
    store.equipos.filter(e => e.operacionId === null)
)

onMounted(async () => {
    if (store.equipos.length === 0) {
        await store.fetchEquipos()
    }
})

async function asignarEquipo() {
    const equipo = store.getEquipoById(equipoSeleccionado.value)
    if (!equipo) return

    await store.editarEquipo(equipo.id, {
        nombre: equipo.nombre,
        especialidad: equipo.especialidad,
        operacionId: props.operacionId
    })

    emit('close')
}
</script>

<template>
    <dialog class="modal" v-if="open" open>
        <div class="modal-box">
            <h3 class="font-bold text-lg mb-4">Asignar equipo existente</h3>

            <select v-model="equipoSeleccionado" class="select select-bordered w-full">
                <option :value="null" disabled selected>Selecciona un equipo</option>
                <option v-for="equipo in equiposDisponibles" :key="equipo.id" :value="equipo.id">
                    {{ equipo.nombre }} - {{ equipo.especialidad }}
                </option>
            </select>

            <div class="modal-action">
                <button class="btn" @click="$emit('close')">Cancelar</button>
                <button class="btn btn-primary" :disabled="!equipoSeleccionado" @click="asignarEquipo">Asignar</button>
            </div>
        </div>
    </dialog>
</template>
