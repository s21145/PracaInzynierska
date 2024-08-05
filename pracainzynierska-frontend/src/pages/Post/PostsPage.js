import "../../assets/App.css";
import React, { useState, useEffect } from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";
import GamesDropdown from "../GamesDropdown/GamesDropdown";
import { getGames, getPosts } from "../../Services/PostService";

import CreatePost from "../Posts/CreatePost/CreatePost";

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

  const [createPost, setCreatePost] = useState(false);

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
     await reloadPosts();
    };
    fetachPosts();
  }, [selected]);

  const openCreatePostModal = () =>{
    setCreatePost(true);
  }
  const reloadPosts = async () => {
    const query = await getPosts(selected.name);
    if (query.status !== 200) {
      setPosts(null);
    } else {
      console.log(query.data);
      setPosts(query.data);
    }
  }
  useEffect(() => {
    const reload = async () => {
     if(createPost==false){
      console.log("reload");
       await reloadPosts();
     }
    };
    reload();
  }, [createPost]);

  return (
    <div className="page-container">
      {createPost && <CreatePost closeModal={setCreatePost} />} 
      <div className="page-container-search-bar">
        <GamesDropdown
          selected={selected}
          setSelected={setSelected}
          gameOptions={gameOptions}
        />
      </div>
      <Posts posts={posts}  openCreatePostModal={openCreatePostModal}/>
    </div>
  );
}

export default PostsPage;
