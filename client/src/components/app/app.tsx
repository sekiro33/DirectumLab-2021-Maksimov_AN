import * as React from 'react';
import { Switch, Route } from 'react-router-dom';
import { RoutePath } from '../../routes';
import CreatePage from '../create-page/create-page';
import PlaningPage from '../planing-page/planing-page';
import InvitePage from '../invite-page/invite-page';
import NoMatchPage from '../no-match-page/no-match-page';
import './app.css';

function App() {
  return (
    <Switch>
      <Route path={RoutePath.INDEX} exact={true} component={CreatePage} />
      <Route path={`${RoutePath.ROOM}/:roomId`} exact={true} component={PlaningPage} />
      <Route path={`${RoutePath.INVITE}/:roomId`} exact={true} component={InvitePage} />
      <Route component={NoMatchPage} />
    </Switch>
  );
}
export default App;
