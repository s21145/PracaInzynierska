import React from 'react';
import "./GameModal.css";
import { useContext } from "react";
import { GameContext } from '../../../../Services/GameContext';


const GameModal = () => {
    
    
    return (
        <div className="game-modal">
            <div className="game-modal-wrapper">
                <div className="game-modal-container">
                    <div className="game-modal-content">
                        <div className="game-modal-content-title">
                            <div className="">
                                <h1>Game Name</h1>
                                </div>
                        </div>
                        <div className="game-modal-content-wrapper">
                            <div className="game-modal-content-stats">
                                <div className="game-stat">
                                    <div className="stats-text">
                                        Win rate: ???%
                                    </div>
                                </div>
                                <div className="game-stat">
                                    <div className="stats-text">
                                        Win rate: ???%
                                    </div>
                                </div>
                                <div className="game-stat">
                                    <div className="stats-text">
                                        Win rate: ???%
                                    </div>
                                </div>
                                <div className="game-stat">
                                    <div className="stats-text">
                                        Win rate: ???%
                                    </div>
                                </div>
                                <div className="game-stat">
                                    <div className="stats-text">
                                        Win rate: ???%
                                    </div>
                                </div>
                            </div>
                            <div className="game-modal-content-right-side">
                                <div className="game-modal-content-picture">
                                    <button className="game-picture" id="leagueoflegends">
                                    </button>
                                </div>
                                <div className="game-modal-content-buttons">
                                    <button className="game-button">
                                        Add game
                                    </button>
                                    <button className="game-button">
                                        Cancel
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="game-modal-close-button">
                        <button
                            className="modal-close-mark"
                            onClick={handleCloseModal}
                        >
                            <i className="fa-solid fa-xmark" />
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default GameModal
