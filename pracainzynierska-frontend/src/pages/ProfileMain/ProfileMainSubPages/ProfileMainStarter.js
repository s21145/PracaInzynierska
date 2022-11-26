import React from "react";
import "./ProfileMainStarter.css";
import { UserContext } from "../../../Services/UserContext";
import { useContext } from "react";

function ProfileMainStarter() {
  const { user } = useContext(UserContext);
  return (
    <div className="starter-wrapper">
      <div className="starter-bio">
        <div className="starter-bio-text-area">{user && user.description}</div>
      </div>

      <div className="starter-bottom-container">
        <div className="starter-left-side">
          <div className="starter-age-container">
            <div className="starter-age-title">Age:</div>
            <div className="starter-age">
              {user && user.age && user.age.toLocaleDateString("en-GB")}
            </div>
          </div>

          <div className="starter-socials-container">
            <div className="starter-socials-title">Socials:</div>
            <div className="starter-socials">
              <div className="social-steam">
                Steam id:{user && user.steamId}
              </div>
              <div className="social-discord">Discord tag:</div>
            </div>
          </div>
        </div>
        <div className="starter-posts"></div>
      </div>
    </div>
  );
}

export default ProfileMainStarter;
