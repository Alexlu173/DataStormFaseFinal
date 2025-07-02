<script setup>
import Footer from '@/components/Footer.vue'; 
</script>

<template>
  <div class="min-h-screen bg-base-100 flex flex-col">
    <!-- Hero -->
    <section class="flex-1 flex flex-col items-center justify-center text-center px-6 py-16">
      <h1 class="text-5xl md:text-6xl font-extrabold text-primary mb-6">DataStorm</h1>
      <p class="text-lg md:text-xl text-gray-500 max-w-2xl mb-10">
        Plataforma para la gestión táctica de operaciones especiales, agentes y equipos. Coordina y controla tus
        recursos con precisión y eficiencia.
      </p>
    </section>

    <!-- Características -->
    <section class="bg-base-200 py-12">
      <div class="max-w-5xl mx-auto px-4 grid gap-8 md:grid-cols-3 text-center">
        <div>
          <div class="text-4xl mb-2">📋</div>
          <h3 class="text-xl font-bold mb-1">Gestión de Operaciones</h3>
          <p class="text-gray-500 text-sm">Crea, planifica y controla cada misión desde una sola vista.</p>
        </div>
        <div>
          <div class="text-4xl mb-2">🧑‍🤝‍🧑</div>
          <h3 class="text-xl font-bold mb-1">Equipos y Agentes</h3>
          <p class="text-gray-500 text-sm">Asigna roles, gestiona equipos y visualiza la actividad de cada miembro.</p>
        </div>
        <div>
          <div class="text-4xl mb-2">📈</div>
          <h3 class="text-xl font-bold mb-1">Análisis de Datos</h3>
          <p class="text-gray-500 text-sm">Obtén información clave para tomar decisiones tácticas.</p>
        </div>
      </div>
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
