import React from 'react';
import './PostComment.css';

const formatDate = (dateString) => {
    const options = {
        day: '2-digit', 
        month: '2-digit', 
        year: 'numeric', 
        hour: '2-digit', 
        minute: '2-digit',
        hour12: false 
    };
    const date = new Date(dateString);
    return date.toLocaleString('pl-PL', options).replace(',', '');
}

const PostComment = ({username, date, text,image}) => {
    return (
        <div className="comment-container">
            <div className="comment-header">
                <div> <img src={`data:image/png;base64, ${image}`}></img></div>
                <span className="comment-username">{username}</span>
                <span className="comment-date">{formatDate(date)}</span>

            </div>
            <div className="comment-body">
                {text}
            </div>
            <div></div>
        </div>
    );
}

export default PostComment;