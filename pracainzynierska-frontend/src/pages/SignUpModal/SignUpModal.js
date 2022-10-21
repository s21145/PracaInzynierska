import "./SignUpModal.css";
import LogInModal from "../LogInModal/LogInModal";
import { useState } from "react";
import React from 'react'

function SignUpModal({closeSignUpModal}) {

    const [openLoginModal, setOpenLoginModal] = useState(false);
    const [openSignupModal, setOpenSignupModal] = useState(false);
  return (
    
    <div className="modal-background">
        {openLoginModal && <LogInModal closeLogInModal={setOpenLoginModal} />}
        <div className="modal-container">
            <div className="modal-close-button">
                <div className="modal-title">
                    E-MATES
                </div>
                <button className="modal-close-mark" 
                    onClick={() => closeSignUpModal(false)}>
                    <i className="fa-solid fa-xmark" />
                </button>
            </div>
            <div className="modal-select-login-signup">
                <div className="modal-login">
                    <button className="modal-login-button" onClick={() => {setOpenLoginModal(true) ;
                        closeSignUpModal(false); 
                        }}>Log In</button>
                </div>
                <div className="modal-login">
                    <button className="modal-signup-button" onClick={() => {setOpenSignupModal(true) && closeSignUpModal(false);}}>Sign Up</button>
                </div>
                
            </div>
            <hr></hr>
            <div className="modal-signup-body">
                <div className="modal-signup-form-wrapper">
                <form className="modal-signup-form">
                    <div className="modal-signup-form-fields">
                        <label className="signup-form-label">Email</label>
                        <input placeholder="Please enter your email." className="signup-form-input"></input>
                        <label className="signup-form-label">Date of birth</label>
                        <input type="date" placeholder="DateOfBirth" className="signup-form-input"></input>
                        <label className="signup-form-label">Nickname</label>
                        <input placeholder="Please enter your nickname." className="signup-form-input"></input>
                        <label className="signup-form-label">Password</label>
                        <input placeholder="Please enter your password." className="signup-form-input"></input>
                    </div>
                    <button type = "submit" id="submit-button" className="signup-form-button">Sign Up</button>
                </form>
                
                </div>
            </div>
        </div>
    </div>
  )
}

export default SignUpModal
