import React, { useEffect, useRef, useState, useContext, forwardRef, useImperativeHandle } from "react";
import { UserContext } from "../../Services/UserContext";
import * as signalR from "@microsoft/signalr";
import { GetMessages } from "../../Services/UserService";
import config from "../../config.json";
import "./ChatWindow.css";

const ChatWindow = forwardRef(({ friend, onClose }, ref) => {
  const { user } = useContext(UserContext);
  const [messages, setMessages] = useState([]);
  const [newMessage, setNewMessage] = useState("");
  const [connection, setConnection] = useState(null);
  const chatBodyRef = useRef(null);

  useImperativeHandle(ref, () => ({
    clearConnection: () => {
      if (connection) {
        connection.stop();
      }
    },
  }));

  useEffect(() => {
    if (!friend || !user) return;

    if (connection) {
      connection.stop();
    }

    const conn = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.None)
      .withUrl(config.chatUrl)
      .withAutomaticReconnect()
      .build();

    conn.on("SpecificMessage", (msg) => {
      if (msg.sender === user.login) {
        return;
      }
      setMessages((prev) => [
        ...prev,
        {
          senderLogin: msg.sender,
          content: msg.message.content,
          messageDate: msg.message.messageDate,
        },
      ]);
    });

    (async () => {
      try {
        await conn.start();
        const response = await GetMessages(friend.login, 0);
        if (response.status === 200) {
          setMessages(response.data);
        }
        const roomName = [user.login, friend.login].sort().join("");
        await conn.invoke("JoinSpecificChatRoom", {
          username: user.login,
          chatRoom: roomName,
        });
      } catch (err) {
        console.error("Error establishing chat connection:", err);
      }
    })();

    setConnection(conn);

    return () => {
      conn.stop();
    };
  }, [friend, user]);

  useEffect(() => {
    if (chatBodyRef.current) {
      chatBodyRef.current.scrollTop = chatBodyRef.current.scrollHeight;
    }
  }, [messages]);

  const handleSend = async () => {
    if (!connection || !newMessage.trim()) return;
    try {
      const chatRoom = [user.login, friend.login].sort().join("");
      await connection.invoke(
        "SendMessage",
        newMessage,
        chatRoom,
        user.userId,
        user.login,
        friend.id
      );
      setMessages((prev) => [
        ...prev,
        { senderLogin: user.login, content: newMessage, messageDate: new Date() },
      ]);
      setNewMessage("");
    } catch (error) {
      console.error("Error sending message:", error);
    }
  };

  const handleKeyDown = (event) => {
    if (event.key === "Enter") {
      event.preventDefault();
      handleSend();
    }
  };

  const handleClose = () => {
    if (connection) {
      connection.stop();
    }
    onClose();
  };

  return (
    <div className="chat-window">
      <div className="chat-header">
        <span>{friend.login}</span>
        <button className="close-button" onClick={handleClose}>X</button>
      </div>
      <div className="chat-body" ref={chatBodyRef}>
        {messages.map((msg, index) => (
          <div
            key={index}
            className={`chat-bubble ${msg.senderLogin === user.login ? "me" : "friend"}`}
          >
            {msg.senderLogin !== user.login && (
              <div>
                <div
                  className="friend-chat-image"
                  style={{ backgroundImage: `url(data:image/png;base64,${user?.image})` }}
                ></div>
              </div>
            )}
            {msg.content}
          </div>
        ))}
      </div>
      <div className="chat-input-container">
        <input
          type="text"
          value={newMessage}
          onKeyDown={handleKeyDown}
          onChange={(e) => setNewMessage(e.target.value)}
          placeholder="Type a message..."
        />
        <button onClick={handleSend}>{">"}</button>
      </div>
    </div>
  );
});

export default ChatWindow;
