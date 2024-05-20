import React from 'react';
import './Friend.css';

const Friend = ({ name, imageUrl, isExpanded }) => {
    return (
        <div className={`friend-item ${isExpanded ? 'expanded' : 'shrunk'}`}>
            <img src={imageUrl} className="friend-image" alt={name} />
            {isExpanded && <span>{name}</span>}
        </div>
    );
};

export default Friend;
