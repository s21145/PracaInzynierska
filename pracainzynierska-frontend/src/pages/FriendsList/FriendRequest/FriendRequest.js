import React from 'react';
import './FriendRequest.css';

const FriendRequests = ({ count, isExpanded }) => {
    return (
        <div className={`friend-requests-container ${isExpanded ? 'expanded' : 'shrunk'}`}>
            <div className={`friend-requests ${isExpanded ? '' : 'shrunk'}`}>
                <span>Friend requests</span>
                <div className="friend-requests-counter">{count}</div>
            </div>
            <hr />
        </div>
    );
};

export default FriendRequests;
