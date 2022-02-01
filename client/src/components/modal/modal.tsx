import * as React from 'react';
import avatar from '../../images/user_icon.svg';
import './modal.css';

export interface IVote {
  name: string;
  value: number;
}

interface IProps {
  votes: IVote[];
  onClose(): void;
}

const Modal: React.FC<IProps> = (props) => {
  const getUserList = (votes: IVote[]) => {
    return (
      votes.map((vote) => {
        return (
          <li key={vote.name} className="modal__item">
            <div className="modal__user-info">
              <img className="modal__item__icon" src={avatar} alt="avatar" />
              <p className="modal__item__text">{vote.name}</p>
            </div>
            <span className="modal__item__grade">{vote.value}</span>
          </li>
        );
      })
    );
  }
  
  return (
    <div className="modal">
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
  );
}

export default Modal;