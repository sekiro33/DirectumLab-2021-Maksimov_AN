import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { compose, Dispatch } from "redux";
import { updateUser } from "../../store/user/user-action-creators";
import { IUser } from "../../store/types";
import CreatePageView from "./create-page-view";

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateUser: (user: IUser) => {
      dispatch(updateUser(user));
    }
  }
}

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);