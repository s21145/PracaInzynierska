import React from "react";
import { useState, useEffect } from "react";
import "./ProfileMainGames.css";
import { GetMissingGamesUser, AddGame } from "../../../Services/GamesService";

function ProfileMainGames({ profileChanger, ...rest }) {
  const [games, setGames] = useState([]);
  const [gameId, setGameId] = useState(null);
  const fetchUserGames = async () => {
    const response = await GetMissingGamesUser();
    if (response.status !== 200) {
      //blad
    } else {
      console.log(response.data);
      setGames(response.data);
    }
  };
  useEffect(() => {
    fetchUserGames();
  }, []);
  const handleGameAdd = async () => {
    if (gameId === null) return;
    const response = await AddGame(gameId);
    if (response.status !== 200) {
      //blad
    } else {
      //wyswietlic modala
      setGames((current) => current.filter((c) => c.gameId !== gameId));
    }
  };
  useEffect(() => {
    handleGameAdd();
  }, gameId);
  return (
    <div className="profile-games-wrapper">
      <div className="profile-games-return-button">
        <i
          class="fa-sharp fa-solid fa-arrow-left"
          onClick={() => profileChanger(1)}
        />
      </div>
      <div className="profile-games-container">
        {games &&
          games.map((game) => (
            <button
              key={game.gameId}
              className="game-icon-button"
              id={game.gameId}
              onClick={(e) => setGameId(game.gameId)}
              style={{
                backgroundImage: `url(data:image/png;base64,${game.image})`,
              }}
            ></button>
          ))}
      </div>
    </div>
  );
}

export default ProfileMainGames;
