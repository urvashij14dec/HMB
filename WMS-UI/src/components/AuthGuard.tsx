import { Navigate } from 'react-router-dom';
import { PropsWithChildren } from 'react';

/**
 * AuthGuard — equivalent to Angular's canActivate route guard.
 * Checks if a JWT token exists in localStorage.
 * If authenticated → renders the child component.
 * If not authenticated → redirects to the login page (/).
 */
const AuthGuard = ({ children }: PropsWithChildren) => {
    const token = localStorage.getItem('token');

    if (!token) {
        // Not authenticated — redirect to login
        return <Navigate to="/" replace />;
    }

    // Authenticated — render the protected page
    return <>{children}</>;
};

export default AuthGuard;
