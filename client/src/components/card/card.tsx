import * as React from 'react';
import { MouseEvent } from 'react';
import { connect } from 'react-redux';
import { Dispatch } from 'redux';
import { vote } from '../../api/api';
import cafe from '../../images/cafe.svg';
import { updateRoom } from '../../store/room/room-action-creators';
import { roomSelector } from '../../store/room/room-selector';
import { IRoom, IRootState, IUser } from '../../store/types';
import { userSelector } from '../../store/user/user-selector';
import './card.css';

interface IProps {
  className? : string;
  user: IUser | null;
  room: IRoom | null;
  updateRoom: (room: IRoom) => void;
  value: number;
}

const Card: React.FC<IProps> = (props) => {
  const handleClick = (evt: MouseEvent<HTMLButtonElement>) => {
    const buttonText = evt.currentTarget.outerText;
    let value;
    if (buttonText === '?')
      value = -10;
    else if (buttonText == '')
      value = -100;
    else
      value = Number.parseInt(buttonText);
    if (props.user != null && props.room) {
      const response = vote(props.user, props.room, value);
      if (response != null) {
        props.updateRoom(response);
        window.console.log(response);
      }
    }
  }


  const getCardValue = (value: number) => {
    switch (value) {
      case -10:
        return '?'

      case -100:
        return (<img className='card-cafe' src={cafe} />);

      default:
        return value;
    }
  }

  const className = ['card-list__button', props.className];

  return (
    <li className="card-list__item">
      <button onClick={handleClick} className={className.join(' ')}>{getCardValue(props.value)}</button>
    </li>
  );
}

const mapStateToProps = (state: IRootState) => {
  return {
    user: userSelector(state),
    room: roomSelector(state),
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateRoom: (room: IRoom) => {
      dispatch(updateRoom(room));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Card);