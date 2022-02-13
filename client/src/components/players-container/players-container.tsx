import * as React from 'react';
import PlayersList from '../players-list/players-list';
import StoryCreator from '../story-creator/story-creator';
import Input from '../input/input';
import { IUser } from '../../store/types';
import './players-container.css';

interface IProps {
  users: IUser[];
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
        count++;
    });
    return count;
  }

  const inviteHref = document.location.host + '/invite' + `/${props.roomId}`;
 
  return (
    <div className="players-container">
      <header className="players-container__header">
        <p className="players-container__title">Story voting completed</p>
      </header>
      {props.isOwner && <StoryCreator createDiscussion={props.createDiscussion} finishDiscussion={props.finishDiscussion} isVoted={props.isVoted} />}
      <p className="players__text">Player ({props.grades ? getVotedUsersCount(props.grades, props.users) : 0}/{props.users.length})</p>
      <PlayersList grades={props.grades} isVoted={props.isVoted} users={props.users} />
      <Input labelClassName='players__label' inputClassName='input players__input' label="Invite a teammate" value={inviteHref} readonly={true} />
    </div>
  );
}

export default PlayersContainer;