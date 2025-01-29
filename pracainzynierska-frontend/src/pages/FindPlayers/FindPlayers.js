import React, { useEffect, useState, useContext, useRef, useCallback } from "react";
import "./FindPlayers.css";
import FoundPlayer from "../../components/FoundPlayer/FoundPlayer";
import GamesDropdownFindPlayers from "../GamesDropdown/GamesDropdownFindPlayers";
import { getGames } from "../../Services/PostService";
import { getSimilarUsers, getUsersByNickname } from "../../Services/GamesService";
import GameModal from "../../pages/ProfileMain/ProfileMainSubPages/GameStatistics/GameModal";
import { statModalContext } from "../../Services/StatsModalContext";
import { useLoader } from "../../Services/LoaderContext";
import { MessageContext } from "../../Services/MessageContext";
import { AddFriendRequest } from "../../Services/UserService";
import MessageModal from "../../components/MessageModal";

function FindPlayers() {
  const [selected, setSelected] = useState({});
  const [users, setUsers] = useState([]);
  const [gameOptions, setGameOptions] = useState([]);
  const [userNickname, setUserNickname] = useState("");
  const [page, setPage] = useState(0);
  const [isLoading, setIsLoading] = useState(false);
  const { statModal, setStatModal } = useContext(statModalContext);
  const { startLoading, stopLoading } = useLoader();
  const { message, setMessage } = useContext(MessageContext);

  const observer = useRef();

  const lastUserElementRef = useCallback(node => {
    if (isLoading) return;
    if (observer.current) observer.current.disconnect();
    observer.current = new IntersectionObserver(entries => {
      if (entries[0].isIntersecting && users.length >= 10) {
        setPage(prevPage => prevPage + 1);
      }
    });
    if (node) observer.current.observe(node);
  }, [isLoading, users]);

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
      setPage(0);
      setUsers([]);
      await loadUsers(0);
    };
    fetchUsers();
  }, [selected]);

  useEffect(() => {
    if (page > 0) {
      loadUsers(page);
    }
  }, [page]);

  const loadUsers = async (pageNumber) => {
    startLoading();
    setIsLoading(true);
    const query = await getSimilarUsers(selected.gameId, pageNumber);
    setIsLoading(false);
    if (query.status !== 200) {
      setUsers([]);
    } else {
      setUsers(prevUsers => [...prevUsers, ...query.data]);
    }
    stopLoading();
  };

  const handleAddFriendClick = async (userId) => {
    try {
      const response = await AddFriendRequest(userId);
      setUsers(prevUsers =>
        prevUsers.map(user =>
          user.userId === userId ? { ...user, isFriend: true } : user
        )
      );
      setMessage({
        content: "A friend request has been sent",
        show: true,
      });

    } catch (error) {
      //console.error("Error sending friend request:", error);
    }
  };

  const handleSumbit = async (event) => {
    event.preventDefault();
    if (userNickname === "") {
      return;
    }
    startLoading();
    const query = await getUsersByNickname(userNickname);
    if (query.status !== 200) {
      setUsers([]);
    } else {
      setUsers(query.data);
    }
    stopLoading();
  };

  const handleInputChange = (event) => {
    setUserNickname(event.target.value);
  };

  return (
    <>
      {message && message.show && <MessageModal />}
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
            {users.map((u, index) => (
              <FoundPlayer
                handleAddFriendClick={handleAddFriendClick}
                userLogin={u.userLogin}
                key={u.userLogin}
                userId={u.userId}
                description={u.description}
                birthday={u.birthday}
                image={u.image}
                isFriend={u.isFriend}
                selectedGame={selected.gameId}
                ref={index === users.length - 1 ? lastUserElementRef : null}
              />
            ))}
          </div>
        </div>
      </div>
    </>
  );
}

export default FindPlayers;
