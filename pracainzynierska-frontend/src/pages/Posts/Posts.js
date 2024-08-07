import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import PostItem from "./PostItem";
import "./Posts.css";
import { getPosts } from "../../Services/PostService";

function Posts({ posts }) {
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
            {posts &&
              posts.map((item) => (
                <PostItem
                  key={item.postId}
                  idUserOwner={item.idUserOwner}
                  userLogin={item.user}
                  title={item.title}
                  content={item.content}
                  postId={item.postId}
                />
              ))}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default Posts;
