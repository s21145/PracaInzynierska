import React from 'react'
import { Link } from 'react-router-dom';
import './Posts.css';

function PostItem() {
  return (
    <>
        <li className="posts__item">
            <div className="posts__item__container">
                <div className="posts__item__postedby">
                    <h4>Posted by: User1</h4>
                    <i class="fa-solid fa-ellipsis fa-xl"></i>
                </div>
                <div className="posts__item__title">
                    <h3>Example Title</h3>
                </div>
                <div className="posts__item__content">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. 
                    Iste numquam blanditiis repellat a quibusdam aperiam.
                </div>
                <div className='posts__item__comments'>
                    <Link to='/' className="posts__item__comments__link">
                        <h2>
                            <i class="fa-solid fa-comments"></i> Comments
                        </h2>
                    </Link>
                </div>
            </div>
        </li>
    </>
  )
}

export default PostItem

/*


<Link to='/' className="posts__item__link">
                <div className="posts__item__info">
                    <h5 className="posts__item__text">
                        tmp
                    </h5>
                </div>
            </Link>

*/