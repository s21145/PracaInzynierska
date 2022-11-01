import config from "../config.json";
import http from "../Services/HttpService";
//import jwtDecode from "jwt-decode";

export async function RefreshToken() {
  var refreshToken = GetRefreshToken();
  try {
    const response = await http.post(
      config.apiUrl + "Login/refresh",
      {},
      {
        params: { token: refreshToken },
      },
      {
        headers: {
          "Content-type": "application/json",
        },
      }
    );
    const userData = {
      refreshToken: refreshToken,
      accessToken: response.data.accessToken,
    };
    localStorage.setItem("userData", JSON.stringify(userData));
    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}

export async function LoginAfterReload() {
  var refreshToken = GetRefreshToken();
  try {
    const response = await http.get(
      config.apiUrl + "Login/reload",
      {
        params: { refreshToken: refreshToken },
      },
      {
        headers: {
          "Content-type": "application/json",
        },
      }
    );
    const userData = {
      accessToken: response.data.accessToken,
      refreshToken: response.data.refreshToken,
    };
    localStorage.setItem("userData", JSON.stringify(userData));

    return response;
  } catch (error) {
    const response = {
      status: error.response.status,
      data: error.response.data,
    };
    return response;
  }
}

export async function RegisterUser(user) {
  const req = JSON.stringify({
    login: user.login,
    password: user.password,
    email: user.email,
    birthday: user.birthday,
  });
  console.log(req);
  try {
    const response = await http.post(config.apiUrl + "Login/register", req, {
      headers: {},
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
    const response = await http.post(config.apiUrl + "Login/login", req, {
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
    if (userData === null) {
      return null;
    }

    return 0;//jwtDecode(userData);
  } catch (error) {
    return {};
  }
}

export function GetRefreshToken() {
  try {
    const userData = JSON.parse(localStorage.getItem("userData"));
    if (userData === null) {
      return null;
    }
    return userData.refreshToken;
  } catch (error) {
    return {};
  }
}
