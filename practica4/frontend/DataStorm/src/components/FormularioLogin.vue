<script setup>
import { ref } from 'vue'

const emit = defineEmits(['login'])
const email = ref('')
const password = ref('')

function onSubmit() {
    emit('login', {
        email: email.value,
        password: password.value
    })
}
</script>

<template>
    <form @submit.prevent="onSubmit" class="space-y-4">
        <input v-model="email" type="email" class="input input-bordered w-full" placeholder="Correo electrónico"
            required />
        <input v-model="password" type="password" class="input input-bordered w-full" placeholder="Contraseña"
            required />

        <button type="submit" class="btn btn-primary w-full">Entrar</button>
    </form>
</template>
