import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { RoutePath } from '../../routes';
import Header from '../header/header';
import Footer from '../footer/footer';
import Button from '../button/button';
import Input from '../input/input';
import './create-page.css';

interface IProps extends RouteComponentProps {
  createRoom: (userName: string, roomName: string) => Promise<string>;
}

const CreatePageView: React.FC<IProps> = (props) => {
  const userNameRef: React.RefObject<HTMLInputElement> = React.createRef();
  const roomNameRef: React.RefObject<HTMLInputElement> = React.createRef();

  const handleSubmit = async (evt: React.FormEvent) => {
    evt.preventDefault();
    const { current: userName } = userNameRef;
    const { current: roomName } = roomNameRef;
    if (userName && roomName) {
      const roomId = await props.createRoom(userName.value, roomName.value);
      props.history.push(`${RoutePath.ROOM}/${roomId}`);
    }
  }

  return <div className={'page'}>
    <Header />
    <main className="main">
      <div className="containter main__content">
        <div className="column-container">
          <form className="form" onSubmit={handleSubmit}>
            <p className="form__text">Let&apos;s Start!</p>
            <h2 className="form__title">Create the room:</h2>
            <Input ref={userNameRef} label='User name' labelClassName='form__label' inputClassName='form__input' name='userName' placeholder='Enter your name' required={true} />
            <Input ref={roomNameRef} label='Room name' labelClassName='form__label' inputClassName='form__input' name='roomName' placeholder='Enter room name' required={true} />
            <Button className={'form__button'} type="submit" title={'Enter'} />
          </form>
        </div>
      </div>
    </main>
    <Footer />
  </div>
};

export default CreatePageView;