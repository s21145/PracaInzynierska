import "./assets/App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";
import PostsPage from "./pages/Post/PostsPage";
import Footer from "./pages/Footer/Footer";
import PostWithComments from "./pages/Posts/PostWithComments";
import Main from "./pages/Main/Main";
import ProfileMain from "./pages/ProfileMain/ProfileMain";
import { useState, useEffect } from "react";
import http from "./Services/HttpService";
import Contact from "./pages/Contact/Contact";
import config from "./config.json";
import { UserContext } from "./Services/UserContext";
import { useMemo } from "react";
import {
  GetCurrentUser,
  LoginAfterReload,
  Logout,
  RefreshToken,
} from "./Services/UserService";

function App() {
  const MINUTE_MS = 60000;
  const [user, setUser] = useState(null);
  const value = useMemo(() => ({ user, setUser }), [user, setUser]);
  const [posts, setPosts] = useState([]);
  useEffect(() => {
    async function reloadUser() {
      if (user === null && GetCurrentUser() !== null) {
        const response = await LoginAfterReload(setUser);
        if (response.status !== 200) {
          Logout();
        } else {
          const age = new Date(response.data.age);
          setUser({
            login: response.data.login,
            image: response.data.image,
            steamId: response.data.steamId,
            age: age,
            description: response.data.description,
          });
        }
      }
    }
    reloadUser();
  });
  useEffect(() => {
    const interval = setInterval(() => {
      if (user === null) {
        return;
      }
      console.log("Logs every minute");
      const response = RefreshToken();
      if (response.status !== 200) {
        Logout();
      }
    }, MINUTE_MS);

    return () => clearInterval(interval);
  }, [user]);
  async function fetchPosts() {
    try {
      //to delete
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

            <Route path="/" element={<Main />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="/ProfileMain" element={<ProfileMain />} />
          </Routes>

          <Footer />
        </Router>
      </UserContext.Provider>
    </>
  );
}

export default App;
