import React, { useEffect, useState,useContext } from "react";
import "./FindPlayers.css";
import FoundPlayer from "../../components/FoundPlayer/FoundPlayer";
import GamesDropdownFindPlayers from "../GamesDropdown/GamesDropdownFindPlayers";
import { getGames } from "../../Services/PostService";
import { getSimilarUsers,getUsersByNickname } from "../../Services/GamesService";
import GameModal from "../../pages/ProfileMain/ProfileMainSubPages/GameStatistics/GameModal";
import { statModalContext } from "../../Services/StatsModalContext";

function FindPlayers() {
  const [selected, setSelected] = useState({});
  const [users, setUsers] = useState([]);
  const [gameOptions, setGameOptions] = useState([]);
  const [userNickname,setUserNickname]=useState("");
  const { statModal, setStatModal } = useContext(statModalContext);
  useEffect(() => {
    const fetchGames = async () => {
      const games = await getGames();
      setGameOptions(games.data);
    };
    fetchGames();
  }, []);

  useEffect(() => {
    const fetchUsers = async () => {
      if (Object.keys(selected).length === 0) return;
      const query = await getSimilarUsers(selected.gameId, 0);
      if (query.status !== 200) {
        setUsers([]);
      } else {
        setUsers(query.data);
        console.log(query.data);
      }
    };
    fetchUsers();
  }, [selected]);

  const fetchUsers = async (selected) => {
    if (Object.keys(selected).length === 0) return;
    const query = await getSimilarUsers(selected.gameId, 0);
    if (query.status !== 200) {
      setUsers([]);
    } else {
      setUsers(query.data);
      console.log(query.data);
    }
  };
  const handleSumbit = async (event) => {
    event.preventDefault();
    if(userNickname == ""){
      return;
    }
    const query = await getUsersByNickname(userNickname);
    if (query.status !== 200) {
      setUsers([]);
    } else {
      setUsers(query.data);
      console.log(query.data);
    }
  }
  const handleInputChange = (event) => {
    setUserNickname(event.target.value); 
  };

  return (
    <div className="find-players">
        {statModal && statModal.show && <GameModal />}
      <h1>Who are you looking for?</h1>
      <div className="find-players-wrapper">
        <div className="find-players-form">
          <form onSubmit={handleSumbit}>
            <div className="form-container">
              <div>
                <input
                  type="text"
                  className="find-players-input"
                  placeholder="Nickname of player"
                  value={userNickname}
                  onChange={handleInputChange}
                />
              </div>
              <div>
                <GamesDropdownFindPlayers
                  selected={selected}
                  setSelected={setSelected}
                  gameOptions={gameOptions}
                />
              </div>
              <div>
                <button type="submit" className="find-players-search-button">Search</button>  
              </div>
            </div>
          </form>
        </div>
        <div className="found-players">
        {users.map(u => (
          
          <FoundPlayer userLogin={u.userLogin}
          key={u.userLogin}
          userId={u.userId}
          description={u.description}
          birthday={u.birthday}
          image={u.image}
          isFriend={u.isFriend}
          selectedGame={selected.gameId}/>
  
        ))}
              </div>
        
      </div>
    </div>
  );
}

export default FindPlayers;
