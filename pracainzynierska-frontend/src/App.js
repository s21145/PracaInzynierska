import "./assets/App.css";
import { BrowserRouter as Router, Routes, Route,Navigate } from "react-router-dom";
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
import CreatePost from "./pages/Posts/CreatePost/CreatePost";
import {SentFriendRequestResponse} from './Services/UserService'
import {GetFriendsList,GetFriendsListRequests,GetMessages} from './Services/UserService'
import * as signalR from "@microsoft/signalr";

function App() {
  const MINUTE_MS = 3600000;
  const [user, setUser] = useState(null);
  const [connection, setConnection] = useState(null);
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
  const [messages, setMessages] = useState([]);
  const [currentChatRoom,setCurrentChatRoom]= useState("");

  const handleSend = async (message) => {
    if (connection && message && user) {
      console.log(message);
      sendMessage(message);
  }
    //setMessages([...messages, { sender: 'me', text:message }]);
  };
  const sendMessage = async(message) => {
    try{
      

      await connection.invoke("SendMessage",message,currentChatRoom,user.userId,user.login,currentFriend.id);
    }catch(e){
      console.log(e);
    }
  }


  const [isChatWindowVisible, setChatWindowVisible] = useState(false);
  const [currentFriend, setCurrentFriend] = useState('');

  const handleClose = () => {
    setChatWindowVisible(false);
    setCurrentChatRoom("");
    setConnection(null);
  };

  const handleFriendClick = async (body) => {
    setCurrentFriend(body);
    try{
      var startMessages = await GetMessages(body.login,0);
      console.log(startMessages);
      if(startMessages.status===200){
        setMessages(startMessages.data);
      }

    }catch(e){
      console.log(e);
    }
    console.log(user);
    const conn = new signalR.HubConnectionBuilder()
            .configureLogging(signalR.LogLevel.Information)
            .withUrl("https://localhost:7194/chatHub")
            .withAutomaticReconnect()
            .build();

     conn.on("JoinSpecificChatRoom",(username,msg) => {
      console.log("msg: ",msg);
     });
     conn.on("SpecificMessage",(msg) => {
      setMessages(messages => [...messages,
        {senderLogin:msg.sender,
        content:msg.message.content,
        messageDate:msg.message.messageDate
      }]);
     })

     var createChatRoom = [user.login,body.login].sort();
     var chatRoom = createChatRoom[0]+createChatRoom[1];
     setCurrentChatRoom(chatRoom);
     await conn.start();
     await conn.invoke("JoinSpecificChatRoom", {username: user.Login,chatRoom: chatRoom});
        setConnection(conn);
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
  const handleResponse = async (request,status) => {
    try {
        var response = await SentFriendRequestResponse(request.userId,status);
        if(response.status === 200){
          const friends = await GetFriendsList();
          const updatedRequests = user.requests.filter(req => req.userId !== request.userId);
            setUser(prevUser => ({
          ...prevUser,
            friends:friends.data,
          requests: updatedRequests
         }));
        }else{
          //error
        }
    }catch(ex){

    }
}

  //#endregion

  useEffect(() => {
    async function reloadUser() {
      if (user === null && GetCurrentUser() !== null) {
        const response = await LoginAfterReload(setUser);
        const friends = await GetFriendsList();
        const requests = await GetFriendsListRequests();
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
            friends:friends.data,
            requests:requests.data,
            userId:response.data.userId
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
  const ProtectedComponent = ({ children }) => {
  
    if (!user) {
      return <></>;
    }
  
    return children;
  };
  const ProtectedRoute  = ({ children }) => {
  
    if (!user) {
      return <Navigate to="/" replace />;
    }
  
    return children;
  };

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
                      <Route path="/FindPlayers" element={<FindPlayers/>} />
                      <Route path="/" element={<Main/>} />
                      <Route path="/?logout" element={<Main/>}/>
                      <Route path="/contact" element={<ProtectedRoute><Contact /></ProtectedRoute>} />
                      <Route path="/ProfileMain" element={<ProfileMain />} />
                      <Route path="/ProfileMain?steamId" element={<ProfileMain />} />
                      <Route path="/CreatePost" element={<ProtectedRoute><CreatePost /></ProtectedRoute>} />
                    </Routes>
                  </div>
                  <ProtectedComponent>
                  <FriendsList onFriendClick={handleFriendClick} onFriendRequestClick={handleFriendRequestClick} />
                  </ProtectedComponent>
                  <ProtectedComponent>
                  {isChatWindowVisible && (
                    <ChatWindow
                      messages={messages}
                      onClose={handleClose}
                      onSend={handleSend}
                      friendName={currentFriend.login}
                      friend={currentFriend}
                    />
                  )}
                  </ProtectedComponent>
                </div>
                <ProtectedComponent>
                {showFriendRequestWindow  && <FriendRequestWindow pendingFriendRequests={user.requests} 
                onClose={closeFriendRequestWindow} onResponse={handleResponse} />}
                </ProtectedComponent>
              </div>
            </Router>
          </statModalContext.Provider>
        </MessageContext.Provider>
      </UserContext.Provider>
    </>
  );
}

export default App;
