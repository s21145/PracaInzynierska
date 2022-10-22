import config from "../config.json";
import http from "../Services/HttpService";
import jwtDecode from "jwt-decode";

export async function RegisterUser(user) {
  const req = JSON.stringify({
    login: user.login,
    password: user.password,
    email: user.email,
    birthday: user.birthday,
  });
  console.log(req);
  try {
    const response = await http.post(config.apiUrl + "register", req, {
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

export async function Login(credentials) {
  const req = JSON.stringify({
    login: credentials.login,
    password: credentials.password,
  });
  console.log(req);
  try {
    const response = await http.post(config.apiUrl + "login", req, {
      headers: {
        "Content-type": "application/json",
      },
    });
    localStorage.setItem("userData", JSON.stringify(response.data));

    //setAuthorization();
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}

export function Logout() {
  localStorage.removeItem("userData");
}

export function GetCurrentUser() {
  try {
    const userData = localStorage.getItem("userData");
    return jwtDecode(userData);
  } catch (error) {
    return {};
  }
}

export function GetRefreshToken() {
  try {
    const userData = JSON.parse(localStorage.getItem("userData"));
    return userData.refreshToken;
  } catch (error) {
    return {};
  }
}
