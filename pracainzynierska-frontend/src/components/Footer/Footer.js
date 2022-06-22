import React from "react";
import { Link } from "react-router-dom";
import "./Footer.css";

function Footer() {
  return (
    <div className="footer-container">
      <section className="footer-tos">
        <Link to="/" className="footer-tos-heading">
          Terms of Service
        </Link>
      </section>
      <section className="footer-links">
        <div className="footer-links-wrapper">
          <div className="footer-logo">
            <Link to="/" className="footer-social-logo">
              E-MATES <i className="fa-solid fa-gamepad" />
            </Link>
          </div>
        </div>
      </section>
      <section className="footer-social-media">
        <div className="footer-social-media-logos">
          <Link
            to="/"
            className="footer-external"
            target="_blank"
            aria-label="Instagram"
          >
            <i className="fa-brands fa-instagram"></i>
          </Link>
          <Link
            to="/"
            className="footer-external"
            target="_blank"
            aria-label="Facebook"
          >
            <i className="fa-brands fa-facebook-f"></i>
          </Link>
          <Link
            to="/"
            className="footer-external"
            target="_blank"
            aria-label="Discord"
          >
            <i className="fa-brands fa-discord"></i>
          </Link>
        </div>
      </section>
    </div>
  );
}

export default Footer;
