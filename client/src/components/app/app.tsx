import * as React from 'react';
import PlaningPage from '../planing-page/planing-page';
import './app.css';

function App() {
  return (
    <PlaningPage userName='test' isOwner={true} />
  );
}
export default App;
