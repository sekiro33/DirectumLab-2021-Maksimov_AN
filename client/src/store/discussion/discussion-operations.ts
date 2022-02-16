import { Dispatch } from "redux"
import { IRootState } from "../types"
import { createDiscussionRequest, finishDiscussionRequest, getAllDiscussionRoomRequest, voteRequest } from "../../api/poker-api"
import { createDiscussion as createDiscussionAction } from "../discussion/discussion-action-creators"
import { finishDiscussion as finishDiscussionAction } from "../discussion/discussion-action-creators";
import { updateDiscussions as updateDiscussionsAction } from "../discussion/discussion-action-creators"; 
import { vote as voteAction } from "../discussion/discussion-action-creators";

export const createDiscussion = (roomId: string, discussionName: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await createDiscussionRequest(roomId, discussionName);
    if (response != null) {
      dispatch(createDiscussionAction(response));
    }
  }
}

export const finishDiscussion = (discussionId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await finishDiscussionRequest(discussionId);
    if (response != null) {
      dispatch(finishDiscussionAction(response));
    }
  }
}

export const vote = (discussionId: string, userId: string, cardId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await voteRequest(discussionId, userId, cardId);
    if (response != null) {
      dispatch(voteAction(response));
    }
  }
}

export const updateDiscussions = (roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await getAllDiscussionRoomRequest(roomId);
    if (response != null) {
      dispatch(updateDiscussionsAction(response));
    }
  }
}