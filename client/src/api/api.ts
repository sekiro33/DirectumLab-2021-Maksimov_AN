import { store, user, room, story } from "../store/mock";
import { roomSelector } from "../store/room/room-selector";
import { ICard, IRoom, IStory, IUser } from "../store/types";

export const random = () => {
  return Math.round(Math.random() * (100 - 1) + 1).toString(10);
}

export const createRoom = (userName: string, roomName: string): { roomId: string; user: IUser; } => {
  user.id = random();
  user.name = userName;

  room.id = random();
  room.name = roomName;
  room.ownerId = user.id;
  room.users.push(user);

  store.user = user;
  store.room = room;

  return {
    roomId: room.id,
    user,
  };
}

export const loadRoom = (id: string): IRoom | null => {
  if (store.room != null && store.room.id === id) {
    return store.room;
  }
  return null;
}

export const createStory = (room: IRoom, storyName: string): IRoom | null => {
  const newStory = { ...story };

  newStory.id = random();
  newStory.name = storyName;
  newStory.isOver = false;
  newStory.votes = {};

  if (room != null) {
    const stories = [...room.stories];
    stories.push(newStory);
    return { ...room, stories: stories };
  }
  else
    return null;
}

export const finishStory = (room: IRoom): IRoom | null => {
  const calcAverage = (votes: Record<string, ICard>): number => {
    let sum = 0;
    let count = 0;
    for (const key in votes) {
      count++;
      if (votes[key].value == -10 || votes[key].value == -100) {
        continue;
      }
      window.console.log(votes[key].value);
      sum += votes[key].value;
    }
    if (count != 0) {
      return sum / count;
    } else {
      return 0;
    }
  };

  if (room != null) {
    const stories = [...room.stories];
    const currentStory = stories[stories.length - 1];
    currentStory.isOver = true;
    currentStory.average = calcAverage(stories[stories.length - 1].votes);
    window.console.log(stories);
    return {
      ...room,
      stories: stories,
    };
  } else {
    return null;
  }
}

export const vote = (user: IUser, room: IRoom, value: number): IRoom | null => {
  if (room != null) {
    const stories = [...room.stories];
    stories[stories.length - 1].votes[user.id] = { value: value };
    return {
      ...room,
      stories: stories,
    };
  } else {
    return null;
  }
}


export const join = (roomId: string, userName: string): IUser => {
  const newUser: IUser = {
    id: random(),
    name: userName,
  };

  if (store.room?.id === roomId) {
    room.users.push(newUser);
  }

  return newUser;
}

