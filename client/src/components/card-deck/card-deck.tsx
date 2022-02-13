import * as React from 'react';
import { ICard } from '../../store/types';
import Card from '../card/card';
import './card-deck.css';

interface IProps {
  selectCard: (cardId: string) => void;
  selectedCard: string | null;
  cards: ICard[];
}

const CardDeck: React.FC<IProps> = (props) => {
  const createCardDeck = (cards: ICard[]) => {
    return (
      cards.map((card) => {
        if (props.selectedCard != null && props.selectedCard == card.id)
          return <Card cardId={card.id} selectCard={props.selectCard} className={'selected'} key={card.value} value={card.value} />
        else
          return <Card cardId={card.id} selectCard={props.selectCard} key={card.value} value={card.value} />
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