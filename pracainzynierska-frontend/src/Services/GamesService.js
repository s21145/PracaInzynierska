import config from "../config.json";
import http from "../Services/HttpService";
import jwtDecode from "jwt-decode";
import { setAuthorization } from "../Services/HttpService";

export async function GetUserGames() {
  setAuthorization();
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
export async function getStats(gameId, userName) {
  try {
    const response = await http.get(
      config.apiUrl + "/User/Stats",
      { params: { idGame: gameId, userName: userName } },
      {
        headers: {
          "Content-type": "application/json",
        },
      }
    );
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}
export async function getSimilarUsers(gameId, page) {
  try {
    const response = await http.get(
      config.apiUrl + "/User/users",
      { params: { Idgame: gameId, page: page } },
      {
        headers: {
          "Content-type": "application/json",
        },
      }
    );
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}
  export async function getUsersByNickname(nickname,page) {
    try {
      const response = await http.get(
        config.apiUrl + "/User/searchForFindPlayers",
        { params: { username: nickname , page:page} },
        {
          headers: {
            "Content-type": "application/json",
          },
        }
      );
      return response;
    } catch (error) {
      const response = {
        status: error.response.status,
        data: error.response.data,
      };
      return response;
    }
  }

