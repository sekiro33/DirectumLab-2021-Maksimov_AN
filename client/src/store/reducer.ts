import { combineReducers } from "redux"
import { reducer as userReducer } from "./user/reducer"
import { reducer as roomReducer } from "./room/reducer"
import { reducer as discussionReducer } from "./discussion/reducer"

export const reducer = combineReducers({
  user: userReducer,
  room: roomReducer,
  discussion: discussionReducer,
});