import * as React from 'react';
import { IUser, IRoom, ICard, IStory } from '../../store/types'
import Header from '../header/header';
import Footer from '../footer/footer';
import CardDeck from '../card-deck/card-deck';
import Results from '../results/results';
import './planing-page.css';
import StoryPlaceholder from '../story-placeholder/story-placeholder';
import PlayersContainer from '../players-container/players-container';
import { RouteComponentProps } from 'react-router-dom';
import { loadRoom } from '../../api/api';
import { room } from '../../store/mock';
import History from '../history/history';

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  user: IUser | null;
  room: IRoom | null;
  updateRoom: (room: IRoom) => void;
}

class PlaningPageView extends React.Component<IProps, any> {
  constructor(props: IProps) {
    super(props);
  }

  public componentDidMount() {
    if (this.props.room == null) {
      const room = loadRoom(this.props.match.params.roomId);
      this.updateRoom(room);
    }
  }

  private updateRoom(room: IRoom | null) {
    if (room) {
      this.props.updateRoom(room);
    }
  }

  private getCurrentStory(room: IRoom) {
    if (room.stories.length == 0) {
      return null;
    }
    return room.stories[room.stories.length - 1];
  }

  private renderPlaceholder() {
    return (
      <StoryPlaceholder />
    )
  }

  private renderCardDeck(cards: ICard[], selectedCard: number | null) {
    return (
      <CardDeck selectedCard={selectedCard} cards={cards} />
    );
  }

  private getSelectedCard(story: IStory) {
    const user = this.props.user;
    if (user != null && story.votes[user.id] != null) {
      return story.votes[user.id].value;
    }
    return null;
  }

  private renderResults() {
    if (this.props.room) {
      const { users } = this.props.room;
      const story = this.props.room.stories[this.props.room.stories.length - 1];
      return (
        <Results playersCount={users.length} average={story.average} votes={story.votes} />
      );
    } else {
      return null;
    }
  }

  private renderHistory(user: IUser | null) {
    if (this.props.room && user) {
      if (this.props.room.stories.length > 0 && this.props.room.stories[0].average != null) {
        const isOwner = user.id == room.ownerId;
        return (
          <History isOwner={isOwner} stories={this.props.room.stories} />
        );
      }
    }
    return null;
  }

  private renderContent(room: IRoom | null) {
    if (room == null) {
      return null;
    }
    else {
      const currentStory = this.getCurrentStory(room);
      if (currentStory == null) {
        return this.renderPlaceholder();
      }
      else if (currentStory.average == null) {
        return this.renderCardDeck(room.cards, this.getSelectedCard(currentStory));
      }
      else {
        return this.renderResults();
      }
    }
  }

  private renderPlayersContainer(room: IRoom | null, user: IUser | null) {
    if (room == null || user == null) {
      return null;
    } else {
      let votes = null;
      const currentStory = this.getCurrentStory(room);
      if (currentStory != null) {
        votes = currentStory.votes;
      }
      const isOwner = user.id == room.ownerId;
      return (
        <PlayersContainer users={room.users} votes={votes} isOwner={isOwner} roomState={false} />
      );
    }
  }

  public render() {
    const { room } = this.props;
    const { user } = this.props;
    return (
      <div className='page'>
        <Header />
        <main className="main">
          <div className="container main__content">
            <div className="title"></div>
            <div className="column-container">
              <div className="left-column">
                {this.renderContent(room)}
                {this.renderHistory(user)}
              </div>
              <div className="right-column">
                {this.renderPlayersContainer(room, user)}
              </div>
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default PlaningPageView;