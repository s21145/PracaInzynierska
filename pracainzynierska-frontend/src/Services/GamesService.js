import config from "../config.json";
import http from "../Services/HttpService";
import jwtDecode from "jwt-decode";
import { setAuthorization } from "../Services/HttpService";

export async function GetUserGames() {
  try {
    const response = await http.get(config.apiUrl + "/Game/myGames", {
      headers: {
        "Content-type": "application/json",
      },
    });
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}

export async function GetMissingGamesUser() {
  try {
    const response = await http.get(config.apiUrl + "/Game/missing", {
      headers: {
        "Content-type": "application/json",
      },
    });
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}
export async function AddGame(gameId) {
  try {
    const response = await http.post(config.apiUrl + "/User/addGame", gameId, {
      headers: {
        "Content-type": "application/json",
      },
    });
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}
