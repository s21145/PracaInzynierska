import React from "react";
import "./Loader.css";

const Loader = ({ isActive }) => {
  if (!isActive) return null;

  return (
    <div className="loader-overlay">
      <div className="loader-spinner"></div>
    </div>
  );
};

export default Loader;
