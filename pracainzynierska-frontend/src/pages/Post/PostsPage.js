import "../../assets/App.css";
import React, { useState, useEffect } from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";
import GamesDropdown from "../GamesDropdown/GamesDropdown";
import { getGames, getPosts } from "../../Services/PostService";

const mockPosts = [
  {
    postId: 1,
    idUserOwner: 1,
    user: "User1",
    title: "Mock Post 1",
    content: "Random words Random wordsRandom wordsRandom wordsRandom wordsRandom wordsRandom wordsRandom wordsRandom wordsRandom words"
  },
  {
    postId: 2,
    idUserOwner: 2,
    user: "User2",
    title: "Mock Post 2",
    content: "This is the content of mock post 2."
  },
  {
    postId: 3,
    idUserOwner: 3,
    user: "User3",
    title: "Mock Post 3",
    content: "This is the content of mock post 3."
  }
];

function PostsPage() {
  const [selected, setSelected] = useState({});
  const [gameOptions, setGameOptions] = useState([]);
  const [posts, setPosts] = useState(mockPosts);

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
