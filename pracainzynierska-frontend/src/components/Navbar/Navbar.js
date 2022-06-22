import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import ProfileDropdown from '../ProfileDropdown/ProfileDropdown';
import './Navbar.css';


function Navbar() {
    const [click, setClick] = useState(false);
    const [button, setButton] = useState(true);
    const [profile, setProfile] = useState(false);

    const handleClick = () => setClick(!click);
    const closeMobileMenu = () => setClick(false);
    const openProfileMenu = () => setProfile(true);


    const showButton = () => {
        if(window.innerWidth <= 960){
            setButton(false)
        } else {
            setButton(true)
        }
    };

    const onMouseLeave = () => {
        if (window.innerWidth < 960) {
          setProfile(false);
        } else {
          setProfile(false);
        }
      };

    useEffect(() => {
        showButton();
    }, []);
    window.addEventListener('resize', showButton);

  return (
    <>
        <nav className="navbar">
            <div className="navbar-container">
                <Link to="/" className='navbar-logo' onClick={closeMobileMenu}>
                    E-MATES<i className="fa-solid fa-gamepad"></i>
                </Link>
                <div className="menu-icon" onClick={handleClick} >
                    <i className={click ? 'fas fa-times' : 'fas fa-bars'} />
                </div>
                <ul className={click ? 'nav-menu active' : 'nav-menu'}>
                    {window.innerWidth<=960 ? <li className='nav-item'>
                        <Link to='/contact' className='nav-links' onClick={closeMobileMenu}>
                            Profile
                        </Link>
                    </li> : null}
                    <li className='nav-item'>
                        <Link to='/e-mates' className='nav-links' onClick={closeMobileMenu}>
                            E-MATES
                        </Link>
                    </li>
                    <li className='nav-item'>
                        <Link to='/findplayers' className='nav-links' onClick={closeMobileMenu}>
                            FIND PLAYERS
                        </Link>
                    </li>
                    <li className='nav-item'>
                        <Link to='/posts' className='nav-links' onClick={closeMobileMenu}>
                            POSTS
                        </Link>
                    </li>
                    <li className='nav-item' >
                        <Link to='/contact' className='nav-links' onClick={closeMobileMenu}>
                            CONTACT
                        </Link>
                    </li>
                    {window.innerWidth<=960 ? <li className='nav-item'>
                        <Link to='/contact' className='nav-links' onClick={closeMobileMenu}>
                            Settings <i className="fa-solid fa-gears"></i>
                        </Link>
                    </li> : null}
                </ul>
                {window.innerWidth>960 ? 
                        <div className='profile-span' onClick={openProfileMenu} onMouseLeave={onMouseLeave} >
                        <div className='profile-link' >
                            <h2 className='profile-wrap' >Your profile</h2>
                        </div>
                        
                        {profile && <ProfileDropdown /> }
                        </div>
                    : null}
                
            </div>
        </nav>


    </>
  )
}

export default Navbar

/*

*/