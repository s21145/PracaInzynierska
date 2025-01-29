import React from "react";
import { useEffect } from "react";
import './FriendRequestWindow.css';



const FriendRequestWindow = ({ onClose, pendingFriendRequests, onResponse }) => {
  useEffect(() => {
    if (pendingFriendRequests.length === 0) {
      onClose();
    }
  }, [pendingFriendRequests, onClose]);
    return (
      <div className="friend-request-overlay">
        <div className="friend-request-window">
          <div className="friend-request-header">
            <button className="fake-button">X</button>
            <span>Friend requests</span>
            <button className="close-button" onClick={onClose}>X</button>
          </div>
          <div className="friend-request-body">
            {pendingFriendRequests.map((request, index) => (
              <div key={index} className="friend-request-item">
                <img
                  src={`data:image/png;base64, ${request.userIcon}`}
                  className="friend-request-image"
                  alt={request.userLogin}
                />
                <span className="friend-request-name" title={request.userLogin}>
                  {request.userLogin}
                </span>
                <div className="friend-request-actions">
                  <button
                    className="accept-button"
                    onClick={() => onResponse(request, "Accepted")}
                  >
                    Accept
                  </button>
                  <button
                    className="decline-button"
                    onClick={() => onResponse(request, "Declined")}
                  >
                    Decline
                  </button>
                </div>
              </div>
            ))}
          </div>
          <div className="friend-request-button-container">
            <button onClick={onClose}>Close</button>
          </div>
        </div>
      </div>
    );
  };

export default FriendRequestWindow;
