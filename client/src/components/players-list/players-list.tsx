import * as React from 'react';
import avatar from '../../images/user_icon.svg';
import check from '../../images/check_circle.svg';
import cafe from '../../images/cafe.svg';
import { IUser } from '../../store/types';
import './players-list.css';

interface IProps {
  users: IUser[];
  isVoted: boolean;
  grades: Record<string, number> | null;
}

const PlayersList: React.FC<IProps> = (props) => {
  const getGrade = (value: number) => {
    switch (value) {
      case -10: return '?';
      case -100: return (<img className='cafe-icon' src={cafe} />);
      default: return value;
    }
  }

  const getStatus = (grades: Record<string, number>, user: IUser) => {
    if (props.isVoted == false && grades[user.id] != null) {
      return <img src={check} alt="voted"></img>;
    } else if (props.isVoted == true && grades[user.id]) {
      return getGrade(grades[user.id]);
    } else {
      return null;
    }
  }

  const createList = (users: IUser[], grades: Record<string, number> | null) => {
    return users.map((user) => {
      return (
        <li key={user.name} className="list__item players-list__item">
          <div className="players__info">
            <img className="players-list__avatar" src={avatar} alt="avatar" />
            <p className="players-list__text">{user.name}</p>
          </div>
          <div className="players-list__status">
            {grades && getStatus(grades, user)}
          </div>
        </li>
      );
    });
  }

  return (
    <ul className="list players__list">
      {createList(props.users, props.grades)}
    </ul>
  );
}

export default PlayersList;