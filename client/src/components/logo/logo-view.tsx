import * as React from 'react';
import { Link } from 'react-router-dom';
import icon from '../../images/logo.svg';
import { RoutePath } from '../../routes';
import './logo.css';

interface IProps {
  clearStore: () => void;
}

const LogoView: React.FC<IProps> = (props) => {
  return (
    <Link className="logo" to={RoutePath.INDEX} onClick={props.clearStore} >
      <img className="logo__icon" src={icon} alt="logo" />
      <h1 className="logo__text">Plan Poker</h1>
    </Link>
  );
}

export default LogoView;