import * as React from 'react';
import './button.css';

interface IProps {
  title: string;
  className? : string;
}

const Button: React.FC<IProps> = (props) => {
  const className = ['button', props.className];
  return <button className={className.join(' ')} type="submit">{props.title}</button>
};

export default Button;