<script setup>
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { useEquiposStore } from '@/stores/equipos'
import { useAgentesStore } from '@/stores/agentes'

import AgenteCard from '@/components/AgenteCard.vue'
import AgenteModal from '@/components/AgenteModal.vue'
import AssignAgenteModal from '@/components/AssignAgenteModal.vue'

const route = useRoute()
const equipoId = Number(route.params.id)

const equiposStore = useEquiposStore()
const agentesStore = useAgentesStore()

const equipo = ref(null)
const mostrarModal = ref(false)
const agenteSeleccionado = ref(null)

async function cargarEquipo() {
    await equiposStore.fetchEquipos()
    equipo.value = equiposStore.getEquipoById(equipoId)
}

function abrirModalCrear() {
    agenteSeleccionado.value = null
    mostrarModal.value = true
}

function abrirModalEditar(agente) {
    agenteSeleccionado.value = agente
    mostrarModal.value = true
}

async function eliminarAgente(agente) {
    const confirmacion = confirm(`¿Eliminar al agente ${agente.nombre}?`)
    if (!confirmacion) return

    await agentesStore.eliminarAgente(agente.id)
    await cargarEquipo()
}

function cerrarModal() {
    mostrarModal.value = false
}

async function guardarAgente(agente) {
    if (agente.id) {
        await agentesStore.editarAgente(agente.id, agente)
    } else {
        await agentesStore.crearAgente(agente)
    }
    await cargarEquipo()
}

onMounted(cargarEquipo)
</script>

<template>
    <section v-if="equipo" class="max-w-3xl mx-auto px-4 py-6">
        <h1 class="text-3xl font-bold mb-2 text-primary">{{ equipo.nombre }}</h1>
        <p class="text-gray-600 mb-4">Especialidad: {{ equipo.especialidad }}</p>

        <div class="flex justify-between items-center mb-4">
            <h2 class="text-xl font-semibold">Agentes del equipo</h2>
            <button class="btn btn-sm btn-primary" @click="abrirModalCrear">➕ Añadir agente</button>
            <button class="btn btn-sm btn-primary" @click="abrirModalCrear">➕ Asignar agente</button>
        </div>

        <div class="grid sm:grid-cols-2 gap-4">
            <AgenteCard v-for="agente in equipo.agentes" :key="agente.id" :agente="agente" @edit="abrirModalEditar"
                @delete="eliminarAgente" />
        </div>
    </section>

    <!-- Modal -->
    <AgenteModal :show="mostrarModal" :agente="agenteSeleccionado" :equipo-id="equipoId" @save="guardarAgente"
        @close="cerrarModal" />
    <AssignAgenteModal :equipo-id="equipoId" :open="mostrarModal" @close="cerrarModal" />
</template>
