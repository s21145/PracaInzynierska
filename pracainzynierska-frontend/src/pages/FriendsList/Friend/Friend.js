import React from 'react';
import './Friend.css';

const Friend = ({ userId,name, imageUrl, isExpanded, onClick }) => {
    return (
        <div className={`friend-item ${isExpanded ? 'expanded' : 'shrunk'}`} onClick={() => onClick({login:name,id:userId,image:imageUrl})}>
            <img  className="friend-image" alt={name} src={`data:image/png;base64, ${imageUrl}`}  />
            {isExpanded && <span>{name}</span>}
        </div>
    );
    
};

export default Friend;
