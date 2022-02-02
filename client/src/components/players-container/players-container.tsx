import * as React from 'react';
import PlayersList from '../players-list/palyers-list';
import StoryCreator from '../story-creator/story-creator';
import Input from '../input/input';
import { RoomState } from '../planing-page/planing-page';
import './players-container.css';

export interface IUser {
  name: string;
  vote?: number;
}

interface IProps {
  users: IUser[];
  roomState: RoomState
  isOwner: boolean;
}

const PlayersContainer: React.FC<IProps> = (props) => {
  const getVotedUsersCount = (users: IUser[]) => {
    let count = 0;
    users.forEach((user) => {
      if (user.vote === null) {
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
      {props.isOwner === true && <StoryCreator />}
      <p className="players__text">Player ({getVotedUsersCount(props.users)}/{props.users.length})</p>
      <PlayersList roomState={props.roomState} users={props.users} />
      <Input labelClassName='players__label' inputClassName='input players__input' label="Invite a teammate" value={'https://www.planitpoker.com/board'} readonly={true} />
    </div>
  );
}

export default PlayersContainer;