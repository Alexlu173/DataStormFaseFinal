<script setup>
import { onMounted, ref, computed } from 'vue'
import { useAgentesStore } from '@/stores/agentes'
import AgenteRow from '@/components/Admin/AgenteRow.vue'

const store = useAgentesStore()
const search = ref('')

onMounted(() => {
    store.fetchAgentes()
})

const filteredAgentes = computed(() => {
    if (!search.value) return store.agentes

    return store.agentes.filter(a =>
        a.nombre?.toLowerCase().includes(search.value.toLowerCase()) ||
        a.apellidos?.toLowerCase().includes(search.value.toLowerCase()) ||
        a.email?.toLowerCase().includes(search.value.toLowerCase())
    )
})
</script>

<template>
    <section class="p-6 max-w-5xl mx-auto">
        <h2 class="text-2xl font-bold mb-4">👮 Gestión de Agentes</h2>

        <input v-model="search" class="input input-bordered w-full mb-4"
            placeholder="Buscar por nombre, apellidos o email" />

        <div class="overflow-x-auto">
            <table class="table w-full">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Apellidos</th>
                        <th>Email</th>
                        <th>Rango</th>
                        <th>Activo</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <AgenteRow v-for="agente in filteredAgentes" :key="agente.id" :agente="agente" />
                </tbody>
            </table>
        </div>
    </section>
</template>
