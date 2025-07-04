<script setup>
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import EquiposBoard from '@/components/EquiposBoard.vue'
import { useEquiposStore } from '@/stores/equipos'
import EquipoModal from '@/components/EquipoModal.vue'

const store = useEquiposStore()
const route = useRoute()
const operacion = ref(null)
const mostrarModal = ref(false)

async function fetchOperacion() {
    const res = await fetch(`http://localhost:5190/api/operaciones/${route.params.id}`)
    if (res.ok) {
        const data = await res.json()
        operacion.value = { ...data }
    }
}

onMounted(fetchOperacion)

async function crearEquipo(data) {
    await store.crearEquipo(data)
    await fetchOperacion() // refresca los equipos desde el backend
}

function abrirModalCrearEquipo() {
    mostrarModal.value = true
}
</script>

<template>
    <section class="p-6">
        <h1 class="text-2xl text-center font-bold mb-4">Operación: {{ operacion?.nombre || '...' }}</h1>

        <EquiposBoard :equipos="operacion?.equipos || []" @add="abrirModalCrearEquipo" />
        <EquipoModal v-if="mostrarModal" :operacion-id="operacion.id" @close="mostrarModal = false"
            @create="crearEquipo" />

    </section>
</template>
