import { IRoom, IRootState } from '../../store/types';
import { connect } from 'react-redux';
import { compose, Dispatch } from 'redux';
import { updateRoom } from '../../store/room/room-action-creators';
import PlaningPageView from './planing-page-view';
import { withRouter } from 'react-router-dom';
import { roomSelector } from '../../store/room/room-selector';

const mapStateToProps = (state: IRootState) => {
  return {
    user: state.user,
    room: roomSelector(state),
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateRoom: (room: IRoom) => {
      dispatch(updateRoom(room));
    }
  }
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(PlaningPageView);