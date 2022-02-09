import * as React from 'react';
import avatar from '../../images/user_icon.svg';
import { ICard, IUser, UserId } from '../../store/types';
import './modal.css';

export interface IVote {
  name: string;
  value: number;
}

interface IProps {
  users: IUser[];
  votes: Record<UserId, ICard>;
  onClose(): void;
}

const Modal: React.FC<IProps> = (props) => {
  const getUserName = (userId: UserId) => {
    return props.users.find((user) => user.id == userId);
  }

  const getUserList = (votes: Record<UserId, ICard>) => {
    const gradeList = [];
    for (const key in votes) {
      const user = getUserName(key);
      gradeList.push(
        (
          <li key={key} className="modal__item">
            <div className="modal__user-info">
              <img className="modal__item__icon" src={avatar} alt="avatar" />
              <p className="modal__item__text">{user && user.name || 'Unknown'}</p>
            </div>
            <span className="modal__item__grade">{votes[key].value}</span>
          </li>
        )
      );
    }
    return gradeList;
  }

  return (
    <div className="modal">
      <div className="modal__dialog">
        <header className="modal__header">
          <p className="modal__header__title">Story Details</p>
        </header>
        <p className="modal__title">Players:</p>
        <ul className="list modal__list">
          {getUserList(props.votes)}
        </ul>
        <div className="modal_button-container">
          <button className="button modal__button" onClick={props.onClose}>Close</button>
        </div>
      </div>
    </div>
  );
}

export default Modal;