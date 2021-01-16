import * as types from "./types";
import { loginUserAxios } from "@/auth/auth.service";

export async function loginUserAction({ commit }, payload) {
  try {
    const { data } = await loginUserAxios(payload);
    commit(types.LOGIN_USER, data.token);
  } catch (e) {}
}
