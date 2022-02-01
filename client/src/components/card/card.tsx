import * as React from 'react';
import cafe from '../../images/cafe.svg';
import './card.css';

interface IProsp {
  value: number;
}

const Card: React.FC<IProsp> = (props) => {
  const getCardValue = (value:number) => {
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
      <button className="card-list__button">{getCardValue(props.value)}</button>
    </li>
  );
}

export default Card;