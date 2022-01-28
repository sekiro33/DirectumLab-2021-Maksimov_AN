import * as React from 'react';
import Card from '../card/card';
import './card-deck.css';

interface ICard {
  value: number;
}

interface IProps {
  cards: ICard[];
}

const createCardDeck = (cards: ICard[]) => {
  return (
    cards.map((card) => {
      return <Card key={card.value} value={card.value} />
    })
  );
}

const CardDeck: React.FC<IProps> = (props) => {
  return (
    <ul className="list card-list">
      {createCardDeck(props.cards)}
    </ul>
  );
}

export default CardDeck;