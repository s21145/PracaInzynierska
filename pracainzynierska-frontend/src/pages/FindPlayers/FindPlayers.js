import React, { useEffect, useState } from "react";
import "./FindPlayers.css";
import GamesDropdown from '../GamesDropdown/GamesDropdown';

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
                        
                        {gameOption==='cs:go' && (
                                <div className="game-specific-options">
                                    <div>
                                        <select name="" id="" className="find-players-select">
                                            <option value="select-rank" selected="selected" disabled>Select min rank</option>
                                            <option value="any">Any rank</option>
                                            <option value="silver1">Silver I</option>
                                            <option value="silver2">Silver II</option>
                                            <option value="silver3">Silver III</option>
                                            <option value="silver4">Silver IV</option>
                                            <option value="silver5">Silver Elite</option>
                                            <option value="silver6">Silver Elite Master</option>
                                            <option value="gold1">Gold Nova I</option>
                                            <option value="gold2">Gold Nova II</option>
                                            <option value="gold3">Gold Nova III</option>
                                            <option value="gold4">Gold Nova Master</option>
                                            <option value="master1">Master Guardian I</option>
                                            <option value="master2">Master Guardian II</option>
                                            <option value="master3">Master Guardian Elite</option>
                                            <option value="master4">Distinguished Master Guardian</option>
                                            <option value="eagle1">Legendary Eagle</option>
                                            <option value="eagle2">Legendary Eagle Master</option>
                                            <option value="masterfc">Supreme Master First Class</option>
                                            <option value="global">Global Elite</option>
                                        </select>
                                    </div>
                                </div>
                            )
                        }
                        {gameOption==='rust' && (
                                <div className="game-specific-options">
                                    <div>
                                        <input type="number" min="0" className="find-players-input" placeholder="Min hours" />
                                    </div>
                                    <div>
                                        <input type="number" min="0" className="find-players-input" placeholder="max hours" />
                                    </div>
                                    <div>
                                        <select className="find-players-select">
                                            <option className="select-option" value="select-group-size" selected="selected" disabled>Select group size</option>
                                            <option value="duo-trio">Duo / trio</option>
                                            <option value="4-8man">4-8 man</option>
                                            <option value="zerg">Zerg</option>
                                            <option value="any">Any</option>
                                        </select>
                                    </div>
                                </div>
                            )
                        }
                    </div>
                </form>
                
            </div>
            <div className="found-players">

            </div>
        </div>
    </div>
  );
}

export default FindPlayers;
