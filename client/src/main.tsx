import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Router from './routers/index.tsx'
import { Provider } from 'react-redux'
import './index.css'
import { store } from './store/index.ts'

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <Provider store={store}>
      <Router />
    </Provider>
  </StrictMode>
);
