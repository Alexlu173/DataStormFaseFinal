import { defineStore } from 'pinia'

export const useEquiposStore = defineStore('equipos', {
    state: () => ({
        equipos: [],
        loading: false,
        error: null,
    }),
    actions: {
        async fetchEquipos() {
            this.loading = true
            this.error = null
            try {
                const response = await fetch('http://localhost:5190/api/equipos')
                if (!response.ok) throw new Error('Error al obtener equipos')
                const data = await response.json()
                this.equipos = data
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
        async crearEquipo(equipo) {
            this.loading = true
            this.error = null
            try {
                const response = await fetch('http://localhost:5190/api/equipos', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(equipo)
                })
                if (!response.ok) throw new Error('Error al crear equipo')
                await this.fetchEquipos()
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
        async editarEquipo(id, equipo) {
            this.loading = true
            this.error = null
            try {
                const response = await fetch(`http://localhost:5190/api/equipos/${id}`, {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(equipo)
                })
                if (!response.ok) throw new Error('Error al editar equipo')
                await this.fetchEquipos()
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
        async eliminarEquipo(id) {
            this.loading = true
            this.error = null
            try {
                const response = await fetch(`http://localhost:5190/api/equipos/${id}`, {
                    method: 'DELETE'
                })
                if (!response.ok) throw new Error('Error al eliminar equipo')
                this.equipos = this.equipos.filter(e => e.id !== id)
            } catch (err) {
                this.error = err.message || 'Error desconocido'
            } finally {
                this.loading = false
            }
        },
        getEquipoById(id) {
            return this.equipos.find(e => e.id === id)
        },
    },
})