import React from 'react'
import PostItem from '../Posts/PostItem'
import './Posts.css';

function Posts() {
  return (
    <div className="posts">
        <div className="posts__container">
          <div className="posts__sort__options">
            <div className="posts__sort__wrapper">
              <h1><i class="fa-solid fa-fire"/>Hot</h1>
              <h1><i class="fa-solid fa-certificate" />New</h1>
              <h1><i class="fa-solid fa-arrow-up-right-dots"/>Top</h1>
            </div>
          </div>
            <div className="posts__wrapper">
                <ul className="posts__items">
                    <PostItem />
                    <PostItem />
                    <PostItem />
                    <PostItem />
                    <PostItem />
                    <PostItem />
                    <PostItem />

                </ul>
            </div>
        </div>
    </div>
  )
}

export default Posts