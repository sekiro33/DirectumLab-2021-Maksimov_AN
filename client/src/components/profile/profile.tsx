import * as React from 'react';
import avatar from '../../images/user_icon.svg';
import './profile.css';

interface IProps {
  name: string;
}

const Profile: React.FC<IProps> = (props) => {
  return <details className="profile">
    <summary className="profile__summary">
      {props.name}
      <img className="profile__icon" src={avatar} alt="avatar" />
    </summary>
    <div className="dropdown dropdown__corner">
      <div className="dropdown__menu">
        <a className="dropdown__content" href="#">Sign Out</a>
      </div>
    </div>
  </details>
};

export default Profile;