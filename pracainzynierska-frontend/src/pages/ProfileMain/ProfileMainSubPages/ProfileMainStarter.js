import React from 'react'
import './ProfileMainStarter.css';

function ProfileMainStarter() {
  return (
    <div className="starter-wrapper">
            <div class="starter-bio">
                <div className="starter-bio-text-area">
                    No bio currently set up.
                </div>
            </div>

            <div className="starter-bottom-container">
                <div className="starter-left-side">
                    <div className="starter-age-container">
                        <div className="starter-age-title">                        
                            Age:
                        </div>
                        <div class="starter-age">
                            2
                        </div>
                    </div>

                    <div className="starter-socials-container">
                        <div className="starter-socials-title">
                            Socials:
                        </div>
                        <div class="starter-socials">
                            <div className="social-steam">
                                Steam id:
                            </div>
                            <div className="social-discord">
                                Discord tag:
                            </div>
                        </div>
                    </div>
                </div>
                <div class="starter-posts">
                    3
                </div>
            </div>
            
    </div>
  )
}

export default ProfileMainStarter
