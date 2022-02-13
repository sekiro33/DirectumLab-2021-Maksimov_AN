import { Action } from "redux"
import { IUser } from "../types"

export const UserActionType = {
  UPDATE_USER: 'UPDATE_USER',
  CLEAR_USER: 'CLEAR_USER',
}

export interface IUpdateUserAction extends Action {
  user: IUser;
}

export const updateUser = (user: IUser) => {
  return {
    type: UserActionType.UPDATE_USER,
    user,
  }
}

export const clearUser = () => {
  return {
    type: UserActionType.CLEAR_USER
  }
}