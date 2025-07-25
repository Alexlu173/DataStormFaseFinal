<script setup>
import Footer from '../components/Footer.vue'

</script>

<template>
  <div class="min-h-screen flex flex-col bg-base-100">
    <!-- Hero Section -->
    <section class="puff-in-center bg-gradient-to-b from-primary to-blue-300 text-white text-center py-20 px-6">
      <div class="max-w-4xl mx-auto">
        <h1 class="text-4xl md:text-6xl font-bold leading-tight mb-4">Coordina, Controla y Ejecuta.</h1>
        <p class="text-lg md:text-xl mb-8">
          DataStorm es tu centro de comando para la gestión táctica de operaciones, equipos y agentes.
        </p>
        <router-link to="/register" class="btn btn-accent btn-lg">Empieza ahora gratis</router-link>
      </div>
    </section>

    <!-- Características -->
    <section class="py-20 px-6 bg-base-200">
      <div class="max-w-6xl mx-auto grid gap-10 md:grid-cols-3 text-center">
        <div>
          <div class="text-5xl mb-4">📋</div>
          <h3 class="text-xl font-bold mb-2">Gestión de Operaciones</h3>
          <p class="text-gray-600">Planifica y supervisa cada operación desde una única vista.</p>
        </div>
        <div>
          <div class="text-5xl mb-4">🧑‍🤝‍🧑</div>
          <h3 class="text-xl font-bold mb-2">Equipos Inteligentes</h3>
          <p class="text-gray-600">Asigna agentes, gestiona especialidades y control de estado.</p>
        </div>
        <div>
          <div class="text-5xl mb-4">📊</div>
          <h3 class="text-xl font-bold mb-2">Análisis de Datos</h3>
          <p class="text-gray-600">Obtén visualizaciones y métricas para tomar decisiones.</p>
        </div>
      </div>
    </section>

    <!-- Mockup Section -->
    <section class="py-20 px-6 text-center">
      <h2 class="text-3xl font-bold mb-6">Visualiza tu misión en tiempo real</h2>
      <p class="text-gray-600 max-w-2xl mx-auto mb-10">
        Desde la planificación hasta la ejecución, todo lo que necesitas está en un solo lugar.
      </p>
      <img src="https://undraw.co/api/illustrations/018cce90-282c-4ed4-8cbd-798f7bc116c3"
        class="w-full max-w-4xl mx-auto rounded-lg shadow" alt="App mockup" />
    </section>

    <!-- Testimonios -->
    <section class="py-20 px-6 bg-base-200 text-center">
      <h2 class="text-2xl font-bold mb-8">Testimonios</h2>
      <div class="max-w-4xl mx-auto grid md:grid-cols-2 gap-8">
        <div class="rounded-lg shadow p-6">
          <p class="italic mb-4">"DataStorm ha revolucionado la forma en que gestionamos nuestras operaciones. ¡Sencillo
            y potente!"</p>
          <div class="avatar">
            <div class="w-16 rounded-full">
              <img src="../assets/agente3.jpg" />
            </div>
          </div>
          <div class="font-bold">María López</div>
          <div class="text-sm text-gray-500">Coordinadora de Operaciones</div>
        </div>
        <div class="rounded-lg shadow p-6">
          <p class="italic mb-4">"La visualización en tiempo real y la gestión de equipos es justo lo que
            necesitábamos."</p>
          <div class="avatar">
            <div class="w-16 rounded-full">
              <img src="../assets/agente2.jpg" />
            </div>
          </div>
          <div class="font-bold">Carlos Pérez</div>
          <div class="text-sm text-gray-500">Jefe de Equipo</div>
        </div>
      </div>
    </section>
    <!-- CTA Section -->
    <section class="py-20 px-6 bg-base-200 text-center">
      <h2 class="text-3xl font-bold mb-4">Únete a la nueva forma de gestionar misiones</h2>
      <p class="text-gray-600 mb-6">DataStorm es gratis. Empieza en segundos.</p>
      <router-link to="/register" class="btn btn-primary btn-lg">Crear cuenta</router-link>
    </section>

    <!-- Footer -->
    <Footer />
  </div>
</template>


<style scoped>
.puff-in-center {
  -webkit-animation: puff-in-center 0.7s cubic-bezier(0.470, 0.000, 0.745, 0.715) both;
  animation: puff-in-center 0.7s cubic-bezier(0.470, 0.000, 0.745, 0.715) both;
}

@-webkit-keyframes puff-in-center {
  0% {
    -webkit-transform: scale(2);
    transform: scale(2);
    -webkit-filter: blur(4px);
    filter: blur(4px);
    opacity: 0;
  }

  100% {
    -webkit-transform: scale(1);
    transform: scale(1);
    -webkit-filter: blur(0px);
    filter: blur(0px);
    opacity: 1;
  }
}

@keyframes puff-in-center {
  0% {
    -webkit-transform: scale(2);
    transform: scale(2);
    -webkit-filter: blur(4px);
    filter: blur(4px);
    opacity: 0;
  }

  100% {
    -webkit-transform: scale(1);
    transform: scale(1);
    -webkit-filter: blur(0px);
    filter: blur(0px);
    opacity: 1;
  }
}
</style>
