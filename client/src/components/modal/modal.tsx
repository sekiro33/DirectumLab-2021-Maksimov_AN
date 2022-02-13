import * as React from 'react';
import avatar from '../../images/user_icon.svg';
<<<<<<< Updated upstream
=======
import cafe from '../../images/cafe.svg';
import { IUser } from '../../store/types';
>>>>>>> Stashed changes
import './modal.css';

interface IModalDiscussion {
  name: string,
  grades: Record<string, number>,
}

interface IProps {
<<<<<<< Updated upstream
  votes: IVote[];
=======
  users: IUser[];
>>>>>>> Stashed changes
  onClose(): void;
  discussion: IModalDiscussion | null,
}

const Modal: React.FC<IProps> = (props) => {
<<<<<<< Updated upstream
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
=======
  const getUserName = (userId: string) => {
    const user = props.users.find((user) => user.id == userId);
    if (user) {
      return user.name;
    }
    return 'Unknown';
  }

  const getGrade = (grade: number) => {
    switch (grade) {
      case -10:
        return '?';
      case -100:
        return (<img src={cafe} className="modal__item__grade-icon" />);
      default:
        return grade;
    }
  }

  const getUserList = (grades: Record<string, number>) => {
    const gradeList = [];

    for (const key in grades) {
      const userName = getUserName(key);
      gradeList.push(
        (
          <li key={key} className="modal__item">
            <div className="modal__user-info">
              <img className="modal__item__icon" src={avatar} alt="avatar" />
              <p className="modal__item__text">{userName}</p>
            </div>
            <span className="modal__item__grade">{getGrade(grades[key])}</span>
          </li>
        )
      );
    }
    window.console.log(gradeList);
    return gradeList;
>>>>>>> Stashed changes
  }
  
  return (
<<<<<<< Updated upstream
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
=======
    <div className='modal'>
      <div className="modal__dialog">
        <header className="modal__header">
          <p className="modal__header__title">Story Details</p>
        </header>
        <p className="modal__title">Players:</p>
        <ul className="list modal__list">
          {props.discussion && props.discussion.grades && getUserList(props.discussion.grades)}
        </ul>
        <div className="modal_button-container">
          <button className="button modal__button" onClick={props.onClose}>Close</button>
        </div>
>>>>>>> Stashed changes
      </div>
    </div>
  )
}

export default Modal;