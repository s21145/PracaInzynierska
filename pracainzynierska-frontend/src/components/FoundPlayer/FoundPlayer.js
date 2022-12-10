import React from 'react';
import './FoundPlayer.css';


const FoundPlayer = () => {
  return (
    <div className="found-player">
        <div className="found-player-container">
            <div className="found-player-title">
                <div className="found-player-picture">
                    
                </div>
                <div className="found-player-name">
                    <div className="found-player-nickname">
                        Garogarogaro
                    </div>
                    <div className="found-player-age">
                        Age: 24
                    </div>
                    <div className="found-player-country">
                        Country: Pooland
                    </div>
                </div>
            </div>
            <div className="found-player-bio">
                bio 
            </div>
            <div className="found-player-buttons">
                <button className="found-player-button">PROFILE</button>
                <button className="found-player-button">ADD</button>
            </div>
        </div>
    </div>
  )
}

export default FoundPlayer
