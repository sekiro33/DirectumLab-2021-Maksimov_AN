import { Dispatch } from "redux"
import { IRootState } from "../types"
import { getCurrentUserRequest, logoutRequest } from "../../api/poker-api"
import { clearUser, updateUser } from "../user/user-action-creators"
import { clearRoom } from "../room/room-action-creators"
import { clearDiscussion } from "../discussion/discussion-action-creators"
import { batch } from "react-redux"


export const getCurrentUser = (): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await getCurrentUserRequest();
    if (response != null) {
      dispatch(updateUser(response));
    }
  }
}

export const logout = (): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    logoutRequest();
    //batch
    dispatch(clearUser());
    dispatch(clearRoom());
    dispatch(clearDiscussion());
  }
}