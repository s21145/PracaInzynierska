import React, { useState } from 'react';
import Friend from './Friend/Friend';
import './FriendsList.css';
import FriendRequests from './FriendRequest/FriendRequest';
import FriendRequestWindow from './FriendRequest/FriendRequestWindow';

import dragon from '../../assets/resources/rust.jpg';

const friends = [
    {
        name: 'Kejnar',
        imageUrl: dragon,
    },
    {
        name: 'Bidi',
        imageUrl: dragon,
    },
    {
        name: 'Drecki',
        imageUrl: dragon,
    },
    {
        name: 'Sempu',
        imageUrl: dragon,
    },
];

const pendingFriendRequests = 999;

const FriendsList = ({ onFriendClick, onFriendRequestClick }) => {
    const [isExpanded, setIsExpanded] = useState(true);

    const toggleExpand = () => {
        setIsExpanded(!isExpanded);
    };

    return (
        <div className={`friends-list ${isExpanded ? 'expanded' : 'shrunk'}`}>
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
            <div className="friends-list-friend-requests" onClick={onFriendRequestClick}>
                {pendingFriendRequests > 0 && (
                    <FriendRequests count={pendingFriendRequests} isExpanded={isExpanded} />
                )}
            </div>
            <div className="friends-container">
                {friends.map((friend, index) => (
                    <Friend
                        key={index}
                        name={friend.name}
                        imageUrl={friend.imageUrl}
                        isExpanded={isExpanded}
                        onClick={onFriendClick}
                    />
                ))}
            </div>
        </div>
    );
};

export default FriendsList;
