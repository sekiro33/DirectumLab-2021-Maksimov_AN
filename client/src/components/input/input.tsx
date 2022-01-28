import * as React from 'react';
import './input.css';

interface IProps {
  label?: string;
  labelClassName? : string;
  inputClassName? : string;
  name?: string;
  placeholder?: string;
  required?: boolean;
  value?: string;
  readonly?: boolean;
}

const Input: React.FC<IProps> = (props) => {
  return (
    <label className={props.labelClassName}>{props.label}
      <input className={props.inputClassName} type="text" name={props.name} placeholder={props.placeholder} required={props.required} value={props.value} readOnly={props.readonly} />
    </label>
  )
}

export default Input;