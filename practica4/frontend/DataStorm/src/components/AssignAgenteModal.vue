<script setup>
import { ref, computed, onMounted } from 'vue'
import { useAgentesStore } from '@/stores/agentes';

const props = defineProps({
    equipoId: Number,
    open: Boolean
})

const emit = defineEmits(['close'])
const store = useAgentesStore()
const agenteSeleccionado = ref(null)
const agentesDisponibles = computed(() =>
    store.agentes.filter(a => a.equipoId === null)
)

onMounted(async () => {
    if (store.agentes.length === 0) {
        await store.fetchAgentes()
    }
})

async function asignarAgente() {
    const agente = store.getAgenteById(agenteSeleccionado.value)
    if (!agente) return

    await store.editarAgente(agente.id, {
        nombre: agente.nombre,
        apellidos: agente.apellidos,
        email: agente.email,
        rango: agente.rango,
        activo: agente.activo,
        equipoId: props.equipoId
    })

    emit('close')
}
</script>

<template>
    <dialog class="modal" v-if="open" open>
        <div class="modal-box">
            <h3 class="font-bold text-lg mb-4">Asignar agente existente</h3>

            <select v-model="agenteSeleccionado" class="select select-bordered w-full">
                <option :value="null" disabled selected>Selecciona un agente</option>
                <option v-for="agente in agentesDisponibles" :key="agente.id" :value="agente.id">
                    {{ agente.nombre }} {{ agente.apellidos }} -Rango: {{ agente.rango }}
                </option>
            </select>

            <div class="modal-action">
                <button class="btn" @click="$emit('close')">Cancelar</button>
                <button class="btn btn-primary" :disabled="!agenteSeleccionado" @click="asignarAgente">Asignar</button>
            </div>
        </div>
    </dialog>
</template>