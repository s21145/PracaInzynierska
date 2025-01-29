import React, { useState, useContext, forwardRef } from 'react';
import './FoundPlayer.css';

import { statModalContext } from "../../Services/StatsModalContext";
import { getStats } from "../../Services/GamesService";




const FoundPlayer = forwardRef(({ userLogin, description, birthday, image, userId, isFriend, selectedGame,handleAddFriendClick }, ref) => {
    const { setStatModal } = useContext(statModalContext);
    const [openGameModal, setOpenGameModal] = useState(false);


    const calculateAge = (dob) => {
        const birthDate = new Date(dob);
        const diffMs = Date.now() - birthDate.getTime();
        const ageDt = new Date(diffMs);
        return Math.abs(ageDt.getUTCFullYear() - 1970);
    };

    const age = calculateAge(birthday);


    const handleProfile = async () => {
        try {
            const response = await getStats(selectedGame, userLogin);
            if (response.status === 200) {
                setStatModal({ stats: response.data, show: true });
            } else {
            }
        } catch (error) {
            console.error("Error fetching stats:", error);
        }
    };

    return (
        <>

            <div className="found-player" ref={ref}>
                <div className="found-player-picture">
                    <img src={`data:image/png;base64,${image}`} alt={`${userLogin}'s avatar`} />
                </div>
                <div className="found-player-details">
                    <div className="found-player-info">
                        <span className="found-player-nickname">{userLogin}</span>
                        <span className="found-player-age"> ({age})</span>
                    </div>
                    <div className="found-player-bio">
                        {description}
                    </div>
                </div>
                <div className="found-player-buttons">
                    <button className="found-player-button" onClick={handleProfile}>Profile</button>
                    {!isFriend && (
                        <button className="found-player-button" onClick={() =>handleAddFriendClick(userId)}>Add</button>
                    )}
                </div>
            </div>
        </>
    );
}
);
export default FoundPlayer;
