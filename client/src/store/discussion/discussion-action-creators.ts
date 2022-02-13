import { Action } from "redux";
import { IDiscussion } from "../types";

export const DiscussionActionType = {
  CLEAR_DISCUSSION: 'CLEAR_DISCUSSION',
  CREATE_DISCUSSION: 'CREATE_DISCUSSION',
  FINISH_DISCUSSION: 'FINISH_DISCUSSION',
  VOTE: 'VOTE',
  UPDATE_DISCUSSION: 'UPDATE_DISCUSSIONS',
}

export interface IUpdateDiscussionAction extends Action {
  discussion: IDiscussion;
}

export interface IUpdateDiscussionsAction extends Action {
  discussions: IDiscussion[];
}

export const updateDiscussions = (discussions: IDiscussion[]) => {
  return {
    type: DiscussionActionType.UPDATE_DISCUSSION,
    discussions: discussions,
  }
}

export const clearRoom = () => {
  return {
    type: DiscussionActionType.CLEAR_DISCUSSION,
  }
}

export const createDiscussion = (discussion: IDiscussion) => {
  return {
    type: DiscussionActionType.CREATE_DISCUSSION,
    discussion,
  };
}

export const finishDiscussion = (discussion: IDiscussion) => {
  return {
    type:  DiscussionActionType.FINISH_DISCUSSION,
    discussion,
  }
}

export const vote = (discussion: IDiscussion) => {
  return {
    type: DiscussionActionType.VOTE,
    discussion,
  }
}
