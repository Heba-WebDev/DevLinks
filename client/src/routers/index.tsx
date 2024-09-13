import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from '../App';
import Register from '@/modules/auth/signup/page';
import Login from '@/modules/auth/signin/page';
import Profile from '@/modules/profile/page';
import Links from '@/modules/links/page';
import ForgotPassword from '@/modules/auth/forgot-password/page';
import ResetPassword from '@/modules/auth/reset-password/page';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/signup",
    element: <Register />
  },
  {
    path: "/login",
    element: <Login />
  },
  {
    path: "/forgot-password",
    element: <ForgotPassword />
  },
  {
    path: "/reset-password",
    element: <ResetPassword />
  },
  {
    path: "/profile",
    element: <Profile />
  },
  {
    path: "/links",
    element: <Links />
  }
]);

export default function Router() {
    return <RouterProvider router={router} fallbackElement={<p>Loading...</p>} />
}
