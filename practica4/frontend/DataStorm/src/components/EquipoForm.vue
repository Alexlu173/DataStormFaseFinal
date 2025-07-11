<!-- components/EquipoForm.vue -->
<script setup>
import { ref } from 'vue'
import { ESPECIALIDAD_EQUIPOS } from '@/services/Constants'
import { useEquiposStore } from '@/stores/equipos'

const emit = defineEmits(['close'])

const store = useEquiposStore()

const nombre = ref('')
const especialidad = ref('')

async function handleSubmit() {
  if (!nombre.value || !especialidad.value) return

  await store.crearEquipo({
    nombre: nombre.value,
    especialidad: especialidad.value,
    operacionId: null // No se asigna aún
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
          <option disabled value="">Seleccione una especialidad</option>
          <option v-for="e in ESPECIALIDAD_EQUIPOS" :key="e" :value="e">{{ e }}</option>
        </select>

        <div class="modal-action">
          <button type="button" class="btn" @click="$emit('close')">Cancelar</button>
          <button type="submit" class="btn btn-primary">Crear equipo</button>
        </div>
      </form>
    </div>
  </dialog>
</template>
