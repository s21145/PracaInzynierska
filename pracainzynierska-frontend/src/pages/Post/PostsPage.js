import "../../assets/App.css";
import React, { useState, useEffect } from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";
import GamesDropdown from "../GamesDropdown/GamesDropdown";
import { getGames, getPosts } from "../../Services/PostService";

function PostsPage() {
  const [selected, setSelected] = useState({});
  const [gameOptions, setGameOptions] = useState([]);
  const [posts, setPosts] = useState(null);

  useEffect(() => {
    const fetchGames = async () => {
      const games = await getGames();
      setGameOptions(games.data);
    };
    fetchGames();
  }, []);

  useEffect(() => {
    const fetachPosts = async () => {
      if (Object.keys(selected).length === 0) return;
      const query = await getPosts(selected.name);
      if (query.status !== 200) {
        setPosts(null);
      } else {
        setPosts(query.data);
      }
    };
    fetachPosts();
  }, [selected]);
  return (
    <div className="page-container">
      <GamesDropdown
        selected={selected}
        setSelected={setSelected}
        gameOptions={gameOptions}
      />
      <Posts posts={posts} />
    </div>
  );
}

export default PostsPage;
