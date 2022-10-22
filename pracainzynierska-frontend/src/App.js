import "./assets/App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";
import PostsPage from "./pages/Post/PostsPage";
import Footer from "./pages/Footer/Footer";
import PostWithComments from "./pages/Posts/PostWithComments";
import Main from "./pages/Main/Main";
import { useState, useEffect } from "react";
import http from "./Services/HttpService";
import Contact from "./pages/Contact/Contact";
import config from "./config.json";
import { UserContext } from "./Services/UserContext";
import { useMemo } from "react";

function App() {
  const [user, setUser] = useState(null);
  const value = useMemo(() => ({ user, setUser }), [user, setUser]);
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
      <UserContext.Provider value={value}>
        <Router>
          <Navbar />
          <Routes>
            <Route path="/posts" element={<PostsPage posts={posts} />} />
            <Route
              path="/posts/:postId"
              element={<PostWithComments posts={posts} />}
            />

            <Route path="/main" element={<Main />} />
            <Route path="/contact" element={<Contact />} />
          </Routes>

          <Footer />
        </Router>
      </UserContext.Provider>
    </>
  );
}

export default App;
