import * as React from 'react';
import Header from '../header/header';
import Footer from '../footer/footer';
import History from '../history/history';
import Results from '../results/results';
import StoryPlaceholder from '../story-placeholder/story-placeholder';
import PlayersContainer from '../players-container/players-container';
import Modal from '../modal/modal';
import CardDeck from '../card-deck/card-deck';
import './planing-page.css';

interface IProps {
  userName: string;
  isOwner: boolean;
}

interface IState {
  roomState: RoomState;
}

export enum RoomState {
  START,
  VOTE,
  VOTED
}

const standardCardDeck = [{
  value: 0
}, {
  value: 0.5
}, {
  value: 1
}, {
  value: 2
}, {
  value: 3
}, {
  value: 5
}, {
  value: 8
}, {
  value: 13
}, {
  value: 20
}, {
  value: 40
}, {
  value: 100
}, {
  value: -10
}, {
  value: -100
}];

const testHistroy = [{
  storyName: 'Story',
  average: 14
},
{
  storyName: 'Story',
  average: 14
}];

const testUsers = [{
  name: 'test',
  voted: false,
  vote: 0
}, {
  name: 'test2',
  voted: false,
  vote: 0
}];

const testVotes = [{
  name: 'test',
  value: '3'
}, {
  name: 'test2',
  value: '8'
}];

class PlaningPage extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = { roomState: RoomState.START };
  }

  contentRoom = () => {
    switch (this.state.roomState) {
      case RoomState.START:
        return (
          <div className="container main__content">
            <div className="column-container">
              <div className="left-column">
                <StoryPlaceholder />
              </div>
              <div className="right-column">
                <PlayersContainer roomState={this.state.roomState} isOwner={this.props.isOwner} users={testUsers} />
              </div>
            </div>
          </div>
        );

      case RoomState.VOTE:
        return (
          <div className="container main__content">
            <div className="title">Story</div>
            <div className="column-container">
              <div className="left-column">
                <CardDeck cards={standardCardDeck} />
                <History history={testHistroy} isOwner={this.props.isOwner} />
              </div>
              <div className="right-column">
                <PlayersContainer roomState={this.state.roomState} isOwner={this.props.isOwner} users={testUsers} />
              </div>
            </div>
          </div>
        );

      case RoomState.VOTED:
        return (
          <div className="container main__content">
            <div className="title">Story</div>
            <div className="column-container">
              <div className="left-column">
                <Results playersCount={2} average={4} votes={[{ grade: 3, count: 1 }, { grade: 5, count: 1 }]} />
                <History history={testHistroy} isOwner={this.props.isOwner} />
                <Modal votes={testVotes} />
              </div>
              <div className="right-column">
                <PlayersContainer roomState={this.state.roomState} isOwner={this.props.isOwner} users={testUsers} />
              </div>
            </div>
          </div>
        );

      default:
        break;
    }
  }

  render() {
    return (
      <div className='page'>
        <Header user={{ name: this.props.userName }} />
        <main className="main">
          {this.contentRoom()}
        </main>
        <Footer />
      </div>
    );
  }
}

export default PlaningPage;