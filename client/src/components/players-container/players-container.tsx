import * as React from 'react';
import PlayersList from '../players-list/players-list';
import StoryCreator from '../story-creator/story-creator';
import Input from '../input/input';
import { ICard, IUser, UserId } from '../../store/types'
import './players-container.css';

interface IProps {
  users: IUser[];
  isOwner: boolean;
  votes: Record<UserId, ICard> | null;
  roomState: boolean
}

const PlayersContainer: React.FC<IProps> = (props) => {
  const getVotedUsersCount = (users: IUser[], votes: Record<UserId, ICard> | null) => {
    let count = 0;
    if (votes == null) return count;
    users.forEach((user) => {
      if (votes[user.id] != null) {
        count++;
      }
    });
    return count;
  }

  return (
    <div className="players-container">
      <header className="players-container__header">
        <p className="players-container__title">Story voting completed</p>
      </header>
      {props.isOwner && <StoryCreator />}
      <p className="players__text">Player ({getVotedUsersCount(props.users, props.votes)}/{props.users.length})</p>
      <PlayersList users={props.users} roomState={props.roomState} votes={props.votes} />
      <Input labelClassName='players__label' inputClassName='input players__input' label="Invite a teammate" value={document.location.href} readonly={true} />
    </div>
  );
}

export default PlayersContainer;