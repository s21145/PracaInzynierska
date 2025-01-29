import "../../assets/App.css";
import React, { useState, useEffect, useRef, useCallback } from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";
import GamesDropdown from "../GamesDropdown/GamesDropdown";
import { getGames, getPosts,getPostsForMainPage, unlikePost } from "../../Services/PostService";
import CreatePost from "../Posts/CreatePost/CreatePost";
import { likePost } from "../../Services/PostService";
import { UserContext } from "../../Services/UserContext";
import { useContext } from "react";
import { useLoader } from "../../Services/LoaderContext";


function PostsPage() {
  const [selected, setSelected] = useState({});
  const [gameOptions, setGameOptions] = useState([]);
  const [posts, setPosts] = useState([]);
  const [page, setPage] = useState(0);
  const [isLoading, setIsLoading] = useState(false);
  const [createPost, setCreatePost] = useState(false);
  const { user } = useContext(UserContext);
  const { startLoading, stopLoading} = useLoader();
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
    try{
      startLoading()
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
    }
    catch(err){

    }
    finally{
      stopLoading();
    }
  };

  const handleAddPost = async (postToAdd) => {
    setPosts(prevPosts => [ postToAdd, ...prevPosts]);
  }

  useEffect(() => {
    if (page > 0) {
      reloadPosts(page);
    }
  }, [page]);

  const handlePostLike = async (postId) => {
    try {
      const response = await likePost(user.userId, postId);
      if (response.status === 200) {
        setPosts((prevPosts) =>
          prevPosts.map((post) =>
            post.postId === postId ? { ...post, isLiked: true, likes:post.likes+1 } : post
          )
        );

      } else {
          //console.error("Failed to like post", response);
      }
  } catch (error) {
      //console.error("Error during like process :", error);
  }
  }
  const handlePostUnlike = async (postId) => {
    try{
      const response = await unlikePost(user.userId, postId);
      if (response.status === 200) {
        setPosts((prevPosts) =>
          prevPosts.map((post) =>
            post.postId === postId ? { ...post, isLiked: false, likes:post.likes-1 } : post
          )
        );

      } else {
          console.error("Failed to unlike post", response);
      }
    }catch(error){
      console.error("Error during unlike process :", error);
    }
  }

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
      <Posts posts={posts} handlePostLike={handlePostLike} handlePostUnlike={handlePostUnlike} openCreatePostModal={openCreatePostModal} lastPostElementRef={lastPostElementRef} />
    </div>
  );
}

export default PostsPage;
