import * as React from 'react';
import { Link } from 'react-router-dom';
import avatar from '../../images/user_icon.svg';
import { RoutePath } from '../../routes';
import './profile.css';

interface IProps {
  name: string;
  logout: () => void;
}

const ProfileView: React.FC<IProps> = (props) => {
  return <details className="profile">
    <summary className="profile__summary">
      {props.name}
      <img className="profile__icon" src={avatar} alt="avatar" />
    </summary>
    <div className="dropdown dropdown__corner">
      <div className="dropdown__menu">
        <Link to={RoutePath.INDEX} onClick={props.logout} >
          <button className="dropdown__content">Sign Out</button>
        </Link>
      </div>
    </div>
  </details>
};

export default ProfileView;