import api from "@/api/api-v1-config";

export async function loginUserAxios(login) {
  return await api.post("Users/auth", login);
}
