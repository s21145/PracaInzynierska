import React, { useEffect, useState } from "react";
import { useContext } from "react";
import Friend from "./Friend/Friend";
import "./FriendsList.css";
import FriendRequests from "./FriendRequest/FriendRequest";
import FriendRequestWindow from "./FriendRequest/FriendRequestWindow";
import { UserContext } from "../../Services/UserContext";
import { GetFriendsList, GetFriendsListRequests, SentFriendRequestResponse } from "../../Services/UserService";

const FriendsList = ({   onFriendClick,  onFriendRequestClick,  updatedFriends,  requests,  updateFriends, isExpanded, onToggleExpand }) => {
  const [isExpanded2, setIsExpanded] = useState(true);
  const { user } = useContext(UserContext);
  const [friends, setFriends] = useState([]);
  const [friendRequests, setFriendRequests] = useState([]);
  const [showFriendRequestWindow, setShowFriendRequestWindow] = useState(false);

  const toggleExpand = () => {
    setIsExpanded(!isExpanded2);
  };

  const handleResponse = async (request, status) => {
    const response = await SentFriendRequestResponse(request.userId, status);
    if (response.status === 200) {
      updateFriends();
    }
  };

  const handleFriendRemoved = () => {
    updateFriends();
  };

  return (
    <>
      {showFriendRequestWindow && (
        <FriendRequestWindow
          onClose={() => setShowFriendRequestWindow(false)}
          pendingFriendRequests={requests}
          onResponse={handleResponse}
        />
      )}

      <div className={`friends-list ${isExpanded ? "expanded" : "shrunk"}`}>
        <div className="friends-list-header">
          <span>Friends List</span>
          <button onClick={onToggleExpand} className="toggle-button">
            <i className="fa-solid fa-arrow-right-to-bracket"></i>
          </button>
          {!isExpanded && (
            <button onClick={onToggleExpand} className="expand-button">
              <i className="fa-solid fa-user-group"></i>
            </button>
          )}
        </div>
        <hr />

        <div
          className="friends-list-friend-requests"
          onClick={() => setShowFriendRequestWindow(true)}
        >
          {requests && requests.length > 0 && (
            <FriendRequests count={requests.length} isExpanded={isExpanded} />
          )}
        </div>

        <div className="friends-container">
          {updatedFriends.map((friend) => (
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
};

export default FriendsList;
