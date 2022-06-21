import '../../App.css';
import React, { useState } from 'react';
import Posts from '../Posts/Posts';
import './PostsPage.css';
import GamesDropdown from '../GamesDropdown/GamesDropdown';

function PostsPage() {
    const [selected, setSelected] = useState("Select a game");


    return(
        <div className='page-container'>
            <GamesDropdown selected={selected} setSelected={setSelected}/>
            <Posts />
        </div>
    )
}

export default PostsPage;