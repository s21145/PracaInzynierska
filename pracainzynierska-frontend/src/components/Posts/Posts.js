import React, { useEffect, useState } from "react";
import PostItem from "../Posts/PostItem";
import "./Posts.css";
import http from "../Services/HttpService.js";
import config from "../config.json";

function Posts() {
  const [posts, setPosts] = useState([
    {
      postId: 0,
      title: "",
      context: "",
      idUserOwner: 0,
      idGame: 0,
      comments: {
        commentId: 0,
        date: "",
        context: "",
        idUser: 0,
      },
    },
  ]);

  async function fetchPosts() {
    try {
      //temporary argument.number means gameid.
      const reqParameters = JSON.stringify({ gameId: 1 });
      const { data } = await http.get(config.apiUrl + "posts", {
        params: { gameId: 1 },
      });
      setPosts(data);
    } catch (error) {
      console.log("error: " + error);
    }
  }

  useEffect(() => {
    fetchPosts();
  }, []);

  return (
    <div className="posts">
      <div className="posts__container">
        <div className="posts__sort__options">
          <div className="posts__sort__wrapper">
            <h1>
              <i className="fa-solid fa-fire" />
              Hot
            </h1>
            <h1>
              <i className="fa-solid fa-certificate" />
              New
            </h1>
            <h1>
              <i className="fa-solid fa-arrow-up-right-dots" />
              Top
            </h1>
          </div>
        </div>
        <div className="posts__wrapper">
          <ul className="posts__items">
            {posts.map((item) => (
              <PostItem key={item.postId}
                idUserOwner={item.idUserOwner}
                title={item.title}
                context={item.context}
              />
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default Posts;
