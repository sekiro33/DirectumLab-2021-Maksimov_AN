import * as React from 'react';
import Header from '../header/header';
import Footer from '../footer/footer';
import Button from '../button/button';
import Input from '../input/input';
import './invite-page.css';

const InvitePage: React.FC = () => {
  return <div className='page'>
    <Header user={null} />
    <main className="main">
      <div className="containter main__content">
        <form className="form">
          <p className="form__text">Let&apos;s Start!</p>
          <h2 className="form__title">Join the room:</h2>
          <Input label='User name' labelClassName='form__label' inputClassName='form__input' name='userName' placeholder='Enter your name' required={true} /> 
          <Button className='form__button' title='Enter' />
        </form>
      </div>
    </main>
    <Footer />
  </div>
};

export default InvitePage;