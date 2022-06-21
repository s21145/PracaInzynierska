import '../../App.css';
import React, { useState } from 'react';
import Posts from '../Posts/Posts';
import './PostsPage.css';
import GamesDropdown from '../GamesDropdown/GamesDropdown';

function PostsPage({ posts }) {
    const [selected, setSelected] = useState("Select a game");


    return(
        <div className='page-container'>
            <GamesDropdown selected={selected} setSelected={setSelected}/>
            <Posts posts={posts} />
        </div>
    )
}

export default PostsPage;
