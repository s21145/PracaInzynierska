import React, { useEffect, useRef} from 'react';
import { UserContext } from "../../Services/UserContext";
import { useContext } from "react";
import './ChatWindow.css';

const ChatWindow = ({messages, onClose, onSend, friendName, friendIcon}) => {

    console.log(messages);
    const [newMessage, setNewMessage] = React.useState('');
    const { user } = useContext(UserContext);
    const chatBodyRef = useRef(null);

    const handleSend = () => {
        if(newMessage.trim()){
            onSend(newMessage);
            setNewMessage('');
        }
    };

    const handleEnterPress = (event) => {
        if(event.key === 'Enter'){
            handleSend();
        }
    };

    useEffect(() => {
        if(chatBodyRef.current){
            chatBodyRef.current.scrollTop = chatBodyRef.current.scrollHeight
        }
    }, [messages])

    return(
        <div className="chat-window">
            <div className="chat-header">
                <span>
                    {friendName}
                </span>
                <button className="close-button" onClick={onClose}>X</button>
            </div>
            <div className="chat-body" ref={chatBodyRef}>
            {messages.map((msg, index) => (
          <div key={index} className={`chat-bubble ${msg.senderLogin === user.login ? 'me' : 'friend'}`}>
            {msg.senderLogin !== user.login && (
                <div>
                    <div
                    className="friend-chat-image"
                    style={{
                    backgroundImage: `url(data:image/png;base64,${
                        user && user.image
                    })`,
                    }}
                ></div>
              </div>
            )} {msg.content}
          </div>
        ))}
            </div>
            <div className="chat-input-container">
                <input type="text" value={newMessage} onChange={(e) => setNewMessage(e.target.value)} onKeyPress={handleEnterPress} placeholder="Message..."></input>
                <button onClick={handleSend}>{'>'}</button>
            </div>
        </div>
    );
};

export default ChatWindow;