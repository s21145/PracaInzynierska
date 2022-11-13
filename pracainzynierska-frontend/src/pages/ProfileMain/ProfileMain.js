import React from "react";
import "./ProfileMain.css";
import ProfileMainSettings from "./ProfileMainSubPages/ProfileMainSettings";
import ProfileMainGames from "./ProfileMainSubPages/ProfileMainGames";
import ProfileMainStarter from "./ProfileMainSubPages/ProfileMainStarter";
import { useContext } from "react";
import { UserContext } from "../../Services/UserContext";

function ProfileMain() {
  const { user } = useContext(UserContext);

  return (
    <div className="profile-wrapper">
      <div className="profile-main-sidebar">
        <div className="profile-sidebar-picture-name">
          <div className="profile-sidebar-picture-wrapper">
            <div
              className="profile-sidebar-picture"
              style={{
                backgroundImage: `url(data:image/png;base64,${
                  user && user.image
                })`,
              }}
            ></div>
          </div>
          <div className="profile-sidebar-name">{user && user.login}</div>
        </div>

        <div className="profile-sidebar-buttons">
          <button className="profile-sidebar-button">MAIN PROFILE</button>
          <button className="profile-sidebar-button">GAMES</button>
          <button className="profile-sidebar-button">SETTINGS</button>
        </div>
      </div>
      <div className="profile-main-content-area">
        {/*<ProfileMainSettings />*/}
        {/*<ProfileMainGames />*/}
        <ProfileMainStarter />
      </div>
    </div>
  );
}

export default ProfileMain;
