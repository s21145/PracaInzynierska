import React from "react";
import './FriendRequestWindow.css';

import rust from '../../../assets/resources/rust.jpg';
import dragon from '../../../assets/resources/dragon.png';


// const pendingFriendRequests = [
//     {
//         name: 'Kejnar',
//         imageUrl: dragon,
//     },
//     {
//         name: 'BidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidiBidi',
//         imageUrl: dragon,
//     },
//     {
//         name: 'Drecki',
//         imageUrl: dragon,
//     },
//     {
//         name: 'Sempu',
//         imageUrl: dragon,
//     },
// ];

const FriendRequestWindow = ({onClose,pendingFriendRequests,onResponse}) => {

  
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
                            <img src={`data:image/png;base64, ${request.userIcon}`}  className="friend-request-image" alt={request.userLogin} />
                            <span className="friend-request-name" title={request.userLogin}>{request.userLogin}</span>
                            <div className="friend-request-actions">
                                <button className="accept-button" onClick={() => onResponse(request,"Accepted")}>Accept</button>
                                <button className="decline-button" onClick={() => onResponse(request,"Declined")}>Decline</button>
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
