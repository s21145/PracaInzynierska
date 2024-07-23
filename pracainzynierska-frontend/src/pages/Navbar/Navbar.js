import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import ProfileDropdown from "../ProfileDropdown/ProfileDropdown";
import "./Navbar.css";
import { UserContext } from "../../Services/UserContext";
import { useContext } from "react";
import AuthModal from "../AuthModal/AuthModal";

function Navbar() {
  const { user } = useContext(UserContext);

  const [click, setClick] = useState(false);
  const [button, setButton] = useState(true);
  const [profile, setProfile] = useState(false);

  const handleClick = () => setClick(!click);
  const closeMobileMenu = () => setClick(false);
  const openProfileMenu = () => setProfile(true);

  const [openLoginModal, setOpenLoginModal] = useState(false);
  const [openSignupModal, setOpenSignupModal] = useState(false);

  const showButton = () => {
    if (window.innerWidth <= 960) {
      setButton(false);
    } else {
      setButton(true);
    }
  };

  const onMouseLeave = () => {
    if (window.innerWidth < 960) {
      setProfile(false);
    } else {
      setProfile(false);
    }
  };

  useEffect(() => {
    showButton();
  }, []);
  window.addEventListener("resize", showButton);

  return (
    <>
      {openLoginModal && <AuthModal closeModal={setOpenLoginModal} initialMode="login" />}
      {openSignupModal && <AuthModal closeModal={setOpenLoginModal} initialMode="signup" />}
      <nav className="navbar">
        <div className="navbar-container">
          <Link to="/" className="navbar-logo" onClick={closeMobileMenu}>
            E-MATES<i className="fa-solid fa-gamepad"></i>
          </Link>
          <div className="menu-icon" onClick={handleClick}>
            <i className={click ? "fas fa-times" : "fas fa-bars"} />
          </div>
          <ul className={click ? "nav-menu active" : "nav-menu"}>
            {window.innerWidth <= 960 ? (
              <li className="nav-item">
                <Link
                  to="/contact"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  Your Profile
                </Link>
              </li>
            ) : null}
            {user && (
              <li className="nav-item">
                <Link
                  to="/e-mates"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  E-MATES
                </Link>
              </li>
            )}
            {user && (
              <li className="nav-item">
                <Link
                  to="/findplayers"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  FIND PLAYERS
                </Link>
              </li>
            )}
            {user && (
              <li className="nav-item">
                <Link
                  to="/posts"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  POSTS
                </Link>
              </li>
            )}
            {user && (
              <li className="nav-item">
                <Link
                  to="/contact"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  CONTACT
                </Link>
              </li>
            )}
            {window.innerWidth <= 960 ? (
              <li className="nav-item">
                <Link
                  to="/contact"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  Settings
                </Link>
              </li>
            ) : null}
            {window.innerWidth <= 960 ? (
              <li className="nav-item">
                <Link
                  to="/contact"
                  className="nav-links"
                  onClick={closeMobileMenu}
                >
                  Sign out
                </Link>
              </li>
            ) : null}
          </ul>
          {!user && window.innerWidth > 960 ? (
            <div className="navbar-login-signup-buttons">
              <div className="tmp">
                <button
                  className="log-in-button"
                  onClick={() => {
                    setOpenLoginModal(true);
                  }}
                >
                  Log In
                </button>
              </div>
              <div className="tmp">
                <button
                  className="sign-in-button"
                  onClick={() => {
                    setOpenSignupModal(true);
                  }}
                >
                  Sign In
                </button>
              </div>
            </div>
          ) : null}
          {user && window.innerWidth > 960 ? (
            <div
              className="profile-span"
              onClick={openProfileMenu}
              onMouseLeave={onMouseLeave}
            >
              <div className="profile-link">
                <div className="testtest"> </div>
                <h2 className="profile-wrap">{user && user.login}</h2>
              </div>

              {profile && <ProfileDropdown />}
            </div>
          ) : null}
        </div>
      </nav>
    </>
  );
}

export default Navbar;

/*

*/
