import "../../assets/App.css";
import React, { useState } from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";
import GamesDropdown from "../GamesDropdown/GamesDropdown";

function PostsPage({ posts }) {
  const [selected, setSelected] = useState({});

  return (
    <div className="page-container">
      <GamesDropdown selected={selected} setSelected={setSelected} />
      <Posts posts={posts} selectedGame={selected} />
    </div>
  );
}

export default PostsPage;
