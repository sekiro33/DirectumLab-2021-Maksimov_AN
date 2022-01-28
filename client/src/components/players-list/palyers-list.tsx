import * as React from 'react';
import avatar from '../../images/user_icon.svg';
import { RoomState } from '../planing-page/planing-page';
import './players-list.css';

interface IUser {
  name: string;
  voted: boolean;
  vote: number;
}

interface IProps {
  users: IUser[];
  roomState: RoomState;
}

class PlayersList extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
  }

  createList = (users: IUser[], roomState: number) => {
    return users.map((user) => {
      return (
        <li key={user.name} className="list__item players-list__item">
          <div className="players__info">
            <img className="players-list__avatar" src={avatar} alt="avatar" />
            <p className="players-list__text">{user.name}</p>
          </div>
          <div className="players-list__status">{roomState == RoomState.VOTED && user.vote}</div>
        </li>
      );
    });
  }

  render() {
    return (
      <ul className="list players__list">
        {this.createList(this.props.users, this.props.roomState)}
      </ul>
    );
  }
}

export default PlayersList;