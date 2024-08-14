import React, { useEffect, useState } from "react";
import { useContext } from "react";
import Friend from './Friend/Friend';
import './FriendsList.css';
import FriendRequests from './FriendRequest/FriendRequest';
import FriendRequestWindow from './FriendRequest/FriendRequestWindow';
import dragon from '../../assets/resources/rust.jpg';
import { UserContext } from "../../Services/UserContext";
import {GetFriendsList,GetFriendsListRequests} from '../../Services/UserService'

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
            <div className="friends-list-friend-requests" onClick={ onFriendRequestClick}>
            {user && user.requests && user.requests.length > 0 && (
                    <FriendRequests count={user.requests.length} isExpanded={isExpanded} />
                )}
            </div>
            <div className="friends-container">
                { user && user.friends && user.friends.map((friend) => (
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