import React from 'react';
import './ProfileMainGames.css';

function ProfileMainGames({profileChanger, ...rest}) {

  return (
    <div className="profile-games-wrapper">
        <div className="profile-games-return-button">
            <i class="fa-sharp fa-solid fa-arrow-left" onClick={() => profileChanger(1)}/>
        </div>
        <div className="profile-games-container">
            <button className="game-icon-button" id="leagueoflegends" onClick={() => gameStats(true)}>
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
