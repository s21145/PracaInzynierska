import React from "react";
import './FriendRequestWindow.css';

import rust from '../../../assets/resources/rust.jpg';
import dragon from '../../../assets/resources/dragon.png';


const pendingFriendRequests = [
    {
        name: 'Kejnar',
        imageUrl: dragon,
    },
    {
        name: 'BidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidi',
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

const FriendRequestWindow = ({onClose}) => {
    
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
                            <img src={request.imageUrl} className="friend-request-image" alt={request.name} />
                            <span className="friend-request-name" title={request.name}>{request.name}</span>
                            <div className="friend-request-actions">
                                <button className="accept-button">Accept</button>
                                <button className="decline-button">Decline</button>
                            </div>
                        </div>
                    ))}
                </div>
                <div className="friend-request-button-container">
                    <button onClick={onClose}>Close</button>
                </div>
            </div>
        </div>
    )
}

export default FriendRequestWindow;
