import "../../App.css";
import React from "react";
import Posts from "../Posts/Posts";
import "./PostsPage.css";

function PostsPage({ posts }) {
  return (
    <div className="page-container">
      <Posts posts={posts} />
    </div>
  );
}

export default PostsPage;
