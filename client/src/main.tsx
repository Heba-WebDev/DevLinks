import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Router from './routers/index.tsx'
import './index.css'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Router />
  </StrictMode>,
)
