import React from "react";
import "./ProfileMainStarter.css";
import { UserContext } from "../../../Services/UserContext";
import { useContext } from "react";

function ProfileMainStarter() {
  const { user } = useContext(UserContext);
  return (
    <div className="profile-container">
      <div className="input-section">
        <div className="input-wrapper">
          <label htmlFor="age" className="input-label">Age</label>
          <div className="input-field">{user && user.age && user.age.toLocaleDateString("en-GB")}</div>
        </div>

        <div className="input-wrapper">
          <label htmlFor="steam" className="input-label">Steam ID</label>
          <div className="input-field">{user && user.steamId}</div>
        </div>

        <div className="input-wrapper">
          <label htmlFor="discord" className="input-label">Discord</label>
          <div className="input-field"></div>
        </div>
      </div>

      <div className="description-section">
        <label htmlFor="description" className="description-label">Description</label>
        <div className="description-box">{user && user.description}</div>
      </div>
    </div>
  );
}

export default ProfileMainStarter;
