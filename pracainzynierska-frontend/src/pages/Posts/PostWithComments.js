import { useEffect, useState, useRef,useContext } from "react";
import { useParams, Link } from "react-router-dom";
import { getPostWithComments,sendComment,likePost,unlikePost } from "../../Services/PostService";
import PostComment from "./PostComment";
import './PostWithComments.css';
import { UserContext } from "../../Services/UserContext";

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
  const { user } = useContext(UserContext);
  const { postId } = useParams();
  const [post, setPost] = useState({});
  const [isAddingComment, setIsAddingComment] = useState(false);
  const [newComment, setNewComment] = useState("");
  const textAreaRef = useRef(null);

  const fetchPost = async () => {
    const response = await getPostWithComments(postId);
    if (response.status !== 200) {
      // error
    } else {
      setPost(response.data);

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
      console.log(ex);
    }
 
    setIsAddingComment(false);

    setNewComment("");

  };
  useEffect(() => {
  }, [post]);
  const handlePostLike = async (postId) => {
    try {
      console.log(user.userId,postId);
      const response = await likePost(user.userId, postId);
      if (response.status === 200) {
        setPost(prevPost => ({
          ...prevPost,
          isLiked: true, 
          likes:post.likes+1
        }));

      } else {
          console.error("Failed to like post", response);
      }
  } catch (error) {
      console.error("Error during like process :", error);
  }
  }
  const handlePostUnlike = async (postId) => {
    try{
      const response = await unlikePost(user.userId, postId);
      if (response.status === 200) {
        setPost(prevPost => ({
          ...prevPost,
          isLiked: false, 
          likes:post.likes-1
        }));

      } else {
          console.error("Failed to unlike post", response);
      }
    }catch(error){
      console.error("Error during unlike process :", error);
    }
  }

  

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
            <div>  {post.image && (
    <img className="post-header-image" src={`data:image/png;base64, ${post.image}`} alt="Post" />
  )}</div>
            <span className="post-header-username">{post.user}</span>
            <span className="post-header-username">{formatDate(post.date)}</span>
          </div>
          <div className="post-header-title">{post.title}</div>
          <div className="post-body">
            {post.content}
          </div>
          <div className="post-footer">
          <span>{post.likes}</span>
          <span>{post.isLiked ?  <i className="fa-solid fa-heart" onClick={() => handlePostUnlike(post.postId)}></i> : <i className="fa-regular fa-heart"onClick={() => handlePostLike(post.postId)}></i>}</span>
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
            post.comments.map((item,index) => (
              <PostComment
              key = {index}
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
