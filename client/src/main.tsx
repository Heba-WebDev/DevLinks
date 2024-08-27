import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Router from './routers/index.tsx'
import { Provider } from 'react-redux'
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import './index.css'
import { store } from './store/index.ts'
import ReactQueryProvider from './util/react-query.provider.tsx';

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <Provider store={store}>
      <ReactQueryProvider>
        <Router />
        <ToastContainer />
      </ReactQueryProvider>
    </Provider>
  </StrictMode>
);
