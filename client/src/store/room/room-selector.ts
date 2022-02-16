import { IRootState } from "../types";

export const roomSelector = (state: IRootState) => state.room;

export const ownerIdSelector = (state: IRootState) => roomSelector(state)?.creator;