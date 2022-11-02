import React from 'react';
import './ProfileMainSettings.css';
import steamLogo from '../../../assets/resources/steam-logo.png';

function ProfileMainSettings() {
  return (
    <div className="settings-wrapper">
        <div className="settings-container">
            <div className="settings-small-container">
                <div className="small-container-header">
                    <h1>Change your email address</h1>
                </div>
                <div className="small-container-form">                
                    <form action="" className="change-email">
                        <div className='small-container-form-content'>
                            <div>
                                {/*<label>New email address: </label>*/}
                                <input className="small-container-form-input" placeholder='Your new email address'></input>
                            </div>
                            <div>
                                <button type="submit" className='small-container-form-submit-button' >Change</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <hr className='settings-line'/>
            <div className="settings-small-container">
            <h1>Change your password</h1>
                <form action="" className="change-password">
                        <div className='small-container-form-content'>
                            <div>
                                {/*<label>Your new password: </label> */}
                                <input className="small-container-form-input" placeholder='Your current password *' ></input>
                            </div>
                            <div>
                                {/*<label>Confirm your new password: </label>*/}
                                <input className="small-container-form-input" placeholder='Your new password *'></input>
                            </div>
                            <div>
                                {/*<label>Confirm your new password: </label>*/}
                                <input className="small-container-form-input" placeholder='Confirm your new password *'></input>
                            </div>
                            <div>
                                <button type="submit" className='small-container-form-submit-button'>Change</button>
                            </div>
                        </div>
                    </form>
            </div>
            <hr className="settings-line" />
            <div className="settings-small-container">
                <h1>Connect Your Socials</h1>
                <div className="socials-icons-container">
                    <img src={steamLogo} alt="Steam logo" className='setttings-socials-icon' onClick={''} />
                </div>
            </div>
            <hr className="settings-line" />
            <div className="settings-small-container">
                <h1>Update your bio</h1>
                <div className="change-bio-container">
                    <form action="" className='change-bio'>
                        <div className='small-container-form-content'>
                            <div>
                                <textarea className='change-bio-textarea' placeholder='Current bio ...' />
                            </div>
                            <div>
                                    <button type="submit" className='small-container-form-submit-button'>Update</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            
        </div>
    </div>
  )
}

export default ProfileMainSettings
