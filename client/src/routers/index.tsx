import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from '../App';
import Register from '@/modules/auth/signup/page';
import Login from '@/modules/auth/signin/page';
import Profile from '@/modules/profile/page';
import Links from '@/modules/links/page';

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
