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
        userId:response.data.userId
      });
      closeModal(false);
    }
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    const response = await RegisterUser(register);
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
        <div className="modal-select-auth-signup">
          <div className="modal-auth">
            <button
              className={`modal-button ${isLoginModal ? "active" : ""}`}
              onClick={() => setIsLoginModal(true)}
            >
              Log In
            </button>
          </div>
          <div className="modal-auth">
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
          <div className="modal-auth-body">
            <label className="auth-form-title-label">Welcome Back!</label>
            <div className="modal-auth-form-wrapper">
              <form className="modal-auth-form" onSubmit={handleLogin}>
                <div className="modal-auth-form-fields">
                  <label className="auth-form-label">Nickname</label>
                  <input
                    name="login"
                    value={login.login}
                    onChange={(e) => handleInputChange(e, setLogin)}
                    placeholder="Email"
                    className="auth-form-input"
                  ></input>
                  <label className="auth-form-label">Password</label>
                  <input
                    placeholder="Password"
                    className="auth-form-input"
                    name="password"
                    type="password"
                    value={login.password}
                    onChange={(e) => handleInputChange(e, setLogin)}
                  ></input>
                  <div className="groupper">
                    <input type="checkbox" />{" "}
                    <label className="auth-form-label">Remember me!</label>
                  </div>
                </div>
                <button type="submit" id="submit-button" className="auth-form-button">
                  Log In
                </button>
              </form>
            </div>
          </div>
        ) : (
          <div className="modal-auth-body">
            <div className="modal-auth-form-wrapper">
              <form className="modal-auth-form" onSubmit={handleRegister}>
                <div className="modal-auth-form-fields">
                  <label className="auth-form-label">Email</label>
                  <input
                    name="email"
                    value={register.email}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    placeholder="Please enter your email."
                    className="auth-form-input"
                  ></input>
                  <label className="auth-form-label">Date of birth</label>
                  <input
                    name="birthday"
                    value={register.birthday}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    type="date"
                    placeholder="DateOfBirth"
                    className="auth-form-input"
                  ></input>
                  <label className="auth-form-label">Nickname</label>
                  <input
                    name="login"
                    value={register.login}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    placeholder="Please enter your nickname."
                    className="auth-form-input"
                  ></input>
                  <label className="auth-form-label">Password</label>
                  <input
                    name="password"
                    value={register.password}
                    onChange={(e) => handleInputChange(e, setRegister)}
                    placeholder="Please enter your password."
                    className="auth-form-input"
                  ></input>
                </div>
                <button type="submit" id="submit-button" className="auth-form-button">
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
