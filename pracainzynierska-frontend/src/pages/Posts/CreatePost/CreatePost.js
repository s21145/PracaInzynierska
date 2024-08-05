import GamesDropdown from '../../GamesDropdown/GamesDropdown';
import './CreatePost.css';
import React, { useState, useEffect } from "react";
import { getGames,createPost } from "../../../Services/PostService";
import { UserContext } from "../../../Services/UserContext";
import { useContext } from "react";
function CreatePost({ closeModal }) {    
    const [selected, setSelected] = useState({});
    const [gameOptions, setGameOptions] = useState([]);
    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const { user } = useContext(UserContext);
    useEffect(() => {
        const fetchGames = async () => {
            const games = await getGames();
            setGameOptions(games.data);
        };
        fetchGames();
    }, []);
  
    const handlePost = async () => {
        console.log(user);
       
        try{
            var response = await createPost(title,content,user.login,selected.name)
            console.log(response);
            if(response.status === 200){

            }else{
                //error
            }
        }catch(ex){

        }
        closeModal(false);
    }
    const handleTitleChange = (event) => {
        setTitle(event.target.value);
      };
      const handleContentChange = (event) => {
        setContent(event.target.value);
      };
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
                    <input className="create-post-input" placeholder="Title"  value={title} onChange={handleTitleChange}></input>
                </div>
                <div className="create-post-body-container">
                    <textarea className="create-post-textarea" placeholder="Body" value={content} onChange={handleContentChange}></textarea>
                </div>
                <div className="create-post-buttons">
                    <button onClick={handlePost} className="create-post-button post">Post</button>
                </div>
            </div>
        </div>
    );
}

export default CreatePost;
