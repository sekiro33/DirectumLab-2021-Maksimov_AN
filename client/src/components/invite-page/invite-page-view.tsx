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

interface IProps extends RouteComponentProps<IMatchParams> {
  joinRoom: (userName: string, roomId: string) => Promise<void>;
}

const InvitePageView: React.FC<IProps> = (props) => {
  const userNameRef: React.RefObject<HTMLInputElement> = React.createRef();

  const handleClick = async (evt: React.FormEvent) => {
    evt.preventDefault();
    const { current: userName } = userNameRef;
    if (userName) {
      await props.joinRoom(userName.value, props.match.params.roomId);
      props.history.push(`${RoutePath.ROOM}/${props.match.params.roomId}`); 
    }
  }

  return <div className='page'>
    <Header />
    <main className="main">
      <div className="containter main__content">
        <form className="form" onSubmit={handleClick}>
          <p className="form__text">Let&apos;s Start!</p>
          <h2 className="form__title">Join the room:</h2>
          <Input ref={userNameRef} label='User name' labelClassName='form__label' inputClassName='form__input' name='userName' placeholder='Enter your name' required={true} /> 
          <Button type="submit" className='form__button' title='Enter' />
        </form>
      </div>
    </main>
    <Footer />
  </div>
};

export default withRouter(InvitePageView);