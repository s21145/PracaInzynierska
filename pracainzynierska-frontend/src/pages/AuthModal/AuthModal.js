import React, { useState, useContext } from "react";
import { Login, RegisterUser, GetFriendsList, GetFriendsListRequests } from "../../Services/UserService";
import { UserContext } from "../../Services/UserContext";
import { MessageContext } from "../../Services/MessageContext";
import { useLoader } from "../../Services/LoaderContext";
import MessageModal from "../../components/MessageModal";
import "./AuthModal.css";


function AuthModal({ closeModal, initialMode,onLogin }) {
  const { user, setUser } = useContext(UserContext);
  const { message, setMessage } = useContext(MessageContext);
  const { startLoading, stopLoading} = useLoader();
  const [isLoginModal, setIsLoginModal] = useState(initialMode === "login");
  const [loginErrors, setLoginErrors] = useState({});
  const [registerErrors, setRegisterErrors] = useState({});
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

  const validateLogin = () => {
    const errors = {};
    if(!login.login) errors.login = "Nickname is required.";
    if(!login.password) errors.password = "Password is required."

    setLoginErrors(errors);
    return Object.keys(errors).length === 0;
  }

  const validateRegister = () => {
    const errors = {};
    if (!register.email) errors.email = "Email is required.";
    else if (!/\S+@\S+\.\S+/.test(register.email)) errors.email = "Invalid email address.";
    if (!register.login) errors.login = "Nickname is required.";
    if (!register.password) errors.password = "Password is required.";
    else if (register.password.length < 6) errors.password = "Password must be at least 6 characters.";
    if (!register.birthday) errors.birthday = "Date of birth is required.";
    setRegisterErrors(errors);
    return Object.keys(errors).length === 0;
  };

  const handleLogin = async (e) => {
    e.preventDefault();
    startLoading();
    try{
      if(!validateLogin()) return;
      const response = await Login(login);
      const friends = await GetFriendsList();
      const requests = await GetFriendsListRequests();
      if (response.status !== 200) {
        setMessage({
          content: "Login failed. Please check your credentials and try again.",
          show: true,
        });
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
        onLogin();
      }
    }
    catch(err){

    }
    finally{
      stopLoading();
      onLogin();
    }
    
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    startLoading();
    try{
      if(!validateRegister()) return;

      const response = await RegisterUser(register);
      if (response.status !== 200) {
        setMessage({
          content: "Registration failed. Please check your input and try again.",
          show: true,
        });
      } else {
        setMessage({
          content: "Account created successfully! You can now log in.",
          show: true,
        });
        setIsLoginModal(true);
      }
    }
    catch(err){

    }
    finally{
      stopLoading();
    }
  };

  const handleInputChange = (e, setState, setErrors) => {
    const { name, value } = e.target;
    setState((prevState) => ({
      ...prevState,
      [name]: value,
    }));
    setErrors((prevErrors) => ({
      ...prevErrors,
      [name]: "", 
    }));
  };

  return (
    <>
      {message && message.show && <MessageModal />}
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
                    <label className="auth-form-label">Login</label>
                    <input
                      name="login"
                      value={login.login}
                      onChange={(e) => handleInputChange(e, setLogin, setLoginErrors)}
                      placeholder={loginErrors.login || "Login"}
                      className={`auth-form-input ${loginErrors.login ? "input-error" : ""}`}
                      style={{
                        "--placeholder-color": loginErrors.login ? "red" : "gray",
                      }}
                    ></input>
                    <label className="auth-form-label">Password</label>
                    <input
                      name="password"
                      type="password"
                      value={login.password}
                      onChange={(e) => handleInputChange(e, setLogin, setLoginErrors)}
                      placeholder={loginErrors.password || "Password"}
                      className={`auth-form-input ${loginErrors.password ? "input-error" : ""}`}
                      style={{
                        "--placeholder-color": loginErrors.login ? "red" : "gray",
                      }}
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
                      className={`auth-form-input ${registerErrors.email ? "input-error" : ""}`}
                      style={{
                        "--placeholder-color": registerErrors.email ? "red" : "gray",
                      }}
                    ></input>
                    <label className="auth-form-label">Date of birth</label>
                    <input
                      name="birthday"
                      value={register.birthday}
                      onChange={(e) => handleInputChange(e, setRegister)}
                      type="date"
                      className={`auth-form-input ${registerErrors.birthday ? "input-error" : ""}`}
                      style={{
                        "--placeholder-color": registerErrors.birthday ? "red" : "gray",
                      }}
                    ></input>
                    <label className="auth-form-label">Nickname</label>
                    <input
                      name="login"
                      value={register.login}
                      onChange={(e) => handleInputChange(e, setRegister)}
                      placeholder="Please enter your nickname."
                      className={`auth-form-input ${registerErrors.login ? "input-error" : ""}`}
                      style={{
                        "--placeholder-color": registerErrors.login ? "red" : "gray",
                      }}
                    ></input>
                    <label className="auth-form-label">Password</label>
                    <input
                      name="password"
                      type="password"
                      value={register.password || ""}  
                      onChange={(e) => handleInputChange(e, setRegister)}
                      placeholder="Enter your password"
                      className={`auth-form-input ${registerErrors.password ? "input-error" : ""}`}
                      style={{
                        "--placeholder-color": registerErrors.password ? "red" : "gray",
                      }}
                    />
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
    </>
  );
}

export default AuthModal;
