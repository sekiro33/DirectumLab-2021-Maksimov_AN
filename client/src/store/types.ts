export type UserId = string;

export interface IUser {
  id: UserId;
  name: string;
}

export interface ICard {
  value: number;
}

export interface IRoom {
  id: string;
  name: string;
  cards: Array<ICard>;
  ownerId: UserId;
  users: Array<IUser>;
  stories: Array<IStory>;
}

export interface IStory {
  id: string;
  name: string;
  average: number | null;
  votes: Record<UserId, ICard>;
  isOver: boolean,
}

export interface IRootState {
  room: IRoom | null;
  user: IUser | null;
}