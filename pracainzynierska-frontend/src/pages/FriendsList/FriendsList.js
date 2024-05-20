import React, { useState } from 'react';
import Friend from './Friend/Friend';
import './FriendsList.css';
import FriendRequests from './FriendRequest/FriendRequest'; // Update the import path

import dragon from '../../assets/resources/rust.jpg';

const friends = [
    {
        name: 'Bartek Konarski',
        imageUrl: dragon,
    },
    {
        name: 'Robert Puszczynski',
        imageUrl: dragon,
    },
    {
        name: 'Mateusz Grudkowski',
        imageUrl: dragon,
    },
];

const pendingFriendRequests = 999;

const FriendsList = () => {
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
            <div className="friends-list-friend-requests">
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
                    />
                ))}
            </div>
        </div>
    );
};

export default FriendsList;
