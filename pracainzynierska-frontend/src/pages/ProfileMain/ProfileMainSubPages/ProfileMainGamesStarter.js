import React from 'react'
import './ProfileMainGamesStarter.css'

function ProfileMainGamesStarter({profileChanger, ...rest}) {

  

  return (
    <div className="profile-games-wrapper">
        <div className="profile-games-container">
            <button className="game-add-button" onClick={() => profileChanger(3)}>
                <i class="fa-solid fa-plus" />
                Add game
            </button>
            <button className="game-icon-button" id="leagueoflegends" >
            </button>
            <button className="game-icon-button" id="countestrikeglobaloffensive">
            </button>
            <button className="game-icon-button" id="rust">
            </button>       
        </div>
    </div>
  )
}

export default ProfileMainGamesStarter
