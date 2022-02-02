import * as React from 'react';
import icon from '../../images/logo.svg';
import './logo.css';

const Logo: React.FC = () => {
  return (
    <a className="logo" href="start-page.html">
      <img className="logo__icon" src={icon} alt="logo" />
      <h1 className="logo__text">Plan Poker</h1>
    </a>
  );
}

export default Logo;