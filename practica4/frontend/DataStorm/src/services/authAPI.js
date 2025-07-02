const API_URL = 'http://localhost:5190/api/auth';

export async function login({ nombreUsuario, password }) {
    const res = await fetch(`${API_URL}/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nombreUsuario, password })
    });

    if (!res.ok) throw new Error('Credenciales incorrectas');
    return await res.json();
}

export async function register(data) {
    const res = await fetch(`${API_URL}/register`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    })

    if (!res.ok) throw new Error('Error al registrar')
    return await res.text()
}