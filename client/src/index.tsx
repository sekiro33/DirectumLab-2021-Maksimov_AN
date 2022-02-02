import React from 'react';
import { Router } from 'react-router-dom';
import { history } from './history';
import ReactDOM from 'react-dom';
import App from './components/app/app';

ReactDOM.render(
  <React.StrictMode>
    <Router history={history}>
      <App />
    </Router>
  </React.StrictMode>,
  document.getElementById(`root`)
);
