import { Action } from "redux";
import { IRoom } from "../types";

export const RoomActionType = {
  UPDATE_ROOM: 'UPDATE_ROOM',
  CLEAR_ROOM: 'CLEAR_ROOM',
}

export interface IUpdateRoomAction extends Action {
  room: IRoom;
}

export const updateRoom = (room: IRoom) => {
  return {
    type: RoomActionType.UPDATE_ROOM,
    room,
  };
}

export const clearRoom = () => {
  return {
    type: RoomActionType.CLEAR_ROOM,
  }
}