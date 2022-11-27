import React from 'react';
import './ProfileMainGames.css';
import { useState } from "react";
import GameModal from "./GameStatistics/GameModal"

function ProfileMainGames() {

  return (
    <div className="profile-games-wrapper">
        <div className="profile-games-container">
            <button className="game-button" id="leagueoflegends">
            </button>
            <button className="game-button" id="countestrikeglobaloffensive">
            </button>
            <button className="game-button" id="rust">
            </button>       
        </div>
        <div className="profile-games-add-game">
          <button className='add-game-button'>Add new game</button>
        </div>
    </div>
  )
}

export default ProfileMainGames
