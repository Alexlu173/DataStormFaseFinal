<script setup>
import { ref, onMounted } from 'vue'
import { useOperacionStore } from '../stores/operaciones'
import { computed } from 'vue'
import OperacionItem from './OperacionItem.vue'
import OperacionModal from './OperacionModal.vue'

const store = useOperacionStore()
const operaciones = computed(() => store.operaciones)
const loading = computed(() => store.loading)

const showModal = ref(false)

async function crearOperacion(op) {
  await store.crearOperacion(op)
}

onMounted(() => {
  if (!operaciones.length) store.fetchOperaciones()
})
</script>

<template>
  <div>
    <div class="flex justify-between items-center mb-6">
      <h2 class="text-2xl font-bold">Operaciones disponibles</h2>
      <button @click="showModal = true" class="btn btn-primary">+ Nueva Operación</button>
    </div>

    <div v-if="loading" class="text-center my-6">
      <span class="loading loading-spinner text-primary"></span>
    </div>

    <div v-else-if="operaciones.length === 0" class="text-center text-gray-500">
      No hay operaciones disponibles.
    </div>

    <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
      <OperacionItem v-for="op in operaciones" :key="op.id" :operacion="op" />
    </div>

    <OperacionModal :open="showModal" @close="showModal = false" @create="crearOperacion" />
  </div>
</template>

