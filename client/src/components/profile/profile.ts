import { connect } from "react-redux";
import { Dispatch } from "redux";
import { logout } from "../../store/user/user-operation";
import ProfileView from "./profile-view";

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    logout: () => {
      dispatch(logout());
    }
  }
}

export default connect(null, mapDispatchToProps)(ProfileView);