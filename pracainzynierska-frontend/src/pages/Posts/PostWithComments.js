import { useEffect, useState, useRef } from "react";
import { useParams, Link } from "react-router-dom";
import { getPostWithComments,sendComment } from "../../Services/PostService";
import PostComment from "./PostComment";
import './PostWithComments.css';
import { useLoader } from "../../Services/LoaderContext";

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

const PostWithComments = () => {
  const { postId } = useParams();
  const [post, setPost] = useState({});
  const [isAddingComment, setIsAddingComment] = useState(false);
  const [newComment, setNewComment] = useState("");
  const { startLoading, stopLoading} = useLoader();
  const textAreaRef = useRef(null);

  const fetchPost = async () => {
    try{
      startLoading();
      const response = await getPostWithComments(postId);
      if (response.status !== 200) {
        // error
      } else {
        setPost(response.data);
      }
    }
    catch(err){
      
    }
    finally{
      stopLoading();
    }
  };

  useEffect(() => {
    fetchPost();
  }, []);

  useEffect(() => {
    if (isAddingComment) {
      textAreaRef.current?.focus();
    }
  }, [isAddingComment]);

  const handleAddCommentClick = () => {
    setIsAddingComment(true);
  };

  const handleCancelClick = () => {
    setIsAddingComment(false);
    setNewComment("");
  };

  const handleConfirmClick = async () => {
    try{

      var response = await sendComment(postId,newComment)
      if(response.status===200){
        setPost(prevPost => ({
          ...prevPost,
          comments: [...prevPost.comments,response.data]
        }));
      }

    }catch(ex){
      //console.log(ex);
    }
 
    setIsAddingComment(false);

    setNewComment("");
  };
  useEffect(() => {
  }, [post]);

  

  return (
    <div className="post-with-comments-wrapper">
      <div className="content-wrapper">
        <div className="back-to-post-wrapper">
          <Link to="/posts">
            <i className="fa-solid fa-arrow-left"></i>
          </Link>
        </div>
        <div className="post-comment-content">
          <div className="post-header">
            <div><img className="post-header-image" src={`data:image/png;base64, ${post.image}`}></img></div>
            <span className="post-header-username">{post.user}</span>
            <span className="post-header-username">{formatDate(post.date)}</span>
          </div>
          <div className="post-header-title">{post.title}</div>
          <div className="post-body">
            {post.content}
          </div>
          <div className="post-footer">
            <span className="post-footer-likes">3 <i class="fa-solid fa-heart"></i></span>
          </div>
        </div>
        <div className="post-comment-new-comment">
          {isAddingComment ? (
            <div className="comment-input-container">
              <textarea
                ref={textAreaRef}
                className="post-comment-textarea"
                value={newComment}
                onChange={(e) => setNewComment(e.target.value)}
              ></textarea>
              <div className="comment-buttons">
                <button onClick={handleCancelClick}>Cancel</button>
                <button onClick={handleConfirmClick}>Confirm</button>
              </div>
            </div>
          ) : (
            <div className="post-comment-add" onClick={handleAddCommentClick}>
              Add Comment
            </div>
          )}
        </div>
        <div className="post-comment-section-header-wrapper">
          <span className="post-comment-section-header">Comments</span>
        </div>
        <div className="post-comment-section">
          {Object.keys(post).length !== 0 &&
            post.comments.map((item) => (
              <PostComment
                username={item.user}
                date={item.date}
                text={item.content}
                image={item.image}
              />
            ))}
        </div>
      </div>
    </div>
  );
};

export default PostWithComments;
