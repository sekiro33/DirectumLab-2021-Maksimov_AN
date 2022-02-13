import { Dispatch } from "redux"
import { IRoom, IRootState } from "../types"
import { createRoomRequest, getRoomInfoRequest, joinRoomRequest} from "../../api/poker-api"
import { updateUser } from "../user/user-action-creators"
import { updateRoom as actionUpdateRoom } from "./room-action-creators";


export const createRoom = (userId: string, roomName: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<string> => {
    const response = await createRoomRequest(userId, roomName);
    if (response != null && response.room && response.user) {
      dispatch(updateUser(response.user));
      return response.room.id;
    }
    return '';
  }
}

export const updateRoom = (roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom | null> => {
    const response = await getRoomInfoRequest(roomId);
    if (response != null) {
      dispatch(actionUpdateRoom(response));
      return response;
    }
    return null;
  }
}

export const joinRoom = (userName: string, roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await joinRoomRequest(userName, roomId);
    if (response != null) {
      dispatch(updateUser(response));
    }
    return null;
  }
}

export const getRoomInfo = (roomId: string): any => {
  return async(dispatch: Dispatch, getState: () => IRootState) => {
    const response = await getRoomInfoRequest(roomId);
    if (response != null) {
      dispatch(actionUpdateRoom(response));
    }
    return null;
  }
}