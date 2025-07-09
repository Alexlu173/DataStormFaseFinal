import { defineStore } from 'pinia';
export const authStore = defineStore('auth', {
    state: () => ({
        user: null,
        token: localStorage.getItem('token') || null,
        loading: false,
        error: null,
    }),
    actions: {
        async login(credentials) {
            this.loading = true;
            this.error = null;
            try {
                const response = await fetch('http://localhost:5190/api/auth/login', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(credentials)
                });
                if (!response.ok) throw new Error('Error al iniciar sesión');
                const data = await response.json();
                this.token = data.token;
                localStorage.setItem('token', data.token)
                await this.fetchCurrentUser()
            } catch (err) {
                this.error = err.message || 'Error desconocido';
            } finally {
                this.loading = false;
            }
        },
        async register(userData) {
            this.loading = true;
            this.error = null;
            try {
                const response = await fetch('http://localhost:5190/api/auth/register', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(userData)
                });
                if (!response.ok) throw new Error('Error al registrarse');
                const data = await response.json();
                this.token = data.token;
                localStorage.setItem('token', data.token)
                await this.fetchCurrentUser()
            } catch (err) {
                this.error = err.message || 'Error desconocido';
            } finally {
                this.loading = false;
            }
        },
        async fetchCurrentUser() {
            const res = await fetch('http://localhost:5190/api/Auth/me', {
                headers: {
                    'Authorization': `Bearer ${this.token}`,
                },
            })

            if (!res.ok) throw new Error('No se pudo obtener el usuario')
            this.user = await res.json()
        },
        logout() {
            this.user = null;
            this.token = null;
            localStorage.removeItem('token');
        }
    },
    getters:{
        isAuthenticated: (state) => !!state.token,
    }
})