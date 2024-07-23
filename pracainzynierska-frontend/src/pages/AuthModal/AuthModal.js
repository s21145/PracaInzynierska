import React, { useState, useContext } from "react";
import { Login, RegisterUser, GetFriendsList, GetFriendsListRequests } from "../../Services/UserService";
import { UserContext } from "../../Services/UserContext";
import "./AuthModal.css";

function AuthModal({ closeModal, initialMode }) {
  const { user, setUser } = useContext(UserContext);
  const [isLoginModal, setIsLoginModal] = useState(initialMode === "login");

  const [login, setLogin] = useState({
    password: "",
    login: "",
  });

  const [register, setRegister] = useState({
    email: "",
    password: "",
    login: "",
    birthday: "",
  });

  const handleLogin = async (e) => {
    e.preventDefault();
    const response = await Login(login);
    const friends = await GetFriendsList();
    const requests = await GetFriendsListRequests();
    if (response.status !== 200) {
      console.log("bad");
      console.log(response.data);
    } else {
      const age = new Date(response.data.age);
      setUser({
        login: response.data.login,
        image: response.data.image,
        steamId: response.data.steamId,
        age: age,
        description: response.data.description,
        friends: friends.data,
        requests: requests.data,
      });
      closeModal(false);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    const response = await RegisterUser(register);
    console.log(response);
    if (response.status !== 200) {
      console.log("bad");
      console.log(response.data);
    } else {
      console.log("successful");
    }
  };

  const handleInputChange = (e, setState) => {
    const { name, value } = e.target;
    setState((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  return (
    <div className="modal-background">
      <div className="modal-container">
        <div className="modal-close-button">
          <div className="modal-title">E-MATES</div>
          <button className="modal-close-mark" onClick={() => closeModal(false)}>
            <i className="fa-solid fa-xmark" />
          </button>
        </div>
        <div className="modal-select-login-signup">
          <div className="modal-login">
            <button
              className={`modal-button ${isLoginModal ? "active" : ""}`}
              onClick={() => setIsLoginModal(true)}
            >
              Log In
            </button>
          </div>
          <div className="modal-login">
            <button
              className={`modal-button ${!isLoginModal ? "active" : ""}`}
              onClick={() => setIsLoginModal(false)}
            >
              Sign Up
            </button>
          </div>
        </div>
        <hr />
        {isLoginModal ? (
          <div className="modal-login-body">
            <label className="login-form-title-label">Welcome Back!</label>
            <div className="modal-login-form-wrapper">
              <form className="modal-login-form" onSubmit={handleLogin}>
                <div className="modal-login-form-fields">
                  <label className="login-form-label">Email</label>
                  <input
                    name="login"
                    value={login.login}
                    onChange={(e) => handleInputChange(e, setLogin)}
                    placeholder="Email"
                    className="login-form-input"
                  ></input>
                  <label className="login-form-label">Password</label>
                  <input
                    placeholder="Password"
                    className="login-form-input"
                    name="password"
                    value={login.password}
                    onChange={(e) => handleInputChange(e, setLogin)}
                  ></input>
                  <div className="groupper">
                    <input type="checkbox" />{" "}
                    <label className="login-form-label">Remember me!</label>
                  </div>
                </div>
                <button type="submit" id="submit-button" className="login-form-button">
                  Log In
                </button>
              </form>
            </div>
          </div>
        ) : (
          <div className="modal-signup-body">
            <div className="modal-signup-form-wrapper">
              <form className="modal-signup-form" onSubmit={handleRegister}>
                <div className="modal-signup-form-fields">
                  <label className="signup-form-label">Email</label>
                  <input
                    name="email"
                    value={register.email}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    placeholder="Please enter your email."
                    className="signup-form-input"
                  ></input>
                  <label className="signup-form-label">Date of birth</label>
                  <input
                    name="birthday"
                    value={register.birthday}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    type="date"
                    placeholder="DateOfBirth"
                    className="signup-form-input"
                  ></input>
                  <label className="signup-form-label">Nickname</label>
                  <input
                    name="login"
                    value={register.login}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    placeholder="Please enter your nickname."
                    className="signup-form-input"
                  ></input>
                  <label className="signup-form-label">Password</label>
                  <input
                    name="password"
                    value={register.password}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    placeholder="Please enter your password."
                    className="signup-form-input"
                  ></input>
                </div>
                <button type="submit" id="submit-button" className="signup-form-button">
                  Sign Up
                </button>
              </form>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}

export default AuthModal;
