import { connect } from 'react-redux';
import { Dispatch } from 'redux';
import { clearRoom } from '../../store/room/room-action-creators';
import { clearUser } from '../../store/user/user-action-creators';
import LogoView from './logo-view';

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    clearStore: () => {
      dispatch(clearUser());
      dispatch(clearRoom());
    },
  };
}

export default connect(null, mapDispatchToProps)(LogoView);