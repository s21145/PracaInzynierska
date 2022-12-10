import React, { useEffect, useState } from "react";
import "./FindPlayers.css";
import FoundPlayer from "../../components/FoundPlayer/FoundPlayer";

function FindPlayers() {
    const [gameOption, setGameOption] = useState('');

    const handleGameOption=(event)=>{
        const getGame = event.target.value;
        setGameOption(getGame);
    }


  return (
    <div className="find-players">
        <h1>Who are you looking for?</h1>
        <div className="find-players-wrapper">
            <div className="find-players-form">
                <form>
                    <div className="form-container">
                        <div>
                            <input type="text" className="find-players-input" placeholder="Nickname of player" />
                        </div>
                        <div>
                            <select className="find-players-select" onChange={(e)=>(handleGameOption(e))}>
                                <option value="default" selected="selected" disabled>Select game</option>
                                <option value="cs:go">CS:GO</option>
                                <option value="rust">Rust</option>
                            </select>
                        </div>
                        <div>
                            <button className="find-players-search-button">
                                Search
                            </button>
                        </div>
                    </div>
                </form>
                
            </div>
            <div className="found-players">
                <FoundPlayer />
                
            </div>
        </div>
    </div>
  );
}

export default FindPlayers;
