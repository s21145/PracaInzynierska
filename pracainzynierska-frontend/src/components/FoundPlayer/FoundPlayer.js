import React from 'react';
import './FoundPlayer.css';


const FoundPlayer = ({userLogin,description,birthday,image}) => {
    const age = calculate_age(birthday)
    function calculate_age(dob) { 
        var date= new Date(dob);
        var diff_ms = Date.now() - date.getTime();
        var age_dt = new Date(diff_ms); 
      
        return Math.abs(age_dt.getUTCFullYear() - 1970);
    }
  return (
    <div className="found-player">
        <div className="found-player-container">
            <div className="found-player-title" >
            <img className="found-player-picture" src={`data:image/png;base64, ${image}`}></img>
                <div className="found-player-name">
                    <div className="found-player-nickname">
                        {userLogin}
                    </div>
                    <div className="found-player-age">
                        Age: {age}
                    </div>
                </div>
            </div>
            <div className="found-player-bio">
                {description}
            </div>
            <div className="found-player-buttons">
                <button className="found-player-button">PROFILE</button>
                <button className="found-player-button">ADD</button>
            </div>
        </div>
    </div>
  )
}

export default FoundPlayer
