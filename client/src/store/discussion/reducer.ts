import { IDiscussion } from "../types";
import { DiscussionActionType, IUpdateDiscussionAction, IUpdateDiscussionsAction } from "./discussion-action-creators";

export const reducer = (state: IDiscussion[] = [], action: IUpdateDiscussionAction | IUpdateDiscussionsAction): any => {
  switch (action.type) {
    case DiscussionActionType.CREATE_DISCUSSION: {
      return [...state, (action as IUpdateDiscussionAction).discussion];
    }

    case DiscussionActionType.FINISH_DISCUSSION: {
      const discussions = [...state];
      discussions[discussions.length - 1] = (action as IUpdateDiscussionAction).discussion;
      return discussions;
    }

    case DiscussionActionType.VOTE: {
      const discussions = [...state];
      discussions[discussions.length - 1] = (action as IUpdateDiscussionAction).discussion;
      return discussions;
    }

    case DiscussionActionType.CLEAR_DISCUSSION: {
      return [];
    }

    case DiscussionActionType.UPDATE_DISCUSSION: {
      return [...(action as IUpdateDiscussionsAction).discussions];
    }

    default:
      return state;
  }
}