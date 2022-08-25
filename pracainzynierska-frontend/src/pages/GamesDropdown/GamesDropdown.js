import React from "react";
import "./GamesDropdown.css";
import { useState, useEffect } from "react";
import http from "../../Services/HttpService";
import config from "../../config.json";

function GamesDropdown({ selected, setSelected }) {
  const [isActive, setIsActive] = useState(false);
  const [gameOptions, setGameOptions] = useState([]);
  const temporaryOptions = [
    "Counter Strike: Global Offensive",
    "Rust",
    "Destiny 2",
    "Rocket League",
    "Random game",
    "rnd game 2",
  ];
  async function fetchGames() {
    try {
      const { data } = await http.get(config.apiUrl + "games");
      setGameOptions(data);
    } catch (error) {
      console.log("error: " + error);
    }
  }
  useEffect(() => {
    fetchGames();
  }, []);

  return (
    <div className="dropdown-container">
      <div className="dropdown-wrapper">
        <i className="fa-solid fa-magnifying-glass" id="magnifying-glass"></i>
        <div className="dropdown">
          <div
            className="dropdown-button"
            onClick={(e) => setIsActive(!isActive)}
          >
            {selected.name}
            <i className="fa-solid fa-angle-down" id="arrow-down" />
          </div>
          {isActive && (
            <div className="dropdown-content">
              {gameOptions.map((temporaryOption) => (
                <div
                  key={temporaryOption.gameId}
                  className="dropdown-item"
                  onClick={(e) => {
                    setSelected(temporaryOption);
                    setIsActive(false);
                  }}
                >
                  {temporaryOption.name}
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
