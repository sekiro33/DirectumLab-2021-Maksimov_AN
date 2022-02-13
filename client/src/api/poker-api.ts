import { IDiscussion, IRoom, IUser } from "../store/types";
import { Api } from "./api";

const baseUrl = 'http://localhost:44341/api';

const api = new Api(baseUrl);

export const signInRequest = async (userName: string): Promise<IUser | null> => {
  return await api.post<IUser>(`User/SignIn?name=${userName}`, null, null);
}; 

export const createRoomRequest = async (userName: string, roomName: string): Promise<{ room: IRoom | null; user: IUser; } | null> => {
  const userInfo = await signInRequest(userName);

  if (userInfo != null) {
    const response = await api.post<IRoom>(`Room/CreateRoom?roomName=${roomName}&userId=${userInfo.id}`, null, null);
    return { room: response, user: userInfo };
  }

  return null;
}

export const getCurrentUserRequest = async() : Promise<IUser | null> => {
  return await api.get<IUser>(`User/GetUser`, null);
}

export const getRoomInfoRequest = async (roomId: string): Promise<IRoom> => {
  return await api.get<IRoom>(`Room/GetRoomInfo?roomId=${roomId}`, null);
}

export const getAllDiscussionRoomRequest = async (roomId: string): Promise<IDiscussion[]> => {
  return await api.get<IDiscussion[]>(`Discussion/GetAllDiscussion?roomId=${roomId}`, null);
}

export const createDiscussionRequest = async (roomId: string, name: string): Promise<IDiscussion> => {
  return await api.post<IDiscussion>(`Discussion/CreateDiscussion?roomId=${roomId}&name=${name}`, null);
}

export const finishDiscussionRequest = async (discussionId: string): Promise<IDiscussion> => {
  return await api.post<IDiscussion>(`Discussion/EndDiscussion?discussionId=${discussionId}`, null, null);
}

export const joinRoomRequest = async (userName: string, roomId: string): Promise<IUser | null> => {
  const userInfo = await signInRequest(userName);

  if (userInfo != null) {
    const response = await api.post<IRoom>(`Room/Connect?roomId=${roomId}&userId=${userInfo.id}`, null, null);
    return userInfo;
  }

  return null;
}

export const voteRequest = async (discussionId: string, userId: string, cardId: string): Promise<IDiscussion | null> => {
  return await api.post<IDiscussion>(`Discussion/Vote?discussionId=${discussionId}&userId=${userId}&cardId=${cardId}`, null, null)
}



/*export const signInRequest = async (userName: string): Promise<IUser | null> => {
  const response = await fetch(`http://localhost:44341/api/User/SignIn?name=${userName}`, {
    method: 'POST',
    mode: 'cors',
    credentials: "include",
    headers: {
      'Content-Type': 'application/json',
    }
  });
  return await response.json();
}*/

/*export const createRoomRequest = async (userName: string, roomName: string): Promise<{ room: IRoom | null; user: IUser; } | null> => {
  const userInfo = await signInRequest(userName);

  if (userInfo != null) {
    const response = await fetch(`http://localhost:44341/api/Room/CreateRoom?roomName=${roomName}&userId=${userInfo.id}`, {
      method: 'POST',
      credentials: 'include',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json'
      }
    });

    return { room: await response.json(), user: userInfo };
  }

  return null;
}*/

/*export const getRoomInfoRequest = async (roomId: string): Promise<IRoom> => {
  const response = await fetch(`http://localhost:44341/api/Room/GetRoomInfo?roomId=${roomId}`, {
    method: 'GET',
    credentials: 'include',
    mode: 'cors',
    headers: {
      'Content-Type': 'application/json'
    }
  });

  return await response.json();
}*/

/*export const getAllDiscussionRoomRequest = async (roomId: string): Promise<IDiscussion[]> => {
  const response = await fetch(`http://localhost:44341/api/Discussion/GetAllDiscussion?roomId=${roomId}`, {
    method: 'GET',
    credentials: 'include',
    mode: 'cors',
    headers: {
      'Content-Type': 'application/json'
    }
  });

  return await response.json();
} */

/*export const createDiscussionRequest = async (roomId: string, name: string): Promise<IDiscussion> => {
  const response = await fetch(`http://localhost:44341/api/Discussion/CreateDiscussion?roomId=${roomId}&name=${name}`, {
    method: 'POST',
    credentials: 'include',
    mode: 'cors',
    headers: {
      'Content-Type': 'application/json'
    }
  });

  return await response.json();
}*/

/*export const finishDiscussionRequest = async (discussionId: string): Promise<IDiscussion> => {
  const response = await fetch(`http://localhost:44341/api/Discussion/EndDiscussion?discussionId=${discussionId}`, {
    method: 'POST',
    credentials: 'include',
    mode: 'cors',
    headers: {
      'Content-Type': 'application/json'
    }
  });

  return await response.json();
}*/

/*export const joinRoomRequest = async (userName: string, roomId: string): Promise<IUser | null> => {
  const userInfo = await signInRequest(userName);

  if (userInfo != null) {
    const response = await fetch(`http://localhost:44341/api/Room/Connect?roomId=${roomId}&userId=${userInfo.id}`, {
      method: 'POST',
      credentials: 'include',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json'
      }
    });

    return userInfo;
  }

  return null;
}*/

/*export const voteRequest = async (discussionId: string, userId: string, cardId: string): Promise<IDiscussion | null> => {
  const response = await fetch(`http://localhost:44341/api/Discussion/Vote?discussionId=${discussionId}&userId=${userId}&cardId=${cardId}`, {
    method: 'POST',
    credentials: 'include',
    mode: 'cors',
    headers: {
      'Content-Type': 'application/json'
    }
  });

  return await response.json();
}
*/