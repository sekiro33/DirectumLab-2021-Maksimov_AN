import * as React from 'react';
import { IUser, UserId } from '../../store/types';
import Card from '../card/card';
import './card-deck.css';

interface ICard {
  value: number;
}

interface IProps {
  selectedCard: number | null;
  cards: ICard[];
}

const CardDeck: React.FC<IProps> = (props) => {
  const createCardDeck = (cards: ICard[]) => {
    return (
      cards.map((card) => {
        window.console.log(props.selectedCard);
        window.console.log(card.value);
        if (props.selectedCard && props.selectedCard == card.value)
          return <Card className={'selected'} key={card.value} value={card.value} />
        else
          return <Card key={card.value} value={card.value} />
      })
    );
  }

  return (
    <ul className="list card-list">
      {createCardDeck(props.cards)}
    </ul>
  );
}

export default CardDeck;