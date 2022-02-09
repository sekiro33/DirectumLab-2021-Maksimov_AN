import { Action } from "redux";
import { IRoom, IStory } from "../types";

export const RoomActionType = {
  UPDATE_ROOM: 'UPDATE_ROOM',
}

export interface IUpdateRoomAction extends Action {
  room: IRoom;
  story: IStory;
}

export const updateRoom = (room: IRoom) => {
  return {
    type: RoomActionType.UPDATE_ROOM,
    room,
  };
}
