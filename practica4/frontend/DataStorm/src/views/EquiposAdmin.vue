<script setup>
import { onMounted } from 'vue'
import { useEquiposStore } from '@/stores/equipos'
import EquipoColumn from '@/components/EquipoColumn.vue'
import EquipoForm from '@/components/EquipoForm.vue'
import { ref, computed } from 'vue'

const store = useEquiposStore()
const search = ref('')
const showModal = ref(false)

onMounted(() => {
    store.fetchEquipos()
})

const filteredEquipos = computed(() => {
    if (!search.value) return store.equipos

    return store.equipos.filter(e =>
        e.nombre?.toLowerCase().includes(search.value.toLowerCase()) ||
        e.especialidad?.toLowerCase().includes(search.value.toLowerCase())
    )
})
</script>

<template>
    <section class="p-6 max-w-7xl mx-auto">
        <div class="flex justify-between items-center mb-6">
            <h2 class="text-2xl font-bold">🛡️ Todos los Equipos</h2>
            <button @click="showModal = true" class="btn btn-primary">+ Crear equipo</button>
        </div>

        <input v-model="search" class="input input-bordered w-full mb-4"
            placeholder="Buscar por nombre o especialidad" />

        <div v-if="store.loading" class="text-center my-6">
            <span class="loading loading-spinner text-primary"></span>
        </div>

        <div v-else-if="store.equipos.length === 0" class="text-center text-gray-500">
            No hay equipos registrados.
        </div>

        <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
            <EquipoColumn v-for="equipo in filteredEquipos" :key="equipo.id" :equipo="equipo" />
        </div>
        <EquipoForm v-if="showModal" @close="showModal = false" />
    </section>
</template>
