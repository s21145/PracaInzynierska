import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import './Navbar.css';


function Navbar() {
    const [click, setClick] = useState(false);
    const [button, setButton] = useState(true);
    const [profile, setProfile] = useState(false);

    const handleClick = () => setClick(!click);
    const closeMobileMenu = () => setClick(false);

    const showButton = () => {
        if(window.innerWidth <= 960){
            setButton(false)
        } else {
            setButton(true)
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
                    E-MATES<i class="fa-solid fa-gamepad"></i>
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
                    <li className='nav-item'>
                        <Link to='/contact' className='nav-links' onClick={closeMobileMenu}>
                            CONTACT
                        </Link>
                    </li>
                    {window.innerWidth<=960 ? <li className='nav-item'>
                        <Link to='/contact' className='nav-links' onClick={closeMobileMenu}>
                            Settings <i class="fa-solid fa-gears"></i>
                        </Link>
                    </li> : null}
                </ul>
                {window.innerWidth>960 ? <h2>Profile</h2> : null}
                
            </div>
        </nav>


    </>
  )
}

export default Navbar

/*

*/