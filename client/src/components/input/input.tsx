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

//eslint-disable-next-line react/display-name
const Input = React.forwardRef(
  (props: IProps, ref: React.ForwardedRef<HTMLInputElement>) => {
  return (
    <label className={props.labelClassName}>{props.label}
      <input ref={ref} className={props.inputClassName} type="text" name={props.name} placeholder={props.placeholder} required={props.required} value={props.value} readOnly={props.readonly} />
    </label>
  );
});

export default Input;