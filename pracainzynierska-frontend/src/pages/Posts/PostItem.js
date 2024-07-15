import React from "react";
import { Link } from "react-router-dom";
import "./Posts.css";

const MAX_LENGTH = 230;

function PostItem({ idUserOwner, title, content, userLogin, postId }) {
  return (
    <div className="posts__item__wrapper">
      <Link to={`/posts/${postId}`} className="link-wrapper">
        <li className="posts__item">
          <div className="posts__item__container">
            <div className="posts__item__postedby">
              <h4>Posted by: {userLogin}</h4>
              {/*<i className="fa-solid fa-ellipsis fa-xl"></i>   -- 3 dots*/}
            </div>
            <div className="posts__item__title">
              <h3>{title}</h3>
            </div>
            {content.length > MAX_LENGTH ? (
              <div className="posts__item__content">
                {`${content.substring(0, MAX_LENGTH)}...`} Read more
              </div>
            ) : (
              <div className="posts__item__content">{content}</div>
            )}
            <div className="posts__item__comments">
              <h2>
                <i className="fa-solid fa-comments"></i> Comments
              </h2>
            </div>
          </div>
        </li>
      </Link>
    </div>
  );
}

export default PostItem;
