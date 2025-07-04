import { defineStore } from 'pinia';

export const useAgentesStore = defineStore = ('agentes', {
    state: () => ({
        agentes: [],
        loading: false,
        error: null,
    }),
    actions: {
        async fetchAgentes() {
            this.loading = true
            this.error = null
            try {
                const response = await fetch('http://localhost:5190/api/agentes')
                if (!response.ok) throw new Error('Error al obtener los agentes')
                const data = await response.json()
                this.agentes = data
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
        async crearAgente(agente) {
            this.loading = true
            this.error = null
            try {
                const response = await fetch('http://localhost:5190/api/agentes', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(agente)
                })
                if (!response.ok) throw new Error('Error al crear agente')
                await this.fetchAgentes()
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
        async eliminarAgente(id) {
            this.loading = true
            this.error = null
            try {
                const response = await fetch(`http://localhost:5190/api/agentes/${id}`, {
                    method: 'DELETE'
                })
                if (!response.ok) throw new Error('Error al eliminar agente')
                this.equipos = this.agentes.filter(a => a.id !== id)
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
    }
})