// stores/useOperacionStore.js
import { defineStore } from 'pinia'

export const useOperacionStore = defineStore('operaciones', {
    state: () => ({
        operaciones: [],
        loading: false
    }),

    actions: {
        async fetchOperaciones() {
            try {
                this.loading = true
                const res = await fetch('http://localhost:5190/api/operaciones')
                if (!res.ok) throw new Error('Error al obtener operaciones')
                const data = await res.json()
                this.operaciones = data
            } catch (err) {
                console.error('[fetchOperaciones]', err)
            } finally {
                this.loading = false
            }
        },

        async crearOperacion(operacion) {
            try {
                const res = await fetch('http://localhost:5190/api/operaciones', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(operacion)
                })
                if (!res.ok) throw new Error('Error al crear operación')
                await this.fetchOperaciones()
            } catch (err) {
                console.error('[crearOperacion]', err)
            }
        },

        async eliminarOperacion(id) {
            try {
                const res = await fetch(`http://localhost:5190/api/operaciones/${id}`, {
                    method: 'DELETE'
                })
                if (!res.ok) throw new Error('Error al eliminar operación')
                this.operaciones = this.operaciones.filter(op => op.id !== id)
            } catch (err) {
                console.error('[eliminarOperacion]', err)
            }
        }
    }
})
