import { useEffect } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import { getPostWithComments } from "../../Services/PostService";

const PostWithComments = () => {
  const { postId } = useParams();
  const [post, setPost] = useState({});
  const fetchPost = async () => {
    const response = await getPostWithComments(postId);
    if (response.status !== 200) {
      // blad
    } else {
      setPost(response.data);
      console.log(post);
    }
  };
  useEffect(() => {
    fetchPost();
  }, []);
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
          {Object.keys(post).length !== 0 &&
            post.comments.map((item) => (
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
