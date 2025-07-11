<script setup>
defineProps({
    stats: Object
})
</script>

<template>
    <div class="flex gap-6 justify-center my-6">
        <div class="bg-base-200 rounded-lg p-4 text-center shadow min-w-[120px]">
            <div class="text-2xl font-bold text-primary">{{ stats.operaciones }}</div>
            <div class="text-xs text-gray-500">Operaciones</div>
        </div>
        <div class="bg-base-200 rounded-lg p-4 text-center shadow min-w-[120px]">
            <div class="text-2xl font-bold text-primary">{{ stats.equipos }}</div>
            <div class="text-xs text-gray-500">Equipos</div>
        </div>
        <div class="bg-base-200 rounded-lg p-4 text-center shadow min-w-[120px]">
            <div class="text-2xl font-bold text-primary">{{ stats.agentes }}</div>
            <div class="text-xs text-gray-500">Agentes</div>
        </div>
    </div>
</template>