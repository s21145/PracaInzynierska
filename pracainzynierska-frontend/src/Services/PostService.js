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
  setAuthorization();
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
export async function sendComment(postId,content) {
  try {
    var body = {
      content:content,
      IdPost:postId
    }
    const response = await http.post(
      config.apiUrl + "/Post/comment",
      body,
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
export async function createPost(title,content,userLogin,gameName) {
  try {
    var body = {
      title:title,
      content:content,
      userLogin:userLogin,
      gameName:gameName
    }
    const response = await http.post(
      config.apiUrl + "/Post/post",
      body,
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