import React from "react";
import "./Main.css";
import { useState } from "react";
import league from "../../assets/resources/lol-icon.jpg";
import csgo from "../../assets/resources/csgo-icon.jpg";
import valorant from "../../assets/resources/valorant-icon.jpg";
import LogInModal from "../LogInModal/LogInModal";
import SignUpModal from "../SignUpModal/SignUpModal";
import MessageModal from "../../components/MessageModal";

function Main() {
  const [openLoginModal, setOpenLoginModal] = useState(false);
  const [openSignupModal, setOpenSignupModal] = useState(false);

  return (
    <div className="main-page-container">
      {openLoginModal && <LogInModal closeLogInModal={setOpenLoginModal} />}
      {openSignupModal && <SignUpModal closeSignUpModal={setOpenSignupModal} />}
      <div className="main-page-signup">
        Search for new people to play with, <br />
        find your perfect teammates and <br />
        NEVER play solo again <br />
        <button
          className="signup-button"
          onClick={() => {
            setOpenSignupModal(true);
          }}
        >
          Sign Up Here!
        </button>
        <br />
        Already a member?
        <button
          className="login-button"
          onClick={() => {
            setOpenLoginModal(true);
          }}
        >
          Log in here!
        </button>
      </div>
      <div className="main-page-games">
        <img src={league} />
        <img src={valorant} />
        <img src={csgo} />
      </div>
    </div>
  );
}

export default Main;
