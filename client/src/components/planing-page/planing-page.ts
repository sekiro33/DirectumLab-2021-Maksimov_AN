import { IRootState } from '../../store/types';
import { connect } from 'react-redux';
import { compose, Dispatch } from 'redux';
import { getRoomInfo, updateRoom } from '../../store/room/room-operations';
import PlaningPageView from './planing-page-view';
import { withRouter } from 'react-router-dom';
import { roomSelector } from '../../store/room/room-selector';
import { getDiscussions } from '../../store/discussion/discussion-selector';
import { createDiscussion, vote } from '../../store/discussion/discussion-operations';
import { finishDiscussion } from '../../store/discussion/discussion-operations';
import { updateDiscussions } from '../../store/discussion/discussion-operations';
import { getCurrentUser } from '../../store/user/user-operation';

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user,
    room: roomSelector(state),
    discussions: getDiscussions(state),
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateRoom: (roomId: string) => {
      dispatch(updateRoom(roomId));
    },

    createDiscussion: (roomId: string, discussionName: string) => {
      dispatch(createDiscussion(roomId, discussionName));
    },

    finishDiscussion: (discussionId: string) => {
      dispatch(finishDiscussion(discussionId));
    },

    vote: (discussionId: string, userId: string, cardId: string) => {
      dispatch(vote(discussionId, userId, cardId));
    },

    getRoomInfo: (roomId: string) => {
      dispatch(getRoomInfo(roomId));
      dispatch(updateDiscussions(roomId));
    },

    updateUser: () => {
      dispatch(getCurrentUser());
    }
  };
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(PlaningPageView);