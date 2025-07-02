// src/stores/useOperacionStore.js
import { defineStore } from 'pinia'

export const useOperacionStore = defineStore('operaciones', {
    state: () => ({
        operaciones: [],
        loading: false,
        error: null
    }),
    actions: {
        async fetchOperaciones() {
            this.loading = true
            this.error = null
            try {
                const res = await fetch('http://localhost:5190/api/operaciones')
                if (!res.ok) throw new Error(`Error: ${res.status}`)
                this.operaciones = await res.json()
            } catch (err) {
                this.error = err.message
                console.error(err)
            } finally {
                this.loading = false
            }
        }
    }
})
