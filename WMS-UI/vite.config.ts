import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        react(),
    ],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'),
        },
    },
    build: {
        // Output directly to the HRMS backend wwwroot folder
        outDir: path.resolve(__dirname, '../WMS/HRMS/wwwroot'),
        emptyOutDir: true,
    },
    server: {
        // Proxy API calls to the backend during development
        proxy: {
            '/api': {
                target: 'https://localhost:5001',
                changeOrigin: true,
                secure: false,
            },
        },
    },
});

