/**
 * API Client — equivalent to Angular's HttpInterceptor.
 * 
 * Features:
 * 1. Auto-attaches JWT token (Authorization: Bearer) to every request
 * 2. Handles 401 responses globally — clears token and redirects to login
 * 3. Provides convenient get/post/put/delete methods
 * 4. Centralizes API base URL configuration
 */

// In dev mode, Vite proxy handles /api → backend (see vite.config.ts)
// In production, the app is served from the same origin as the API
const API_BASE_URL = '';

/**
 * Core request function with interceptor logic
 */
async function request<T>(endpoint: string, options: RequestInit = {}): Promise<T> {
    const token = localStorage.getItem('token');

    // --- REQUEST INTERCEPTOR ---
    // Auto-attach Authorization header if token exists
    const headers: HeadersInit = {
        'Content-Type': 'application/json',
        ...options.headers,
    };

    if (token) {
        (headers as Record<string, string>)['Authorization'] = `Bearer ${token}`;
    }

    const config: RequestInit = {
        ...options,
        headers,
    };

    const response = await fetch(`${API_BASE_URL}${endpoint}`, config);

    // --- RESPONSE INTERCEPTOR ---
    // Handle 401 Unauthorized globally
    if (response.status === 401) {
        localStorage.removeItem('token');
        // Redirect to login page
        window.location.href = '/';
        throw new Error('Session expired. Please login again.');
    }

    // Parse response
    const data = await response.json();

    if (!response.ok) {
        throw { status: response.status, data };
    }

    return data as T;
}

/**
 * API Client with convenient HTTP methods
 */
const apiClient = {
    get<T>(endpoint: string): Promise<T> {
        return request<T>(endpoint, { method: 'GET' });
    },

    post<T>(endpoint: string, body: unknown): Promise<T> {
        return request<T>(endpoint, {
            method: 'POST',
            body: JSON.stringify(body),
        });
    },

    put<T>(endpoint: string, body: unknown): Promise<T> {
        return request<T>(endpoint, {
            method: 'PUT',
            body: JSON.stringify(body),
        });
    },

    delete<T>(endpoint: string): Promise<T> {
        return request<T>(endpoint, { method: 'DELETE' });
    },
};

export default apiClient;
