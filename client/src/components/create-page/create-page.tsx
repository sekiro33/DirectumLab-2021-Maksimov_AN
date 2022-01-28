import * as React from 'react';
import Header from '../header/header';
import Footer from '../footer/footer';
import Button from '../button/button';
import Input from '../input/input';
import './create-page.css';

const CreatePage: React.FC = () => {
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
            <Button className={'form__button'} title={'Enter'} />
          </form>
        </div>
      </div>
    </main>
    <Footer />
  </div>
};

export default CreatePage;