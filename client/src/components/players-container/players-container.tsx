import * as React from 'react';
import PlayersList from '../players-list/palyers-list';
import StoryCreator from '../story-creator/story-creator';
import Input from '../input/input';
<<<<<<< Updated upstream
import { RoomState } from '../planing-page/planing-page';
=======
>>>>>>> Stashed changes
import './players-container.css';
import { IUser } from '../../store/types';

export interface IUser {
  name: string;
  vote?: number;
}

interface IProps {
  users: IUser[];
<<<<<<< Updated upstream
  roomState: RoomState
  isOwner: boolean;
}

const PlayersContainer: React.FC<IProps> = (props) => {
  const getVotedUsersCount = (users: IUser[]) => {
    let count = 0;
    users.forEach((user) => {
      if (user.vote === null) {
=======
  roomId: string;
  grades: Record<string, number> | null;
  isOwner: boolean;
  isVoted: boolean;
  createDiscussion: (name: string) => void;
  finishDiscussion: () => void;
}

const PlayersContainer: React.FC<IProps> = (props) => {
  const getVotedUsersCount = (grades: Record<string, number>, users: IUser[]) => {
    let count = 0;
    users.forEach((user) => {
      if (grades[user.id] != null)
>>>>>>> Stashed changes
        count++;
    });
    return count;
  }
<<<<<<< Updated upstream
  
=======

  const inviteHref = document.location.host + '/invite' + `/${props.roomId}`;
 
>>>>>>> Stashed changes
  return (
    <div className="players-container">
      <header className="players-container__header">
        <p className="players-container__title">Story voting completed</p>
      </header>
<<<<<<< Updated upstream
      {props.isOwner === true && <StoryCreator />}
      <p className="players__text">Player ({getVotedUsersCount(props.users)}/{props.users.length})</p>
      <PlayersList roomState={props.roomState} users={props.users} />
      <Input labelClassName='players__label' inputClassName='input players__input' label="Invite a teammate" value={document.location.href} readonly={true} />
=======
      {props.isOwner && <StoryCreator createDiscussion={props.createDiscussion} finishDiscussion={props.finishDiscussion} isVoted={props.isVoted} />}
      <p className="players__text">Player ({props.grades ? getVotedUsersCount(props.grades, props.users) : 0}/{props.users.length})</p>
      <PlayersList grades={props.grades} isVoted={props.isVoted} users={props.users} />
      <Input labelClassName='players__label' inputClassName='input players__input' label="Invite a teammate" value={inviteHref} readonly={true} />
>>>>>>> Stashed changes
    </div>
  );
}

export default PlayersContainer;