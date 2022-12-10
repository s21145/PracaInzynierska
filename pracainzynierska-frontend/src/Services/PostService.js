import config from "../config.json";
import http from "../Services/HttpService";
import jwtDecode from "jwt-decode";
import { setAuthorization } from "../Services/HttpService";

export async function getPosts(gameName) {
  try {
    const response = await http.get(
      config.apiUrl + "/Post/posts",
      { params: { gameName: gameName, page: 0 } },
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

export async function getGames() {
  try {
    const response = await http.get(config.apiUrl + "/Game/games", {
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
export async function getPostWithComments(postId) {
  try {
    const response = await http.get(
      config.apiUrl + "/Post/post",
      { params: { id: postId } },
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
