import React, { useState } from 'react';
import './GamesDropdown.css';

function GamesDropdown({selected, setSelected}) {

    const [isActive, setIsActive] = useState(false)
    const temporaryOptions = ['Counter Strike: Global Offensive', 'Rust', 'Destiny 2','Rocket League','Random game','rnd game 2'];

  return (
    <div className="dropdown-container">
        <div className="dropdown-wrapper">
            <i class="fa-solid fa-magnifying-glass" id="magnifying-glass"></i>
            <div className="dropdown">
                <div className="dropdown-button" onClick={e => setIsActive(!isActive)}>{selected}<i className="fa-solid fa-angle-down" id='arrow-down' /></div>
                {isActive && (<div className="dropdown-content">
                    {temporaryOptions.map(temporaryOption => (
                        <div className="dropdown-item" onClick={e => {
                            setSelected(temporaryOption)
                            setIsActive(false)
                        }}>
                            {temporaryOption}
                        </div>
                    ))}
                </div>
                )}
                
            </div>
        </div>
    </div>
  )
}

export default GamesDropdown
