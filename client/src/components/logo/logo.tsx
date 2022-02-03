import * as React from 'react';
import { Link } from 'react-router-dom';
import icon from '../../images/logo.svg';
import { RoutePath } from '../../routes';
import './logo.css';

const Logo: React.FC = () => {
  return (
    <Link className="logo" to={RoutePath.INDEX}>
      <img className="logo__icon" src={icon} alt="logo" />
      <h1 className="logo__text">Plan Poker</h1>
    </Link>
  );
}

export default Logo;