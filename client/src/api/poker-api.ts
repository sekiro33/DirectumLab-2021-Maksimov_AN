import { IRoom, IServerRoom, IServerUser } from "../store/types";

export const signIn = async (userName: string): Promise<IServerUser | null> => {
  const response = await fetch(`http://localhost:44341/api/User/SignIn?name=${userName}`, {
    method: 'POST',
    mode: 'cors',
    credentials: "include",
    headers: {
      'Content-Type': 'application/json'
    }
  });
  return await response.json();
}

export const createRoom = async (userName: string, roomName: string): Promise<IServerRoom | null> => {
  const userInfo = await signIn(userName);
  window.console.log('user:');
  window.console.log(userInfo);

  if (userInfo != null) {
    const response = await fetch(`http://localhost:44341/api/Room/CreateRoom?roomName=${roomName}&userId=${userInfo.id}`, {
      method: 'POST',
      credentials: 'include',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json'
      }
    });

    window.console.log('room:');
    window.console.log(await response.json());

    return await response.json();
  }

  return null;
}