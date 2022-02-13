import { connect } from 'react-redux';
import { IRootState } from '../../store/types';
import { userSelector } from '../../store/user/user-selector';
import HeaderView from './header-view';

const mapStateToProps = (state: IRootState) => {
  return {
    user: userSelector(state),
  };
}

export default connect(mapStateToProps)(HeaderView);