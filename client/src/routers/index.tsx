import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from '../App';
import Register from '@/modules/auth/signup/page';
import Login from '@/modules/auth/signin/page';
import Profile from '@/modules/profile/page';

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
  }
]);

export default function Router() {
    return <RouterProvider router={router} fallbackElement={<p>Loading...</p>} />
}
