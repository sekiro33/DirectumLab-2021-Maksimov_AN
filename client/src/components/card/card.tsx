import * as React from 'react';
import { MouseEvent } from 'react';
import cafe from '../../images/cafe.svg';
import './card.css';

interface IProps {
  className? : string;
  value: number;
  onClick: (value: string) => void;
}

const Card: React.FC<IProps> = (props) => {
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
      <button onClick={(evt: MouseEvent<HTMLButtonElement>) => props.onClick(evt.currentTarget.outerText)} className={className.join(' ')}>{getCardValue(props.value)}</button>
    </li>
  );
}

export default Card;