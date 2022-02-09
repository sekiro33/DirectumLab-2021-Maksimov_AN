import * as React from 'react';
import { IUser, IRoom, ICard, IStory } from '../../store/types'
import Header from '../header/header';
import Footer from '../footer/footer';
import CardDeck from '../card-deck/card-deck';
import Results from '../results/results';
import StoryPlaceholder from '../story-placeholder/story-placeholder';
import PlayersContainer from '../players-container/players-container';
import { RouteComponentProps } from 'react-router-dom';
import { loadRoom } from '../../api/api';
import History from '../history/history';
import './planing-page.css';


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

  private renderResults(room: IRoom) {
    const { users } = room;
    const story = room.stories[room.stories.length - 1];
    return (
      <Results playersCount={users.length} average={story.average} votes={story.votes} />
    );
  }

  private renderHistory(user: IUser, room: IRoom) {
    if (room.stories.length > 0 && room.stories[0].average != null) {
      const isOwner = user.id == room.ownerId;
      return (
        <History users={room.users} isOwner={isOwner} stories={room.stories} />
      );
    }
  }

  private renderContent(room: IRoom) {
    const currentStory = this.getCurrentStory(room);
    if (currentStory == null) {
      return this.renderPlaceholder();
    }
    else if (currentStory.average == null) {
      return this.renderCardDeck(room.cards, this.getSelectedCard(currentStory));
    }
    else {
      return this.renderResults(room);
    }
  }

  private renderTitle(room: IRoom) {
    const story = this.getCurrentStory(room);
    if (story != null)
      return (<div className="title">{story.name}</div>)
    else
      return (<div className="title"></div>)
  }

  private renderPlayersContainer(room: IRoom, user: IUser) {
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

  public render() {
    const { room } = this.props;
    const { user } = this.props;
    return (
      <div className='page'>
        <Header />
        <main className="main">
          <div className="container main__content">
            {room != null && this.renderTitle(room)}
            <div className="column-container">
              <div className="left-column">
                {room != null && this.renderContent(room)}
                {user != null && room != null && this.renderHistory(user, room)}
              </div>
              <div className="right-column">
                {room != null && user != null && this.renderPlayersContainer(room, user)}
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