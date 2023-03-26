import { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Router from '@src/routes/Router';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <StrictMode>
    <Router />
  </StrictMode>
);