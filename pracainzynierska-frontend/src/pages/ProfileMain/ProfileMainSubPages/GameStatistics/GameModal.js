import React from 'react';
import "./GameModal.css";
import { useState } from "react";


function GameModal({ closeGameModal }) {
    
    
    return (
        <div className="game-modal-wrapper">
            <div className="game-modal-container">
                <div className="game-modal-content-wrapper">
                    <div className="game-modal-content">
                        <div className="game-modal-content-title">
                            <div className="">
                                <h1>Game Name</h1>
                                </div>
                        </div>
                        <div className="game-modal-conent-stats">
                            <div className="game-stats">
                                <div className="stats-icon">
                                    K/D
                                </div>
                                <div className="stats-text">X.Y</div>
                            </div>
                            <div className="game-stats">
                                <div className="stats-icon">
                                    <i class="fa-regular fa-clock"></i>
                                </div>
                                <div className="stats-text">X hours</div>
                            </div>
                            <div className="game-stats">
                                <div className="stats-icon">
                                <i class="fa-solid fa-trophy"></i>
                                </div>
                                <div className="stats-text">
                                    100%
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="game-modal-close-button">
                        <button
                            className="modal-close-mark"
                            onClick={() => closeGameModal(false)}
                        >
                            <i className="fa-solid fa-xmark" />
                        </button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default GameModal
