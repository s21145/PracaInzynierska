import React, { useEffect, useState } from "react";
import { useContext } from "react";
import Friend from './Friend/Friend';
import './FriendsList.css';
import FriendRequests from './FriendRequest/FriendRequest'; // Update the import path
import {GetFriendsList,GetFriendsListRequests} from '../../Services/UserService'
import FriendRequests from './FriendRequest/FriendRequest';
import FriendRequestWindow from './FriendRequest/FriendRequestWindow';

import dragon from '../../assets/resources/rust.jpg';
import { UserContext } from "../../Services/UserContext";

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
    const { user } = useContext(UserContext);
    const toggleExpand = () => {
        setIsExpanded(!isExpanded);
    };
    const [friends, setFriends] = useState([]);
    const [friendRequests, setFriendRequests] = useState([]);
    useEffect(() => {
        const fetchFriendsList = async () => {
          const list = await GetFriendsList();
          const requests = await GetFriendsListRequests();
          console.log(list);
          console.log(requests);
          if(list.status === 200){
            setFriends(list.data);
          }else{
            //error
          }
          if(requests.status === 200){
            setFriendRequests(requests.data);
          }{
            //error
          }
         console.log(friendRequests);
        };
        fetchFriendsList();
      }, [user]);
    
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
                {friends.map((friend) => (
                    <Friend
                        key={friend.userId}
                        name={friend.userLogin}
                        imageUrl={friend.iconPath}
                        isExpanded={isExpanded}
                        onClick={onFriendClick}
                    />
                ))}
            </div>
        </div>
    );
};

export default FriendsList;