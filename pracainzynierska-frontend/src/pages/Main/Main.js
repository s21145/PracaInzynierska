import React from "react";
import "./Main.css";
import { useState, useEffect } from "react";
import league from "../../assets/resources/lol-icon.jpg";
import csgo from "../../assets/resources/csgo-icon.jpg";
import valorant from "../../assets/resources/valorant-icon.jpg";
import LogInModal from "../LogInModal/LogInModal";
import SignUpModal from "../SignUpModal/SignUpModal";
import MessageModal from "../../components/MessageModal";
import { Logout } from "../../Services/UserService";
import { useSearchParams } from "react-router-dom";
import { useContext } from "react";
import { UserContext } from "../../Services/UserContext";
function Main() {
  const [openLoginModal, setOpenLoginModal] = useState(false);
  const [openSignupModal, setOpenSignupModal] = useState(false);
  const { user, setUser } = useContext(UserContext);

  const [searchParams, setSearchParamas] = useSearchParams();
  useEffect(() => {
    handleLogout();
  }, [searchParams]);

  const handleLogout = () => {
    const logout = searchParams.get("logout");
    searchParams.delete("logout");
    setSearchParamas(searchParams);
    if (logout) {
      Logout();
      setUser({
        login: "",
        image: "",
        steamId: null,
        age: "",
        description: "",
      });
      console.log(user);
      console.log("KONIEC");
      window.location.reload();
    }
  };

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
