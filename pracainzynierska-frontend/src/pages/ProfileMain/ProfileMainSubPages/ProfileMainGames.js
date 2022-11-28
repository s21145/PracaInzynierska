import React from 'react';
import './ProfileMainGames.css';

function ProfileMainGames() {

  return (
    <div className="profile-games-wrapper">
        <div className="profile-games-return-button">
            <i class="fa-sharp fa-solid fa-arrow-left" />
        </div>
        <div className="profile-games-container">
            <button className="game-icon-button" id="leagueoflegends">
            </button>
            <button className="game-icon-button" id="countestrikeglobaloffensive">
            </button>
            <button className="game-icon-button" id="rust">
            </button>       
        </div>
    </div>
  )
}

export default ProfileMainGames
