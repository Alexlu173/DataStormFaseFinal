<script setup>
defineProps({ agente: Object })
</script>

<template>
  <tr>
    <td>{{ agente.nombre }}</td>
    <td>{{ agente.apellidos }}</td>
    <td>{{ agente.email }}</td>
    <td>{{ agente.rango }}</td>
    <td>
      <span :class="agente.activo ? 'text-green-600' : 'text-red-500'">
        {{ agente.activo ? 'Sí' : 'No' }}
      </span>
    </td>
    <td>
      <button class="btn btn-sm btn-outline btn-info">Ver</button>
      <button class="btn btn-sm btn-outline btn-error ml-2">Eliminar</button>
    </td>
  </tr>
</template>
