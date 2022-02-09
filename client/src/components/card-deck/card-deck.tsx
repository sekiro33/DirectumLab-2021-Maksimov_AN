import * as React from 'react';
import { connect } from 'react-redux';
import { Dispatch } from 'redux';
import { vote } from '../../api/api';
import { updateRoom } from '../../store/room/room-action-creators';
import { roomSelector } from '../../store/room/room-selector';
import { IUser, ICard, IRoom, IRootState } from '../../store/types';
import { userSelector } from '../../store/user/user-selector';
import Card from '../card/card';
import './card-deck.css';

interface IProps {
  selectedCard: number | null;
  cards: ICard[];
  updateRoom: (room: IRoom) => void;
  user: IUser | null;
  room: IRoom | null;
}

const CardDeck: React.FC<IProps> = (props) => {
  const handleCardClick = (value: string) => {
    let numberValue: number;

    if (value === '?')
      numberValue = -10;
    else if (value == '')
      numberValue = -100;
    else
      numberValue = Number.parseFloat(value);

    if (props.user != null && props.room) {
      const response = vote(props.user, props.room, numberValue);
      if (response != null) {
        props.updateRoom(response);
        window.console.log(response);
      }
    }
  }

  const createCardDeck = (cards: ICard[]) => {
    return (
      cards.map((card) => {
        if (props.selectedCard != null && props.selectedCard == card.value)
          return <Card onClick={handleCardClick} className={'selected'} key={card.value} value={card.value} />
        else
          return <Card onClick={handleCardClick} key={card.value} value={card.value} />
      })
    );
  }

  return (
    <ul className="list card-list">
      {createCardDeck(props.cards)}
    </ul>
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

export default connect(mapStateToProps, mapDispatchToProps)(CardDeck);