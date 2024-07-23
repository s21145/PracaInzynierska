import React, { useState, useEffect, useContext } from "react";
import "./Main.css";
import league from "../../assets/resources/lol-icon.jpg";
import csgo from "../../assets/resources/csgo-icon.jpg";
import valorant from "../../assets/resources/valorant-icon.jpg";
import AuthModal from "../AuthModal/AuthModal";
import { Logout } from "../../Services/UserService";
import { useSearchParams, Link } from "react-router-dom";
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
      {openLoginModal && <AuthModal closeModal={setOpenLoginModal} initialMode="login" />}
      {openSignupModal && <AuthModal closeModal={setOpenSignupModal} initialMode="signup" />}
      {user == null ? (
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
      ) : (
        <div className="main-page-signup">
          Welcome back {user.login}!<br />
          Search for new teammates <Link to="/findplayers"><button className="login-button">here!</button><br /></Link>
          Or browse all the posts by clicking on the button below! <br />
          <Link to="/posts"><button className="signup-button">Browse posts</button></Link>
        </div>
      )}

      <div className="main-page-games">
        <img src={league} alt="League of Legends" />
        <img src={valorant} alt="Valorant" />
        <img src={csgo} alt="CS:GO" />
      </div>
    </div>
  );
}

export default Main;
