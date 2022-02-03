import * as React from 'react';
import { Link } from 'react-router-dom';
import { RoutePath } from '../../routes';
import './footer.css';

const Footer: React.FC = () => {
  return <footer className="footer">
    <p>Copyright 2021 <Link to={RoutePath.INDEX}>Plan Poker</Link></p>
  </footer>
};

export default Footer;