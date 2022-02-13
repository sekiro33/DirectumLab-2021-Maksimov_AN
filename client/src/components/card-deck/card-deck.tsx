import * as React from 'react';
<<<<<<< Updated upstream
=======
import { ICard } from '../../store/types';
>>>>>>> Stashed changes
import Card from '../card/card';
import './card-deck.css';

interface ICard {
  value: number;
}

interface IProps {
<<<<<<< Updated upstream
=======
  selectCard: (cardId: string) => void;
  selectedCard: string | null;
>>>>>>> Stashed changes
  cards: ICard[];
}

const CardDeck: React.FC<IProps> = (props) => {
  const createCardDeck = (cards: ICard[]) => {
    return (
      cards.map((card) => {
<<<<<<< Updated upstream
        return <Card key={card.value} value={card.value} />
=======
        if (props.selectedCard != null && props.selectedCard == card.id)
          return <Card cardId={card.id} selectCard={props.selectCard} className={'selected'} key={card.value} value={card.value} />
        else
          return <Card cardId={card.id} selectCard={props.selectCard} key={card.value} value={card.value} />
>>>>>>> Stashed changes
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