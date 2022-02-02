import * as React from 'react';
import Logo from '../logo/logo';
import Profile from '../profile/profile';
import './header.css';

interface IUser {
  name: string;
}

interface IProps {
  user: IUser | null;
}

const Header: React.FC<IProps> = (props) => {
  return (
    <header className="header">
      <div className="container header__content">
        <Logo />
        {props.user != null && <Profile name={props.user.name} />}
      </div>
    </header>
  );
}

export default Header;