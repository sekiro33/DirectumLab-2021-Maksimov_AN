import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { RouteComponentProps } from 'react-router-dom';
import { RoutePath } from '../../routes';
import Header from '../header/header';
import Footer from '../footer/footer';
import Button from '../button/button';
import Input from '../input/input';
import './create-page.css';

const CreatePage: React.FC<RouteComponentProps> = (props) => {
  const handleClick = () => {
    const roomId = Math.round(Math.random() * (100 - 1) + 1);
    props.history.push(`${RoutePath.ROOM}/${roomId}`);
  }

  return <div className={'page'}>
    <Header user={null} />
    <main className="main">
      <div className="containter main__content">
        <div className="column-container">
          <form className="form">
            <p className="form__text">Let&apos;s Start!</p>
            <h2 className="form__title">Create the room:</h2>
            <Input label='User name' labelClassName='form__label' inputClassName='form__input' name='userName' placeholder='Enter your name' required={true} />
            <Input label='Room name' labelClassName='form__label' inputClassName='form__input' name='roomName' placeholder='Enter room name' required={true} />
            <Button onClick={handleClick} className={'form__button'} type="submit" title={'Enter'} />
          </form>
        </div>
      </div>
    </main>
    <Footer />
  </div>
};

export default withRouter(CreatePage);