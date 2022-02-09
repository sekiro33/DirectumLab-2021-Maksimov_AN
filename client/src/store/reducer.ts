import { combineReducers } from "redux"
import { reducer as userReducer } from "./user/reducer"
import { reducer as roomReducer } from "./room/reducer"

export const reducer = combineReducers({
  user: userReducer,
  room: roomReducer
});