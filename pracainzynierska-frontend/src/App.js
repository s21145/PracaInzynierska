import "./assets/App.css";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
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
import config from "./config.json";

import FriendsList from "./pages/FriendsList/FriendsList";
import FriendRequestWindow from "./pages/FriendsList/FriendRequest/FriendRequestWindow";
import CreatePost from "./pages/Posts/CreatePost/CreatePost";
import { SentFriendRequestResponse } from './Services/UserService'
import { GetFriendsList, GetFriendsListRequests, GetMessages } from './Services/UserService'
import * as signalR from "@microsoft/signalr";
import { LoaderProvider, useLoader } from "./Services/LoaderContext"
import Loader from "./components/Loader/Loader";

function LoaderWrapper() {
  const { isLoading } = useLoader();
  return <Loader isActive={isLoading} />;
}

function App() {
  const MINUTE_MS = 3600000;
  const [user, setUser] = useState(null);
  const [connection, setConnection] = useState(null);
  const value = useMemo(() => ({ user, setUser }), [user, setUser]);
  const [loading, setLoading] = useState(true);

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

  const [isChatWindowVisible, setChatWindowVisible] = useState(false);
  const [currentFriend, setCurrentFriend] = useState(null);
  const [friends, setFriends] = useState([]);
  const [friendRequests, setFriendRequests] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  
  const handleFriendClick = (friend) => {
    setCurrentFriend(friend);
    setChatWindowVisible(true);
  };
  
  const fetchFriendsAndRequests = async () => {
      try {
        setIsLoading(true);
        const [friendsResp, requestsResp] = await Promise.all([
          GetFriendsList(),
          GetFriendsListRequests(),
        ]);
  
        if (friendsResp.status === 200) {
          setFriends(friendsResp.data);
        }
        if (requestsResp.status === 200) {
          setFriendRequests(requestsResp.data);
        }
      } catch {}
      finally{
        setIsLoading(false);
      }
    };

  useEffect(() => {
      const intervalId = setInterval(() => {
        fetchFriendsAndRequests();
      }, 45000);
      return () => clearInterval(intervalId);
    }, []);

  //#endregion

  //#region Friends request window
  const [showFriendRequestWindow, setShowFriendRequestWindow] = useState(false);
  const handleFriendRequestClick = () => {
    setShowFriendRequestWindow(true);
  }

  const closeFriendRequestWindow = () => {
    setShowFriendRequestWindow(false);
  }
  const handleResponse = async (request, status) => {
    try {
      var response = await SentFriendRequestResponse(request.userId, status);
      if (response.status === 200) {
        const friends = await GetFriendsList();
        const updatedRequests = user.requests.filter(req => req.userId !== request.userId);
        setUser(prevUser => ({
          ...prevUser,
          friends: friends.data,
          requests: updatedRequests
        }));
      } else {
        //error
      }
    } catch (ex) {

    }
  }

  //#endregion
  const handleLogin = async () => {
    await fetchFriendsAndRequests();
  }
  useEffect(() => {
    async function reloadUser() {
      if (user === null && GetCurrentUser() !== null) {
        setLoading(true);
        const response = await LoginAfterReload(setUser);

        if (response.status !== 200) {
          Logout();
        } else {
          const friends = await GetFriendsList();
          const requests = await GetFriendsListRequests();
          const age = new Date(response.data.age);
          setUser({
            login: response.data.login,
            image: response.data.image,
            steamId: response.data.steamId,
            age: age,
            description: response.data.description,
            friends: friends.data,
            requests: requests.data,
            userId: response.data.userId
          });
          if (friends.status === 200) {
            setFriends(friends.data);
          }
          if (requests.status === 200) {
            setFriendRequests(requests.data);
          setLoading(false);
          }
        }
      } else {
        setLoading(false);
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


  const ProtectedComponent = ({ children }) => {

    if (!user) {
      return <></>;
    }

    return children;
  };
  const ProtectedRoute = ({ children }) => {

    if (!user) {
      return <Navigate to="/" replace />;
    }

    return children;
  };
  return (
    <>
      <LoaderProvider>
        <UserContext.Provider value={value}>
          <MessageContext.Provider value={messageValue}>
            <statModalContext.Provider value={statModalValue}>
              <Router>
                <div className="main-layout">
                  <LoaderWrapper />
                  <Navbar onLogin={handleLogin} />
                  <div className="content-with-friends">
                    <div className="content">
                    <Routes>
                      <Route path="/" element={<Main handleLogin={handleLogin} />} />
                      <Route path="/?logout" element={<Main />} />

                      {user ? (
                        <>
                          <Route path="/posts" element={<ProtectedRoute><PostsPage /></ProtectedRoute>} />
                          <Route path="/posts/:postId" element={<PostWithComments />} />
                          <Route path="/FindPlayers" element={<FindPlayers />} />
                          <Route path="/contact" element={<ProtectedRoute><Contact /></ProtectedRoute>} />
                          <Route path="/ProfileMain" element={<ProfileMain />} />
                          <Route path="/ProfileMain?steamId" element={<ProfileMain />} />
                          <Route path="/CreatePost" element={<ProtectedRoute><CreatePost /></ProtectedRoute>} />
                        </>
                      ) : (
                        !loading && <Route path="*" element={<Navigate to="/" />} />
                      )}
                    </Routes>
                    </div>
                    <ProtectedComponent>
                    <FriendsList onFriendClick={handleFriendClick} onFriendRequestClick={handleFriendRequestClick} updatedFriends={friends} requests={friendRequests} updateFriends={fetchFriendsAndRequests} />
                    </ProtectedComponent>
                    <ProtectedComponent>
                    {isChatWindowVisible && currentFriend && (
                      <ChatWindow
                        friend={currentFriend}
                        onClose={() => {
                          setChatWindowVisible(false);
                          setCurrentFriend(null);
                        }}
                      />
                    )}
                    </ProtectedComponent>
                  </div>
                  <ProtectedComponent>
                  {showFriendRequestWindow && !isLoading && friendRequests.length > 0 && (
                      <FriendRequestWindow
                        pendingFriendRequests={friendRequests}
                        onClose={closeFriendRequestWindow}
                        onResponse={handleResponse}
                      />
                    )}
                  </ProtectedComponent>
                </div>
              </Router>
            </statModalContext.Provider>
          </MessageContext.Provider>
        </UserContext.Provider>
      </LoaderProvider>
    </>
  );
}

export default App;
