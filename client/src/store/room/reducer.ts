import { IRoom } from "../types";
import { IUpdateRoomAction, RoomActionType } from "./room-action-creators";

export const reducer = (state: IRoom | null = null, action: IUpdateRoomAction): IRoom | null => {
  switch (action.type) {
    case RoomActionType.UPDATE_ROOM: {
      return {
        ...action.room,
      };
    }

    case RoomActionType.CLEAR_ROOM: {
      return null;
    }

    default:
      return state;
  }
}