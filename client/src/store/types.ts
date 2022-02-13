export interface IUser {
  id: string,
  name: string,
}

export interface IRoom {
  id: string;
  name: string;
  creator: string;
  users: IUser[];
  cardDeck: ICardDeck | null;
}

export interface ICardDeck {
  id: string;
  name: string;
  cards: ICard[];
}

export interface ICard {
  id: string;
  value: number;
}

export interface IRootState {
  user: IUser | null,
  room: IRoom | null,
  discussion: IDiscussion[] | null,
}

export interface IDiscussion {
  id: string,
  name: string,
  grades: Record<string, string>,
  startDateTime: string | null,
  endDateTime: string | null
}