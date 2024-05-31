import React from 'react';
import './Friend.css';

const Friend = ({ name, imageUrl, isExpanded, onClick }) => {
    return (
        <div className={`friend-item ${isExpanded ? 'expanded' : 'shrunk'}`} onClick={() => onClick(name)}>
            <img src={imageUrl} className="friend-image" alt={name} />
            {isExpanded && <span>{name}</span>}
        </div>
    );
};

export default Friend;
