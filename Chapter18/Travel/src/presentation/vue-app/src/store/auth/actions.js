import * as types from "./types";
import {
  loginUserAxios,
  isTokenFromLocalStorageValid,
  getToken
} from "@/auth/auth.service";

export async function loginUserAction({ commit }, payload) {
  try {
    const { data } = await loginUserAxios(payload);
    commit(types.LOGIN_USER, data.token);
  } catch (e) {
    console.log(e);
  }
}

export function useLocalStorageTokenToSignInAction({ commit }) {
  if (!isTokenFromLocalStorageValid()) {
    return;
  }

  const token = getToken();
  commit(types.LOCAL_STORAGE_TOKEN_LOG_IN, token);
}
