import React, { useState, useRef, useEffect } from "react";
import "./Friend.css";
import { RemoveFriend } from "../../../Services/UserService"; 

const Friend = ({ userId, name, imageUrl, isExpanded, onClick, afterRemove }) => {
  const [showMenu, setShowMenu] = useState(false);
  const menuRef = useRef(null);

  useEffect(() => {
    if (!showMenu) return;

    function handleClickOutside(e) {
      if (menuRef.current && !menuRef.current.contains(e.target)) {
        setShowMenu(false);
      }
    }
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, [showMenu]);

  const handleItemClick = () => {
    onClick({ login: name, id: userId, image: imageUrl });
  };

  const handleMenuButtonClick = (e) => {
    e.stopPropagation();
    setShowMenu((prev) => !prev);
  };

  const handleRemoveClick = async (e) => {
    e.stopPropagation();
    const response = await RemoveFriend(userId);
    if (response.status === 200) {
      if (afterRemove) {
        afterRemove();
      }
    }
    setShowMenu(false);
  };

  const handleCloseMenu = (e) => {
    e.stopPropagation();
    setShowMenu(false);
  };

  return (
    <div
      className={`friend-item ${isExpanded ? "expanded" : "shrunk"}`}
      onClick={handleItemClick}
    >
      <img
        className="friend-image"
        alt={name}
        src={`data:image/png;base64, ${imageUrl}`}
      />
      {isExpanded && <span>{name}</span>}

      {isExpanded && (
        <button className="friend-options-button" onClick={handleMenuButtonClick}>
          ...
        </button>
      )}

      {showMenu && (
        <div
          className="friend-options-menu"
          ref={menuRef}
          onClick={(e) => e.stopPropagation()}
        >
          <button onClick={handleRemoveClick}>Remove</button>
          <button onClick={handleCloseMenu}>Close</button>
        </div>
      )}
    </div>
  );
};

export default Friend;
