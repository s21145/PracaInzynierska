import React from "react";
import "./ProfileMain.css";
import ProfileMainSettings from "./ProfileMainSubPages/ProfileMainSettings";
import ProfileMainGames from "./ProfileMainSubPages/ProfileMainGames";
import ProfileMainStarter from "./ProfileMainSubPages/ProfileMainStarter";
import ProfileMainGamesStarter from "./ProfileMainSubPages/ProfileMainGamesStarter";
import { useContext } from "react";
import { UserContext } from "../../Services/UserContext";
import { useState } from "react";
import { MessageContext } from "../../Services/MessageContext";
import MessageModal from "../../components/MessageModal";
import { useSearchParams } from "react-router-dom";
import { useEffect } from "react";
import GameModal from "./ProfileMainSubPages/GameStatistics/GameModal";
import { statModalContext } from "../../Services/StatsModalContext";
import FriendsList from "../FriendsList/FriendsList";

function ProfileMain() {
  const { user } = useContext(UserContext);
  const [profile, setProfile] = useState(0);
  const { message } = useContext(MessageContext);
  const [searchParams] = useSearchParams();
  const [openGameModal, setOpenGameModal] = useState(false);
  const { statModal } = useContext(statModalContext);

  useEffect(() => {
    const tab = searchParams.get("tab");
    if (tab === "settings") {
      setProfile(2);
    } else if (tab === "games") {
      setProfile(1);
    } else {
      setProfile(0); 
    }
  }, [searchParams]);

  return (
    <div className="profile-wrapper">
      {message && message.show && <MessageModal />}
      {statModal && statModal.show && <GameModal />}
      {openGameModal && <GameModal closeGameModa={setOpenGameModal} />}

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
          <button
            className="profile-sidebar-button"
            onClick={() => setProfile(0)}
          >
            MAIN PROFILE
          </button>
          <button
            className="profile-sidebar-button"
            onClick={() => setProfile(1)}
          >
            GAMES
          </button>
          <button
            className="profile-sidebar-button"
            onClick={() => setProfile(2)}
          >
            SETTINGS
          </button>
        </div>
      </div>
      <div className="profile-main-content-area">
        {profile === 2 && <ProfileMainSettings />}
        {profile === 1 && (
          <ProfileMainGamesStarter profileChanger={setProfile} />
        )}
        {profile === 3 && <ProfileMainGames profileChanger={setProfile} />}
        {profile === 0 && <ProfileMainStarter />}
      </div>
    </div>
  );
}

export default ProfileMain;
