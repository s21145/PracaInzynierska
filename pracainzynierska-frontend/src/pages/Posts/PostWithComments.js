import { useState } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";

const PostWithComments = ({ posts }) => {
  const { postId } = useParams();
  const post = posts.find((e) => e.postId === parseInt(postId));
  console.log(post);
  return (
    <div className="post-wrapper">
      <div className="back-to-post-wrapper">
        {post.title}{" "}
        <Link to="/posts">
          <i className="fa-solid fa-arrow-left"></i>
        </Link>
      </div>
      <div className="post-with-comments-wrapper">
        <div className="post-content">
          <span className="post-title">{post.title}</span>
          <div>{post.context}</div>
          <div className="post-with-comments-button-wrapper"> BUTTONS HERE</div>
        </div>

        <div className="box-comments-wrapper">
          {post.comments.map((item) => (
            <div key={item.commentId} className="comment-wrapper">
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
    </div>
  );
};

export default PostWithComments;
