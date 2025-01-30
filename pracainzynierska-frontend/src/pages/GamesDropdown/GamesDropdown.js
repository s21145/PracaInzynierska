import React from "react";
import "./GamesDropdown.css";
import { useState, useEffect } from "react";
import { getGames } from "../../Services/PostService";

function GamesDropdown({ selected, setSelected, gameOptions, resetMaxPage }) {
  const [isActive, setIsActive] = useState(false);

  return (
    <div className="dropdown-container">
      <div className="dropdown-wrapper">
        <i className="fa-solid fa-magnifying-glass" id="magnifying-glass"></i>
        <div className="dropdown">
          <div
            className="dropdown-button"
            onClick={() => setIsActive(!isActive)}
          >
            {selected.name || "Select a game"}
            <i className="fa-solid fa-angle-down" id="arrow-down" />
          </div>
          {isActive && (
            <div className="dropdown-content">
              {gameOptions.map((game) => (
                <div
                  key={game.gameId}
                  className="dropdown-item"
                  onClick={() => {
                    resetMaxPage();
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
