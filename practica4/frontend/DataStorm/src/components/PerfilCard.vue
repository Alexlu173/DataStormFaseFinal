<script setup>
const props = defineProps({ agente: Object })
</script>

<template>
    <div class="bg-base-100 rounded-lg shadow p-6 flex flex-col items-center">
        <div class="avatar mb-4">
            <div class="w-24 rounded-full ring ring-primary ring-offset-base-100 ring-offset-2">
                <div class="avatar">
                    <div class="ring-primary ring-offset-base-100 w-24 rounded-full ring-2 ring-offset-2">
                        <img src="https://img.daisyui.com/images/profile/demo/spiderperson@192.webp" />
                    </div>
                </div>
            </div>
        </div>
        <h3 class="text-2xl font-bold mb-1">{{ agente.nombre }} {{ agente.apellidos }}</h3>
        <div class="text-primary font-semibold mb-2">{{ agente.rango }}</div>
        <div class="mb-2">
            <span v-if="agente.activo" class="badge badge-success">Activo</span>
            <span v-else class="badge badge-error">Inactivo</span>
        </div>
        <div class="text-gray-500 mb-4">{{ agente.email }}</div>
        <button class="btn btn-outline btn-sm">Editar perfil</button>
    </div>
</template>