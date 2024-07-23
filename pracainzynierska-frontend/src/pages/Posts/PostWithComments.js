import { useEffect, useState, useRef } from "react";
import { useParams, Link } from "react-router-dom";
import { getPostWithComments,sendComment } from "../../Services/PostService";
import PostComment from "./PostComment";
import './PostWithComments.css';

const PostWithComments = () => {
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
      console.log(post);
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
    console.log("New Comment:", newComment);

    try{
      console.log(postId);
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
    console.log(post);
    setNewComment("");

  };
  useEffect(() => {
    console.log("Post updated:", post);
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
            <div><img src={`data:image/png;base64, ${post.image}`}></img></div>
            <span className="post-header-username">{post.user}</span>
            <span className="post-header-username">{post.date}</span>
          </div>
          <div className="post-header-title">{post.title}</div>
          <div className="post-body">
            {post.content}
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
