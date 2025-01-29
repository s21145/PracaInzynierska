import React, { useEffect, useState } from "react";
import { useContext } from "react";
import Friend from "./Friend/Friend";
import "./FriendsList.css";
import FriendRequests from "./FriendRequest/FriendRequest";
import FriendRequestWindow from "./FriendRequest/FriendRequestWindow";
import { UserContext } from "../../Services/UserContext";
import { GetFriendsList, GetFriendsListRequests, SentFriendRequestResponse } from "../../Services/UserService";

const FriendsList = React.memo(({ onFriendClick, onFriendRequestClick }) => {
  const [isExpanded, setIsExpanded] = useState(true);
  const { user } = useContext(UserContext);
  const [friends, setFriends] = useState([]);
  const [friendRequests, setFriendRequests] = useState([]);
  const [showFriendRequestWindow, setShowFriendRequestWindow] = useState(false);

  const fetchFriendsAndRequests = async () => {
    try {
      const [friendsResp, requestsResp] = await Promise.all([
        GetFriendsList(),
        GetFriendsListRequests(),
      ]);

      if (friendsResp.status === 200) {
        setFriends(friendsResp.data);
      }
      if (requestsResp.status === 200) {
        setFriendRequests(requestsResp.data);
      }
    } catch {}
  };

  useEffect(() => {
    fetchFriendsAndRequests();
    const intervalId = setInterval(() => {
      fetchFriendsAndRequests();
    }, 3000);
    return () => clearInterval(intervalId);
  }, []);

  const toggleExpand = () => {
    setIsExpanded(!isExpanded);
  };

  const handleResponse = async (request, status) => {
    const response = await SentFriendRequestResponse(request.userId, status);
    if (response.status === 200) {
      fetchFriendsAndRequests();
    }
  };

  const handleFriendRemoved = () => {
    fetchFriendsAndRequests();
  };

  return (
    <>
      {showFriendRequestWindow && (
        <FriendRequestWindow
          onClose={() => setShowFriendRequestWindow(false)}
          pendingFriendRequests={friendRequests}
          onResponse={handleResponse}
        />
      )}

      <div className={`friends-list ${isExpanded ? "expanded" : "shrunk"}`}>
        <div className="friends-list-header">
          <span>Friends List</span>
          <button onClick={toggleExpand} className="toggle-button">
            <i className="fa-solid fa-arrow-right-to-bracket"></i>
          </button>
          {!isExpanded && (
            <button onClick={toggleExpand} className="expand-button">
              <i className="fa-solid fa-user-group"></i>
            </button>
          )}
        </div>
        <hr />

        <div
          className="friends-list-friend-requests"
          onClick={() => setShowFriendRequestWindow(true)}
        >
          {friendRequests && friendRequests.length > 0 && (
            <FriendRequests count={friendRequests.length} isExpanded={isExpanded} />
          )}
        </div>

        <div className="friends-container">
          {friends.map((friend) => (
            <Friend
              key={friend.userId}
              userId={friend.userId}
              name={friend.userLogin}
              imageUrl={friend.iconPath}
              isExpanded={isExpanded}
              onClick={onFriendClick}
              afterRemove={handleFriendRemoved} 
            />
          ))}
        </div>
      </div>
    </>
  );
});

export default FriendsList;
