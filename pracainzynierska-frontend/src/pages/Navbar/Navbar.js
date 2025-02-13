import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import ProfileDropdown from "../ProfileDropdown/ProfileDropdown";
import "./Navbar.css";
import { UserContext } from "../../Services/UserContext";
import { useContext } from "react";
import AuthModal from "../AuthModal/AuthModal";

function Navbar({onLogin}) {
  const { user } = useContext(UserContext);

  const [click, setClick] = useState(false);
  const [button, setButton] = useState(true);
  const [profile, setProfile] = useState(false);
  const [leaveTimeout, setLeaveTimeout] = useState(null);

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

  const handleMouseEnter = () => {
    if (leaveTimeout) clearTimeout(leaveTimeout);
    setProfile(true);
  };

  const handleMouseLeave = () => {
    const timeout = setTimeout(() => {
      setProfile(false);
    }, 200);
    setLeaveTimeout(timeout);
  };

  useEffect(() => {
    showButton();
  }, []);

  window.addEventListener("resize", showButton);

  return (
    <>
      {openLoginModal && <AuthModal closeModal={setOpenLoginModal} onLogin={onLogin}initialMode="login" />}
      {openSignupModal && <AuthModal closeModal={setOpenSignupModal} initialMode="signup" />}
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
                  to="/ProfileMain"
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
            {window.innerWidth <= 960 ? (
              <li className="nav-item">
                <Link
                  to="/ProfileMain?tab=settings"
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
              className="profile-area"
              onMouseEnter={handleMouseEnter}
              onMouseLeave={handleMouseLeave}
            >
              <div className="profile-link">
                <div
                  className="nav-picture"
                  style={{
                    backgroundImage: `url(data:image/png;base64,${
                      user && user.image
                    })`,
                  }}
                ></div>
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
