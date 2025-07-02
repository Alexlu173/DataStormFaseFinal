<script setup>
import { reactive } from 'vue'

const emit = defineEmits(['register'])

const form = reactive({
    nombreUsuario: '',
    nombre: '',
    apellidos: '',
    email: '',
    password: ''
})

function onSubmit() {
    emit('register', { ...form })
}
</script>

<template>
    <form @submit.prevent="onSubmit" class="space-y-4">
        <input v-model="form.nombreUsuario" class="input input-bordered w-full" placeholder="Nombre de usuario"
            required />
        <input v-model="form.nombre" class="input input-bordered w-full" placeholder="Nombre" required />
        <input v-model="form.apellidos" class="input input-bordered w-full" placeholder="Apellidos" required />
        <input v-model="form.email" type="email" class="input input-bordered w-full" placeholder="Correo electrónico"
            required />
        <input v-model="form.password" type="password" class="input input-bordered w-full" placeholder="Contraseña"
            required />

        <button class="btn btn-secondary w-full">Registrarse</button>
    </form>
</template>
