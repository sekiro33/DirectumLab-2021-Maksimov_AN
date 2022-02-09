import { IUser } from "../types";
import { IUpdateUserAction, UserActionType } from "./user-action-creators";

export const reducer = (state: IUser | null = null, action: IUpdateUserAction): IUser | null => {
  switch (action.type) {

    case UserActionType.UPDATE_USER: {
      return {
          ...action.user
      };
    }

    default:
      return state;
  }
}