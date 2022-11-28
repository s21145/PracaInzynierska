import React from 'react'
import './ProfileMainGamesStarter.css'

function ProfileMainGamesStarter() {
  return (
    <div className="profile-games-wrapper">
        <div className="profile-games-container">
            <button className="game-add-button">
                <i class="fa-solid fa-plus" />
                Add game
            </button>
            <button className="game-button" id="leagueoflegends">
            </button>
            <button className="game-button" id="countestrikeglobaloffensive">
            </button>
            <button className="game-button" id="rust">
            </button>       
        </div>
    </div>
  )
}

export default ProfileMainGamesStarter
