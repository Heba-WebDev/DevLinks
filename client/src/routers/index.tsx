import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from '../App';
import Register from '@/auth/signup/page';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/signup",
    element: <Register />
  }
]);

export default function Router() {
    return <RouterProvider router={router} fallbackElement={<p>Loading...</p>} />
}
