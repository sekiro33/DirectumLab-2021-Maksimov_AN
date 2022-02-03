import * as React from 'react';
import Header from '../header/header';
import Footer from '../footer/footer';
import './no-match-page.css';

const NoMatchPage: React.FC = () => {
  return (
    <div className="page">
      <Header user={null} />
      <main className="main">
        <div className="containter main__content">
          <div className="text">
            Ooops!!
          </div>
        </div>
      </main>
      <Footer />
    </div>
  )
}

export default NoMatchPage;