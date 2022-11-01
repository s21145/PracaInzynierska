import React from 'react';
import "./ProfileMain.css";
import ProfileMainSettings from './ProfileMainSubPages/ProfileMainSettings';
import ProfileMainGames from './ProfileMainSubPages/ProfileMainGames';

function ProfileMain() {
  return (
    <div className="profile-wrapper">
        <div className="profile-main-sidebar">
            <div className="profile-sidebar-picture-name">
                <div className="profile-sidebar-picture-wrapper">
                    <div className="profile-sidebar-picture">
                        
                    </div>
                </div>
                <div className="profile-sidebar-name">
                    Garo
                </div>
            </div>

            <div className="profile-sidebar-buttons">
                <button className="profile-sidebar-button">
                    MAIN PROFILE
                </button>
                <button className="profile-sidebar-button">
                    GAMES
                </button>
                <button className="profile-sidebar-button">
                    SETTINGS
                </button>
            </div>
        </div>
        <div className="profile-main-content-area">
            {/*<ProfileMainSettings></ProfileMainSettings>*/}

            <ProfileMainGames>

            </ProfileMainGames>
        </div>
    </div>
  )
}

export default ProfileMain
