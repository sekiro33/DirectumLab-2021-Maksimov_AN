import { IRoom, IRootState, IStory, IUser } from "./types";

export const store: IRootState = {
  user: null,
  room: null,
};

export const user: IUser = {
  id: '',
  name: '',
}

export const room: IRoom = {
  id: '',
  name: '',
  cards: [{ value: 0}, {value: 0.5}, { value: 1}, { value: 2}, { value: 3}, { value: 5}, { value: 8}, { value: 13}, {value: 20}, {value: 40}, {value: 100}, {value: -10}, {value: -100}, ],
  ownerId: '',
  users: [],
  stories: [],
}

export const story: IStory = {
  id: '',
  name: '',
  average: null,
  votes: {},
  isOver: false,
}

