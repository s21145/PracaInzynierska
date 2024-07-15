import axios from "axios";
import { GetJwt } from "./UserService";

export function setAuthorization() {
  axios.defaults.headers.common["Authorization"] = "Bearer " + GetJwt();
}
export function removeAuthorization() {
  delete axios.defaults.headers.common["Authorization"];
}
export default {
  get: axios.get,
  post: axios.post,
  put: axios.put,
  delete: axios.delete,
};
