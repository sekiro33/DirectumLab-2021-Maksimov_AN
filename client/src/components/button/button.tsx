import * as React from 'react';
import './button.css';

interface IProps {
  title: string;
  className? : string;
  type? : "button" | "reset" | "submit";
  onClick?: () => void;
}

const Button: React.FC<IProps> = (props) => {
  const className = ['button', props.className];
  return <button onClick={props.onClick} className={className.join(' ')} type={props.type || "button"}>{props.title}</button>
};

export default Button;