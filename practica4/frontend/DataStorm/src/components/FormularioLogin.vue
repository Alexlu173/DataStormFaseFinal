<script setup>
import { ref } from 'vue'

const emit = defineEmits(['login'])
const nombreUsuario = ref('')
const password = ref('')

function onSubmit() {
    emit('login', {
        nombreUsuario: nombreUsuario.value,
        password: password.value
    })
}
</script>

<template>
    <form @submit.prevent="onSubmit" class="space-y-4">
        <input v-model="nombreUsuario" class="input input-bordered w-full" placeholder="Usuario" required />
        <input v-model="password" type="password" class="input input-bordered w-full" placeholder="Contraseña"
            required />

        <button class="btn btn-primary w-full">Entrar</button>
    </form>
</template>
