import React from "react";
import "./GamesDropdownFindPlayers.css";
import { useState, useEffect } from "react";
import { getGames } from "../../Services/PostService";

function GamesDropdown({ selected, setSelected, gameOptions }) {
  const [isActive, setIsActive] = useState(false);

  return (
    <div className="gdfp-dropdown-container">
      <div className="gdfp-dropdown-wrapper">
        <div className="gdfp-dropdown">
          <div
            className="gdfp-dropdown-button"
            onClick={(e) => setIsActive(!isActive)}
          >
            {selected.name}
            <i className="fa-solid fa-angle-down" id="gdfp-arrow-down" />
          </div>
          {isActive && (
            <div className="gdfp-dropdown-content">
              {gameOptions.map((game) => (
                <div
                  key={game.gameId}
                  className="gdfp-dropdown-item"
                  onClick={(e) => {
                    setSelected(game);
                    setIsActive(false);
                  }}
                >
                  {game.name}
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default GamesDropdown;
