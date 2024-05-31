import React from "react";
import { useState, useEffect, useContext } from "react";
import "./ProfileMainGames.css";
import { GetMissingGamesUser, AddGame } from "../../../Services/GamesService";
import { statModalContext } from "../../../Services/StatsModalContext";
import { MessageContext } from "../../../Services/MessageContext";

function ProfileMainGames({ profileChanger, ...rest }) {
  const [games, setGames] = useState([]);
  const { statModal, setStatModal } = useContext(statModalContext);
  const { message, setMessage } = useContext(MessageContext);
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
  const handleGameAdd = async (selected) => {
    if (Object.keys(selected).length === 0) return;
    const response = await AddGame(selected.gameId);
    if (response.status !== 200) {
      setMessage({ content: "Wystąpił błąd podczas próby przypisania gry", show: true });
    } else {
      //wyswietlic modala
      setStatModal({ stats: response.data, show: true });
      setGames((current) =>
        current.filter((c) => c.gameId !== selected.gameId)
      );
    }
  };


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
              onClick={async (e) => handleGameAdd(game)}
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
