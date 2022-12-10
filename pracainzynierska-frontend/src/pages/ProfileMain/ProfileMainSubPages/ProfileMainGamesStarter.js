import React from "react";
import "./ProfileMainGamesStarter.css";
import { GetUserGames } from "../../../Services/GamesService";
import { useState } from "react";
import { useEffect } from "react";
function ProfileMainGamesStarter({ profileChanger, ...rest }) {
  const [games, setGames] = useState([]);
  const fetchUserGames = async () => {
    const response = await GetUserGames();
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
  console.log(games);
  return (
    <div className="profile-games-wrapper">
      <div className="profile-games-container">
        <button className="game-add-button" onClick={() => profileChanger(3)}>
          <i class="fa-solid fa-plus" />
          Add game
        </button>
        {games &&
          games.map((game) => (
            <button
              key={game.gameId}
              className="game-icon-button"
              id={game.gameId}
              style={{
                backgroundImage: `url(data:image/png;base64,${game.image})`,
              }}
            ></button>
          ))}
      </div>
    </div>
  );
}

export default ProfileMainGamesStarter;
