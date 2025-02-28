import React from 'react';
import PostItem from './PostItem';

function Posts({ posts, openCreatePostModal, lastPostElementRef,handlePostLike,handlePostUnlike }) {
  return (
    <div className="posts">
      <div className="posts__container">
        <div className="posts__sort__options">
          <button className="create__new__post__button" onClick={openCreatePostModal}>Create</button>
        </div>
        <div className="posts__wrapper">
          <ul className="posts__items">
            {posts &&
              posts.map((item, index) => (
                <PostItem
                  handlePostLike={handlePostLike}
                  handlePostUnlike={handlePostUnlike}
                  key={item.postId}
                  idUserOwner={item.idUserOwner}
                  userLogin={item.user}
                  title={item.title}
                  content={item.content}
                  postId={item.postId}
                  likes={item.likes}
                  isLiked={item.isLiked}
                  ref={index === posts.length - 1 ? lastPostElementRef : null}
                />
              ))}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default Posts;
