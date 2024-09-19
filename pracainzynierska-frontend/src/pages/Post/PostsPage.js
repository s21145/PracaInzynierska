import "../../assets/App.css";
import React, { useState, useEffect, useRef, useCallback } from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";
import GamesDropdown from "../GamesDropdown/GamesDropdown";
import { getGames, getPosts,getPostsForMainPage } from "../../Services/PostService";
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
  const [posts, setPosts] = useState([]);
  const [page, setPage] = useState(0);
  const [isLoading, setIsLoading] = useState(false);
  const [createPost, setCreatePost] = useState(false);

  const observer = useRef();

  const lastPostElementRef = useCallback(node => {
    if (isLoading) return;
    if (observer.current) observer.current.disconnect();
    observer.current = new IntersectionObserver(entries => {
      if (entries[0].isIntersecting && posts.length >= 10) {
        setPage(prevPage => prevPage + 1);
      }
    });
    if (node) observer.current.observe(node);
  }, [isLoading, posts]);

  useEffect(() => {
    const fetchGames = async () => {
      const games = await getGames();
      setGameOptions(games.data);
    };
    fetchGames();
  }, []);
  useEffect(() => {
    const fetchMainPagePosts = async () => {
      await reloadPosts(0);
    };
    fetchMainPagePosts();
  }, []);
  useEffect(() => {
    const fetchPosts = async () => {
      if (Object.keys(selected).length === 0) return;
      setPage(0);
      setPosts([]);
      await reloadPosts(0);
    };
    fetchPosts();
  }, [selected]);

  const openCreatePostModal = () => {
    setCreatePost(true);
  };

  const reloadPosts = async (pageNumber) => {
    setIsLoading(true);
    var query = [];
    if(selected.name){
      query = await getPosts(selected.name, pageNumber);
    }else{
      query = await getPostsForMainPage(page);
    }
    
    setIsLoading(false);
    if (query.status !== 200) {
      setPosts(null);
    } else {
      setPosts(prevPosts => [...prevPosts, ...query.data]);
    }
  };
  const handleAddPost = async (postToAdd) => {
    console.log(postToAdd);
    setPosts(prevPosts => [ postToAdd, ...prevPosts]);
  }
  useEffect(() => {
    if (page > 0) {
      reloadPosts(page);
    }
  }, [page]);

  return (
    <div className="page-container">
      {createPost && <CreatePost closeModal={setCreatePost}  AddPost={handleAddPost}/>}
      <div className="page-container-search-bar">
        <GamesDropdown
          selected={selected}
          setSelected={setSelected}
          gameOptions={gameOptions}
        />
      </div>
      <Posts posts={posts} openCreatePostModal={openCreatePostModal} lastPostElementRef={lastPostElementRef} />
    </div>
  );
}

export default PostsPage;
