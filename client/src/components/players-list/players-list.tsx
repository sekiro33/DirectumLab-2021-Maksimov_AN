import * as React from 'react';
import avatar from '../../images/user_icon.svg';
import check from '../../images/check_circle.svg';
import { ICard, IUser, UserId } from '../../store/types';
import './players-list.css';

interface IProps {
  users: IUser[];
  roomState: boolean;
  votes: Record<UserId, ICard> | null;
}

const PlayersList: React.FC<IProps> = (props) => {
  
  const getStatus = (isVoted: boolean, user: IUser, votes: Record<UserId, ICard> | null) => {
    if (votes == null) {
      return null;
    }
    if (votes[user.id]) {
      if (isVoted) {
        return votes[user.id].value;
      } else {
        return (<img src={check} alt="voted"></img>)
      }
    }
  }

const createList = (users: IUser[]) => {
  return users.map((user) => {
    return (
      <li key={user.name} className="list__item players-list__item">
        <div className="players__info">
          <img className="players-list__avatar" src={avatar} alt="avatar" />
          <p className="players-list__text">{user.name}</p>
        </div>
        <div className="players-list__status">
          {getStatus(props.roomState, user, props.votes)}
        </div>
      </li>
    );
  });
}

return (
  <ul className="list players__list">
    {createList(props.users)}
  </ul>
);
}

export default PlayersList;