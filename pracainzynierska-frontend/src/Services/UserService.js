import config from "../config.json";
import http from "../Services/HttpService";
import jwtDecode from "jwt-decode";
import { setAuthorization } from "../Services/HttpService";

export async function RefreshToken() {
  var refreshToken = GetRefreshToken();
  try {
    const response = await http.post(
      config.apiUrl + "/Login/refresh",
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
      config.apiUrl + "/Login/reload",
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
    setAuthorization();
    return response;
  } catch (error) {
    console.log(error);
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
    const response = await http.post(config.apiUrl + "/Login/register", req, {
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

  try {
    const response = await http.post(config.apiUrl + "/Login/login", req, {
      headers: {
        "Content-type": "application/json",
      },
    });
    localStorage.setItem("userData", JSON.stringify(response.data));
    setAuthorization();
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

    return jwtDecode(userData);
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

export async function ChangeDescription(description) {
  try {
    const response = await http.post(
      config.apiUrl + "/User/description",
      description,
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
    console.log(response);
    return response;
  }
}
export function GetJwt() {
  const userData = JSON.parse(localStorage.getItem("userData"));
  if (userData === null) {
    return null;
  }
  return userData.accessToken;
}
export async function ChangeEmail(email) {
  try {
    const response = await http.post(config.apiUrl + "/User/email", email, {
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
    console.log(response);
    return response;
  }
}
export async function ChangePassword(oldPassword, newPassword) {
  const req = JSON.stringify({
    oldPassword: oldPassword,
    password: newPassword,
  });

  try {
    const response = await http.post(config.apiUrl + "/User/password", req, {
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

export async function AddSteamId(steamId) {
  const body = `"${steamId}"`;
  try {
    const response = await http.post(config.apiUrl + "/User/steamId", body, {
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
