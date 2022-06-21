import { useState } from "react";
import { useParams } from "react-router-dom";

const PostWithComments = ({ posts }) => {
  const { postId } = useParams();
  console.log(postId);
  console.log(posts);
  console.log(posts[0].postId);
  console.log(posts.find((e) => e.postId === postId));
  const post = posts.find((e) => e.postId === postId)[0];
  console.log(post);
  return (
    <div className="post-with-comments-wrapper">
      <div className="post-context">
        <span className="post-title">{post.title}</span>
        <div>{post.context}</div>
        <div className="post-with-comments-button-wrapper"> BUTTONS HERE</div>
      </div>
      <div className="box-comments-wrapper">
        {post.comments.map((item) => (
          <div className="comment-wrapper">
            <div className="comment-top">
              <span>ikonka</span>
              <span>{item.user}</span>
              <span>{item.date}</span>
            </div>
            {item.context}
          </div>
        ))}
      </div>
    </div>
  );
};

export default PostWithComments;
