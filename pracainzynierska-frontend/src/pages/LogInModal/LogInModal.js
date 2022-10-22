import "./LogInModal.css";
import SignUpModal from "../SignUpModal/SignUpModal";

import React from 'react'

function LogInModal({closeLogInModal}) {
  return (
    <div className="modal-background">
        <div className="modal-container">
            <div className="modal-close-button">
                <div className="modal-title">
                    E-MATES
                </div>
                <button className="modal-close-mark" 
                    onClick={() => closeLogInModal(false)}>
                    <i className="fa-solid fa-xmark" />
                </button>
            </div>
            
            <div className="modal-select-login-signup">
                <div className="modal-login">
                    <button className="modal-login-button2">Log In</button>
                </div>
                <div className="modal-login">
                    <button className="modal-signup-button2">Sign Up</button>
                </div>
                
            </div>
            <hr></hr>


            <div className="modal-login-body">
                
                <label className="login-form-title-label">Welcome Back!</label>
                <div className="modal-login-form-wrapper">
                <form className="modal-login-form">
                    <div className="modal-login-form-fields">
                        <label className="login-form-label">Email</label>
                        <input placeholder="Email" className="login-form-input"></input>
                        <label className="login-form-label">Password</label>
                        <input placeholder="Password" className="login-form-input"></input>
                        <div className="groupper">
                        <input type="checkbox" /> <label className="login-form-label">Remember me!</label>
                        </div>
                    </div>
                    <button type = "submit" id="submit-button" className="login-form-button">Log In</button>
                </form>
                </div>
            </div>
        </div>
    </div>
  )
}

export default LogInModal
