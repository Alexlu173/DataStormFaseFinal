<script setup>
import { ref, watch, onMounted } from 'vue'

const props = defineProps({
    agente: Object, // si es null ⇒ modo crear
    equipoId: Number,
    show: Boolean
})

const emit = defineEmits(['close', 'save'])

const nombre = ref('')
const rango = ref('')
const activo = ref(true)

onMounted(() => {
    if (props.agente) {
        nombre.value = props.agente.nombre
        rango.value = props.agente.rango
        activo.value = props.agente.activo
    }
})

watch(() => props.agente, (nuevo) => {
    if (nuevo) {
        nombre.value = nuevo.nombre
        rango.value = nuevo.rango
        activo.value = nuevo.activo
    } else {
        nombre.value = ''
        rango.value = ''
        activo.value = true
    }
})

function handleSubmit() {
    const agenteData = {
        nombre: nombre.value,
        rango: rango.value,
        activo: activo.value,
        equipoId: props.equipoId
    }

    if (props.agente?.id) {
        agenteData.id = props.agente.id // para PUT
    }

    emit('save', agenteData)
    emit('close')
}
</script>

<template>
    <dialog v-if="show" open class="modal">
        <div class="modal-box">
            <h3 class="font-bold text-lg mb-4">
                {{ props.agente ? 'Editar agente' : 'Nuevo agente' }}
            </h3>

            <form @submit.prevent="handleSubmit" class="space-y-4">
                <input v-model="nombre" class="input input-bordered w-full" placeholder="Nombre del agente" required />

                <input v-model="rango" class="input input-bordered w-full" placeholder="Rango (ej. Técnico, Líder...)"
                    required />

                <label class="flex items-center gap-2">
                    <input type="checkbox" v-model="activo" class="checkbox" />
                    Activo
                </label>

                <div class="modal-action">
                    <button type="button" class="btn" @click="$emit('close')">Cancelar</button>
                    <button type="submit" class="btn btn-primary">
                        {{ props.agente ? 'Guardar cambios' : 'Crear agente' }}
                    </button>
                </div>
            </form>
        </div>
    </dialog>
</template>
