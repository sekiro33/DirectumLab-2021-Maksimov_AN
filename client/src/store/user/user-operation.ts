import { Dispatch } from "redux"
import { IRootState } from "../types"
import { getCurrentUserRequest } from "../../api/poker-api"
import { updateUser } from "../user/user-action-creators"


export const getCurrentUser = (): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await getCurrentUserRequest();
    if (response != null) {
      dispatch(updateUser(response));
    }
  }
}
