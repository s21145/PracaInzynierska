import React from "react";
import "./GameModal.css";
import { useContext } from "react";
import { statModalContext } from "../../../../Services/StatsModalContext";
import { getStats } from "../../../../Services/GamesService";
import { useState } from "react";
import { useEffect } from "react";

const GameModal = () => {
  const { statModal, setStatModal } = useContext(statModalContext);

  return (
    <div className="game-modal">
      <div className="game-modal-wrapper">
        <div className="game-modal-container">
          <div className="game-modal-content">
            <div className="game-modal-content-title">
              <div className="">
                <h1>{statModal.stats.gameName}</h1>
              </div>
            </div>
            <div className="game-modal-content-wrapper">
              <div className="game-modal-content-stats">
                {statModal.stats.stats &&
                  statModal.stats.stats.map((item) => (
                    <div className="game-stat">
                      <div className="stats-text">
                        {item.name}: {item.value}
                      </div>
                    </div>
                  ))}
              </div>
              <div className="game-modal-content-right-side">
                <div className="game-modal-content-picture">
                  <button
                    className="game-picture"
                    style={{
                      backgroundImage: `url(data:image/png;base64,${
                        statModal.stats && statModal.stats.gameImage
                      })`,
                    }}
                  ></button>
                </div>
                <div className="game-modal-content-buttons">
                  <button className="game-button">Add game</button>
                  <button
                    className="game-button"
                    onClick={() => setStatModal({ show: false })}
                  >
                    Cancel
                  </button>
                </div>
              </div>
            </div>
          </div>
          <div className="game-modal-close-button">
            <button
              className="modal-close-mark"
              onClick={() => setStatModal({ show: false })}
            >
              <i className="fa-solid fa-xmark" />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default GameModal;
