import "./assets/App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";
import PostsPage from "./pages/Post/PostsPage";
import Footer from "./pages/Footer/Footer";
import PostWithComments from "./pages/Posts/PostWithComments";
import Main from "./pages/Main/Main";
import ProfileMain from "./pages/ProfileMain/ProfileMain";
import FindPlayers from "./pages/FindPlayers/FindPlayers";
import { useState, useEffect } from "react";
import Contact from "./pages/Contact/Contact";
import { UserContext } from "./Services/UserContext";
import { MessageContext } from "./Services/MessageContext";
import { statModalContext } from "./Services/StatsModalContext";
import ChatWindow from "./components/ChatWindow/ChatWindow";
import { useMemo } from "react";
import {
  GetCurrentUser,
  LoginAfterReload,
  Logout,
  RefreshToken,
} from "./Services/UserService";

import FriendsList from "./pages/FriendsList/FriendsList";
import FriendRequestWindow from "./pages/FriendsList/FriendRequest/FriendRequestWindow";

function App() {
  const MINUTE_MS = 60000;
  const [user, setUser] = useState(null);
  const value = useMemo(() => ({ user, setUser }), [user, setUser]);

  const [message, setMessage] = useState({
    content: "",
    show: false,
  });
  const messageValue = useMemo(
    () => ({ message, setMessage }),
    [message, setMessage]
  );

  const [statModal, setStatModal] = useState({
    stats: {},
    userName: null,
    show: false,
  });
  const statModalValue = useMemo(
    () => ({ statModal, setStatModal }),
    [statModal, setStatModal]
  );


  //#region Chat window
  const [messages, setMessages] = useState([
    { sender: 'me', text: 'Czy bidi jest dobrym kolegą?' },
    { sender: 'friend', text: 'Jak najbardziej, czemu pytasz?' },
  ]);

  const handleSend = (text) => {
    setMessages([...messages, { sender: 'me', text }]);
  };

  const [isChatWindowVisible, setChatWindowVisible] = useState(false);
  const [currentFriend, setCurrentFriend] = useState('');

  const handleClose = () => {
    setChatWindowVisible(false);
  };

  const handleFriendClick = (friendName) => {
    setCurrentFriend(friendName);
    setChatWindowVisible(true);
  };
  //#endregion

  //#region Friends request window
  const [showFriendRequestWindow, setShowFriendRequestWindow] = useState(false);
  const handleFriendRequestClick = () => {
    setShowFriendRequestWindow(true);
  }

  const closeFriendRequestWindow = () => {
      setShowFriendRequestWindow(false);
  }
  //#endregion

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
  }, [user]);

  useEffect(() => {
    const interval = setInterval(() => {
      if (user === null) {
        return;
      }
      const response = RefreshToken();
      if (response.status !== 200) {
        Logout();
      }
    }, MINUTE_MS);

    return () => clearInterval(interval);
  }, [user]);

  return (
    <>
      <UserContext.Provider value={value}>
        <MessageContext.Provider value={messageValue}>
          <statModalContext.Provider value={statModalValue}>
            <Router>
              <div className="main-layout">
                <Navbar />
                <div className="content-with-friends">
                  <div className="content">
                    <Routes>
                      <Route path="/posts" element={<PostsPage />} />
                      <Route path="/posts/:postId" element={<PostWithComments />} />
                      <Route path="/FindPlayers" element={<FindPlayers />} />
                      <Route path="/" element={<Main />} />
                      <Route path="/?logout" element={<Main />} />
                      <Route path="/contact" element={<Contact />} />
                      <Route path="/ProfileMain" element={<ProfileMain />} />
                      <Route path="/ProfileMain?steamId" element={<ProfileMain />} />
                    </Routes>
                  </div>
                  <FriendsList onFriendClick={handleFriendClick} onFriendRequestClick={handleFriendRequestClick} />
                  {isChatWindowVisible && (
                    <ChatWindow
                      messages={messages}
                      onClose={handleClose}
                      onSend={handleSend}
                      friendName={currentFriend}
                    />
                  )}
                </div>
                {showFriendRequestWindow && <FriendRequestWindow onClose={closeFriendRequestWindow} />}
              </div>
            </Router>
          </statModalContext.Provider>
        </MessageContext.Provider>
      </UserContext.Provider>
    </>
  );
}

export default App;
