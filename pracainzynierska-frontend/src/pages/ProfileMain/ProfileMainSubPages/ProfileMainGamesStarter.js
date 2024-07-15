import React from "react";
import "./ProfileMainGamesStarter.css";
import { GetUserGames } from "../../../Services/GamesService";
import { useState } from "react";
import { useEffect } from "react";
import { useContext } from "react";
import { statModalContext } from "../../../Services/StatsModalContext";
import { getStats } from "../../../Services/GamesService";
function ProfileMainGamesStarter({ profileChanger, ...rest }) {
  const [games, setGames] = useState([]);
  const [selected, setSelected] = useState({});
  const { statModal, setStatModal } = useContext(statModalContext);
  const fetchUserGames = async () => {
    const response = await GetUserGames();
    if (response.status !== 200) {
      //blad
    } else {
      setGames(response.data);
    }
  };
  useEffect(() => {
    fetchUserGames();
  }, []);
  const handleClick = async () => {
    if (Object.keys(selected).length === 0) return;

    var response = await getStats(selected.gameId);
    if (response.status !== 200) {
      //blad
    } else {
      setStatModal({ stats: response.data, show: true });
      setSelected({});
    }
  };
  useEffect(() => {
    handleClick();
  }, [selected]);
  return (
    <div className="profile-games-wrapper">
      <div className="profile-games-container">
        <button className="game-add-button" onClick={() => profileChanger(3)}>
          <i className="fa-solid fa-plus" />
          Add game
        </button>
        {games &&
          games.map((game) => (
            <button
              key={game.gameId}
              className="game-icon-button"
              onClick={() => setSelected(game)}
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
