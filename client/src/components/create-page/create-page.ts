import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { compose, Dispatch } from "redux";
import CreatePageView from "./create-page-view";
import { createRoom } from "../../store/room/room-operations";

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: async (userName: string, roomName: string) => {
      return dispatch(createRoom(userName, roomName));
    }
  }
}

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);