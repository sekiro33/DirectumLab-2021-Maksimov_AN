import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { compose, Dispatch } from "redux";
import InvitePageView from "./invite-page-view";
import { joinRoom } from "../../store/room/room-operations";

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    joinRoom: async (userName: string, roomId: string) => {
      return dispatch(await joinRoom(userName, roomId));
    }
  }
}

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(InvitePageView);