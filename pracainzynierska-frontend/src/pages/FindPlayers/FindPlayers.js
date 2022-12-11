import React, { useEffect, useState } from "react";
import "./FindPlayers.css";
import FoundPlayer from "../../components/FoundPlayer/FoundPlayer";
import GamesDropdown from "../GamesDropdown/GamesDropdown";
import { getGames } from "../../Services/PostService";
import { getSimilarUsers } from "../../Services/GamesService";

function FindPlayers() {
  const [selected, setSelected] = useState({});
  const [users, setUsers] = useState([]);
  const [gameOptions, setGameOptions] = useState([]);

  useEffect(() => {
    const fetchGames = async () => {
      const games = await getGames();
      setGameOptions(games.data);
    };
    fetchGames();
  }, []);

  useEffect(() => {
    const fetchUsers = async () => {
      console.log("testAAA");
      console.log(selected);
      if (Object.keys(selected).length === 0) return;
      const query = await getSimilarUsers(selected.gameId, 0);
      if (query.status !== 200) {
        setUsers([]);
      } else {
        setUsers(query.data);
        console.log(users);
      }
    };
    fetchUsers();
  }, [selected]);

  return (
    <div className="find-players">
      <h1>Who are you looking for?</h1>
      <div className="find-players-wrapper">
        <div className="find-players-form">
          <form>
            <div className="form-container">
              <div>
                <input
                  type="text"
                  className="find-players-input"
                  placeholder="Nickname of player"
                />
              </div>
              <div>
                <GamesDropdown
                  selected={selected}
                  setSelected={setSelected}
                  gameOptions={gameOptions}
                />
              </div>
              <div>
                <button className="find-players-search-button">Search</button>
              </div>
            </div>
          </form>
        </div>
        <div className="found-players">
          <FoundPlayer />
        </div>
      </div>
    </div>
  );
}

export default FindPlayers;
