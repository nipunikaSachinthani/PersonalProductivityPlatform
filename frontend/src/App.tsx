import { Routes, Route } from 'react-router-dom';
import { ROUTES } from './routes';
import LandingPage from './pages/LandingPage';

function App() {
  return (
    <Routes>
      <Route path={ROUTES.HOME} element={<LandingPage />} />
    </Routes>
  );
}

export default App;
