import * as React from 'react';
import cafe from '../../images/cafe.svg';
import './card.css';

<<<<<<< Updated upstream
interface IProsp {
  value: number;
}

const Card: React.FC<IProsp> = (props) => {
  const getCardValue = (value:number) => {
=======
interface IProps {
  cardId: string;
  className? : string;
  value: number;
  selectCard: (cardId: string) => void;
}

const Card: React.FC<IProps> = (props) => {
  const handleClick = () => {
    props.selectCard(props.cardId);
  }

  const getCardValue = (value: number) => {
>>>>>>> Stashed changes
    switch (value) {
      case -10:
        return '?'
    
      case -100:
        return (<img className='card-cafe' src={cafe} />);
      
      default:
        return value;
    }
  }
  
  return (
    <li className="card-list__item">
<<<<<<< Updated upstream
      <button className="card-list__button">{getCardValue(props.value)}</button>
=======
      <button onClick={handleClick} className={className.join(' ')}>{getCardValue(props.value)}</button>
>>>>>>> Stashed changes
    </li>
  )
}

export default Card;