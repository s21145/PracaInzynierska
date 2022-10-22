import "./SignUpModal.css";
import LogInModal from "../LogInModal/LogInModal";
import { useState } from "react";
import React from "react";
import { RegisterUser } from "../../Services/UserService";

function SignUpModal({ closeSignUpModal }) {
  const [register, setRegister] = useState({
    email: "",
    password: "",
    login: "",
    birthday: "",
  });
  const handleRegister = async (e) => {
    e.preventDefault();
    const response = await RegisterUser(register);
    console.log(response);
    if (response.status !== 200) {
      // bad register
      console.log("bad");
      console.log(response.data);
    } else {
      // successful register
      console.log("successful");
    }
  };
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setRegister((prevRegister) => ({
      ...prevRegister,
      [name]: value,
    }));
  };
  const [openLoginModal, setOpenLoginModal] = useState(false);
  const [openSignupModal, setOpenSignupModal] = useState(false);
  return (
    <div className="modal-background">
      {openLoginModal && <LogInModal closeLogInModal={setOpenLoginModal} />}
      <div className="modal-container">
        <div className="modal-close-button">
          <div className="modal-title">E-MATES</div>
          <button
            className="modal-close-mark"
            onClick={() => closeSignUpModal(false)}
          >
            <i className="fa-solid fa-xmark" />
          </button>
        </div>
        <div className="modal-select-login-signup">
          <div className="modal-login">
            <button
              className="modal-login-button"
              onClick={() => {
                setOpenLoginModal(true);
                closeSignUpModal(false);
              }}
            >
              Log In
            </button>
          </div>
          <div className="modal-login">
            <button
              className="modal-signup-button"
              onClick={() => {
                setOpenSignupModal(true) && closeSignUpModal(false);
              }}
            >
              Sign Up
            </button>
          </div>
        </div>
        <hr></hr>
        <div className="modal-signup-body">
          <div className="modal-signup-form-wrapper">
            <form
              className="modal-signup-form"
              onSubmit={(e) => handleRegister(e)}
            >
              <div className="modal-signup-form-fields">
                <label className="signup-form-label">Email</label>
                <input
                  name="email"
                  value={register.email}
                  onChange={(e) => handleInputChange(e)}
                  placeholder="Please enter your email."
                  className="signup-form-input"
                ></input>
                <label className="signup-form-label">Date of birth</label>
                <input
                  name="birthday"
                  value={register.birthday}
                  onChange={(e) => handleInputChange(e)}
                  type="date"
                  placeholder="DateOfBirth"
                  className="signup-form-input"
                ></input>
                <label className="signup-form-label">Nickname</label>
                <input
                  name="login"
                  value={register.login}
                  onChange={(e) => handleInputChange(e)}
                  placeholder="Please enter your nickname."
                  className="signup-form-input"
                ></input>
                <label className="signup-form-label">Password</label>
                <input
                  name="password"
                  value={register.password}
                  onChange={(e) => handleInputChange(e)}
                  placeholder="Please enter your password."
                  className="signup-form-input"
                ></input>
              </div>
              <button
                type="submit"
                id="submit-button"
                className="signup-form-button"
              >
                Sign Up
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default SignUpModal;
