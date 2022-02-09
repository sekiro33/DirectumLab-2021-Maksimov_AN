import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { RouteComponentProps } from 'react-router-dom';
import { RoutePath } from '../../routes';
import Header from '../header/header';
import Footer from '../footer/footer';
import Button from '../button/button';
import Input from '../input/input';
import './invite-page.css';


interface IMatchParams {
  roomId: string;
}

const InvitePage: React.FC<RouteComponentProps<IMatchParams>> = (props) => {
  const handleClick = () => {
    props.history.push(`${RoutePath.ROOM}/${props.match.params.roomId}`);
  }

  return <div className='page'>
    <Header />
    <main className="main">
      <div className="containter main__content">
        <form className="form">
          <p className="form__text">Let&apos;s Start!</p>
          <h2 className="form__title">Join the room:</h2>
          <Input label='User name' labelClassName='form__label' inputClassName='form__input' name='userName' placeholder='Enter your name' required={true} /> 
          <Button onClick={handleClick} type="submit" className='form__button' title='Enter' />
        </form>
      </div>
    </main>
    <Footer />
  </div>
};

export default withRouter(InvitePage);