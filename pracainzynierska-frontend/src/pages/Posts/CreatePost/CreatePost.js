import GamesDropdown from '../../GamesDropdown/GamesDropdown';
import './CreatePost.css';
import React, { useState, useEffect } from "react";
import { getGames } from "../../../Services/PostService";

function CreatePost({ closeModal }) {    
    const [selected, setSelected] = useState({});
    const [gameOptions, setGameOptions] = useState([]);
  
    useEffect(() => {
        const fetchGames = async () => {
            const games = await getGames();
            setGameOptions(games.data);
        };
        fetchGames();
    }, []);
  
    return (
        <div className="create-post-background">
            <div className="create-post-container">
                <div className="create-post-header">
                    <span>Create post</span>
                    <button className="modal-close-mark" onClick={() => closeModal(false)}>
                        <i className="fa-solid fa-xmark" />
                    </button>
                </div>
                
                <div className="create-post-game-selector">
                    <GamesDropdown selected={selected} setSelected={setSelected} gameOptions={gameOptions} />
                </div>
                <div className="create-post-title-container">
                    <input className="create-post-input" placeholder="Title"></input>
                </div>
                <div className="create-post-body-container">
                    <textarea className="create-post-textarea" placeholder="Body"></textarea>
                </div>
                <div className="create-post-buttons">
                    <button className="create-post-button post">Post</button>
                </div>
            </div>
        </div>
    );
}

export default CreatePost;
