// Default Imports
import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';

// Router Creation and Routing
import { createBrowserRouter, Outlet, RouterProvider } from 'react-router-dom';
import Home from './pages/Home.jsx';
import Scoreboard from './pages/Scoreboard.jsx';
import Login from './pages/Auth/Login.jsx';

const router = createBrowserRouter([
    {
        path: '/',
        element: <ApplicationWrapper />,
        children: [
            {
                path: '/',
                element: <Home />,
            },
            {
                path: '/scoreboard',
                element: <Scoreboard />,
            },
            {
                path: '/login',
                element: <Login />,
            },
            {
                path: '/register',
                element: <Home />,
            },
            {
                path: '/404',
                element: <Home />,
            },
        ],
    },
]);

// User Context
import { UserProvider } from './contexts/UserContext.jsx';
import NiceModal from '@ebay/nice-modal-react';
import { QueryClientProvider, QueryClient } from '@tanstack/react-query';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <QueryClientProvider client={queryClient}>
            <UserProvider value={2}>
                <NiceModal.Provider>
                    <RouterProvider router={router} />
                </NiceModal.Provider>
            </UserProvider>
        </QueryClientProvider>
    </StrictMode>
);

/*
 * This allows for the navbar to be rendered on every page due to the Navbar component
 * which uses react-router-dom components/hooks
 */
// Wrapper import statements
import Footer from './components/Footer.jsx';
import Navbar from './components/Navbar.jsx';
function ApplicationWrapper() {
    return (
        <div className="">
            <Navbar />
            <Outlet />
            <Footer />
        </div>
    );
}
