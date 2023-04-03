// React
import { createRoot } from 'react-dom/client';

// Styles
import HorizonUI from './theme/theme';

// Redux Store
import { Provider } from 'react-redux';
import { store } from './store';

// Router
import Router from './routes/Router';

// ==============================|| REACT DOM RENDER  ||============================== //

const container = document.getElementById('root');
const root = createRoot(container!);

root.render(
  <HorizonUI>
    <Provider store={store}>
      <Router />
    </Provider>
  </HorizonUI>
);
