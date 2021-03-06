import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar/Navbar";
import PostsPage from "./components/pages/PostsPage";
import Footer from "./components/Footer/Footer";
import PostWithComments from "./components/Posts/PostWithComments";
import { useState, useEffect } from "react";
import http from "./components/Services/HttpService";
import config from "./config.json";

function App() {
  const [posts, setPosts] = useState([]);

  async function fetchPosts() {
    try {
      //temporary argument.number means gameid.
      const reqParameters = JSON.stringify({ gameId: 1 });
      const { data } = await http.get(config.apiUrl + "posts", {
        params: { gameId: 1 },
      });
      setPosts(data);
    } catch (error) {
      console.log("error: " + error);
    }
  }

  useEffect(() => {
    fetchPosts();
  }, []);
  return (
    <>
      <Router>
        <Navbar />
        <Routes>
          <Route path="/posts" element={<PostsPage posts={posts} />} />
          <Route
            path="/posts/:postId"
            element={<PostWithComments posts={posts} />}
          />
        </Routes>
        <Footer />
      </Router>
    </>
  );
}

export default App;
