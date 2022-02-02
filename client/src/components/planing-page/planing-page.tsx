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
import { RouteComponentProps } from 'react-router-dom';
import { loadRoom } from '../../api/api';

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
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
  votes:
    [{
      name: 'test',
      value: 4
    },
    {
      name: 'test2',
      value: 5
    }],
  average: 14
},
{
  storyName: 'Story',
  votes:
    [{
      name: 'test',
      value: 4
    },
    {
      name: 'test2',
      value: 5
    }],
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

    this.renderContentRoom.bind(this);
  }

  public async componentDidMount() {
      await loadRoom(this.props.match.params.roomId);
  }

  public renderContentRoom() {
    switch (this.state.roomState) {
      case RoomState.START:
        return (
          <StoryPlaceholder />
        );

      case RoomState.VOTE:
        return (
          <CardDeck cards={standardCardDeck} />
        );

      case RoomState.VOTED:
        return (
          <Results playersCount={2} average={4} votes={[{ grade: 3, count: 1 }, { grade: 5, count: 1 }]} />
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
          <div className="container main__content">
            <div className="title">Story</div>
            <div className="column-container">
              <div className="left-column">
                {this.renderContentRoom()}
                {testHistroy.length > 0 && <History history={testHistroy} isOwner={this.props.isOwner} />}
              </div>
              <div className="right-column">
                <PlayersContainer roomState={this.state.roomState} isOwner={this.props.isOwner} users={testUsers} />
              </div>
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default PlaningPage;