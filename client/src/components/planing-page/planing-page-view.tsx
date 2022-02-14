import * as React from 'react';
import { IUser, IRoom, IDiscussion, ICard } from '../../store/types'
import Header from '../header/header';
import Footer from '../footer/footer';
import History from '../history/history';
import { RouteComponentProps } from 'react-router-dom';
import StoryPlaceholder from '../story-placeholder/story-placeholder';
import PlayersContainer from '../players-container/players-container';
import CardDeck from '../card-deck/card-deck';
import Results from '../results/results';
import './planing-page.css';

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  user: IUser | null;
  room: IRoom | null;
  discussions: IDiscussion[];
  updateRoom: (roomId: string) => void;
  getRoomInfo: (roomId: string) => void;
  updateUser: () => boolean;
  createDiscussion: (roomId: string, discussionName: string) => void;
  finishDiscussion: (discussionId: string) => void;
  vote: (discussionId: string, userId: string, cardId: string) => void;
}

class PlaningPageView extends React.Component<IProps, any> {
  constructor(props: IProps) {
    super(props);

    this.timer = null;

    this.createDiscussion = this.createDiscussion.bind(this);
    this.finishDiscussion = this.finishDiscussion.bind(this);
    this.getCurrentDiscussion = this.getCurrentDiscussion.bind(this);
    this.selectCard = this.selectCard.bind(this);
  }

  public componentDidMount() {
    if (this.props.user == null) {
      const res = this.props.updateUser();
    }

    if (this.props.room == null) {
      this.props.getRoomInfo(this.props.match.params.roomId);
    }

    this.timer = setInterval(this.props.getRoomInfo, 2000, this.props.match.params.roomId);
  }

  public componentWillUnmount(): void {
    this.timer = clearInterval(this.timer);
  }

  timer: any;

  public getCurrentDiscussion() {
    if (this.props.discussions.length > 0) {
      const currentDiscussion = this.props.discussions[this.props.discussions.length - 1];
      return currentDiscussion;
    }
    return null;
  }

  private renderPlaceholder() {
    return (
      <StoryPlaceholder />
    )
  }

  private calcAverage(grades: Record<string, number> | null) {
    if (grades == null)
      return 0;
    let playersCount = 0;
    let sum = 0;
    for (const key in grades) {
      if (grades[key] > 0) {
        playersCount++;
        sum += grades[key];
      }
    }
    return playersCount > 0 ? sum / playersCount : 0;

  }

  private renderContent(room: IRoom, user: IUser) {
    const currentDiscussion = this.getCurrentDiscussion();
    if (currentDiscussion == null) {
      return this.renderPlaceholder();
    } else if (currentDiscussion.endDateTime && room.cardDeck) {
      const grades = this.convertGrades(currentDiscussion.grades, room.cardDeck.cards);
      return <Results playersCount={room.users.length} average={this.calcAverage(grades)} grades={grades} />
    } else {
      if (room.cardDeck) {
        const selectedCard = this.getSelectedCard(currentDiscussion.grades, user)
        return <CardDeck selectCard={this.selectCard} selectedCard={selectedCard} cards={room.cardDeck.cards} />
      }
    }
  }

  private selectCard(cardId: string) {
    const currentDiscussion = this.getCurrentDiscussion();
    if (currentDiscussion && this.props.user)
      this.props.vote(currentDiscussion.id, this.props.user.id, cardId);
  }

  private getSelectedCard(grades: Record<string, string>, user: IUser) {
    for (const key in grades) {
      if (key == user.id) {
        return grades[key];
      }
    }
    return null;
  }

  private renderPlayerList(room: IRoom, user: IUser) {
    const currentDiscussion = this.getCurrentDiscussion();
    let grades = null;
    let isVoted = true;
    if (currentDiscussion && room && room.cardDeck) {
      grades = this.convertGrades(currentDiscussion?.grades, room.cardDeck.cards);
      isVoted = currentDiscussion.endDateTime != null;
    }
    const isOwner = user.id == room.creator;
    return (
      <PlayersContainer roomId={this.props.match.params.roomId} grades={grades} users={room.users} isOwner={isOwner} isVoted={isVoted} createDiscussion={this.createDiscussion} finishDiscussion={this.finishDiscussion} />
    )
  }

  private renderDiscussionHistory(room: IRoom, user: IUser, discussions: IDiscussion[]) {
    if (discussions && discussions.length > 0 && discussions[0].endDateTime) {
      const isOwner = room.creator == user.id;
      const cards = room.cardDeck ? room.cardDeck.cards : null;
      return <History calcAverage={this.calcAverage} gradesConverter={this.convertGrades} cards={cards} users={room.users} discussions={discussions} isOwner={isOwner} />
    }
  }

  private convertGrades(grades: Record<string, string> | null | undefined, cards: ICard[]): Record<string, number> | null {
    if (grades == null || grades == undefined) {
      return null;
    }
    const convertGrades: Record<string, number> = {};
    for (const key in grades) {
      const cardValue = cards.find(card => card.id == grades[key]);
      if (cardValue)
        convertGrades[key] = cardValue.value;
    }
    return convertGrades;
  }

  private createDiscussion = (name: string) => {
    this.props.createDiscussion(this.props.match.params.roomId, name);
  }

  private finishDiscussion() {
    const currentDiscussion = this.getCurrentDiscussion();
    if (currentDiscussion != null && currentDiscussion.endDateTime == null) {
      this.props.finishDiscussion(currentDiscussion.id);
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
            <div className="column-container">
              <div className="left-column">
                {room && user && this.renderContent(room, user)}
                {room && user && this.renderDiscussionHistory(room, user, this.props.discussions)}
              </div>
              <div className="right-column">
                {room && user && this.renderPlayerList(room, user)}
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