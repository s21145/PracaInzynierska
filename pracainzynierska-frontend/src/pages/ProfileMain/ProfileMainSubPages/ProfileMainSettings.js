import React from 'react'
import './ProfileMainSettings.css';

function ProfileMainSettings() {
  return (
    <div className="settings-wrapper">
        <div className="settings-container">
            <div className="settings-small-container">
                <div className="small-container-header">
                    <h1>Change Email</h1>
                </div>
                <div className="small-container-form">                
                    <form action="" className="change-email">
                        <div className='small-container-form-content'>
                            <div>
                                <label>Current email address: </label>
                                <input className="small-container-form-input" disabled placeholder="randomemail@gmail.com"></input>
                            </div>
                            <div>
                                <label>New email address: </label>
                                <input className="small-container-form-input"></input>
                            </div>
                            <div>
                                <button type="submit" className='small-container-form-submit-button'>Confirm</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div className="settings-small-container">
            <h1>CHANGE PASSWORD</h1>
                <form action="" className="change-password">
                        <div className='small-container-form-content'>
                            <div>
                                <label>Your new password: </label>
                                <input className="small-container-form-input" ></input>
                            </div>
                            <div>
                                <label>Confirm your new password: </label>
                                <input className="small-container-form-input"></input>
                            </div>
                            <div>
                                <button type="submit" className='small-container-form-submit-button'>Confirm</button>
                            </div>
                        </div>
                    </form>
            </div>
            
        </div>
    </div>
  )
}

export default ProfileMainSettings
