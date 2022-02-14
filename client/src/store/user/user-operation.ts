import { Dispatch } from "redux"
import { IRootState } from "../types"
import { checkUser, getCurrentUserRequest, logoutRequest } from "../../api/poker-api"
import { clearUser, updateUser } from "../user/user-action-creators"
import { clearRoom } from "../room/room-action-creators"
import { clearDiscussion } from "../discussion/discussion-action-creators"
import { batch } from "react-redux"


export const getCurrentUser = (roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<boolean> => {
    const currentUser = await getCurrentUserRequest();
    if (currentUser != null) {
      const check = await checkUser(currentUser.id, roomId);
      window.console.log(check);
      if (check == true) {
        dispatch(updateUser(currentUser));
        return true;
      }
    }
    return false;
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