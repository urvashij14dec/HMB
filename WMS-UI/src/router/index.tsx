import { createBrowserRouter } from 'react-router-dom';
import BlankLayout from '../components/Layouts/BlankLayout';
import DefaultLayout from '../components/Layouts/DefaultLayout';
import AuthGuard from '../components/AuthGuard';
import { routes } from './routes';

const finalRoutes = routes.map((route) => {
    if (route.layout === 'blank') {
        // Public routes (login, register, error pages) — no auth guard
        return {
            ...route,
            element: <BlankLayout>{route.element}</BlankLayout>,
        };
    }

    // Protected routes — wrapped with AuthGuard
    return {
        ...route,
        element: (
            <AuthGuard>
                <DefaultLayout>{route.element}</DefaultLayout>
            </AuthGuard>
        ),
    };
});

const router = createBrowserRouter(finalRoutes);

export default router;

