import React, { forwardRef } from "react";
import { Link } from "react-router-dom";
import "./Posts.css";

const MAX_LENGTH = 230;

const PostItem = forwardRef(({ idUserOwner, title, content, userLogin, postId }, ref) => {
  return (
    <div className="posts__item__wrapper" ref={ref}>
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
          <div className="posts__item__footer">
            <div className="posts__item__comments">
              <Link to={`/posts/${postId}`} className="link-wrapper">
                <h2>
                  <i className="fa-solid fa-comments"></i> Comments
                </h2>
              </Link>
            </div>
            <div className="posts__item__likes">
              <h2>3 <i className="fa-solid fa-heart"></i></h2>
            </div>
          </div>
        </div>
      </li>
    </div>
  );
});

export default PostItem;
