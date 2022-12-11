import React from "react";
import "./ProfileMainSettings.css";
import steamLogo from "../../../assets/resources/steam-logo.png";
import {
  AddSteamId,
  ChangeDescription,
  ChangeEmail,
  ChangePassword,
} from "../../../Services/UserService";
import { useContext, useState } from "react";
import { UserContext } from "../../../Services/UserContext";
import { MessageContext } from "../../../Services/MessageContext";
import http, {
  removeAuthorization,
  setAuthorization,
} from "../../../Services/HttpService";
import config from "../../../config.json";
import { useSearchParams } from "react-router-dom";
import { useEffect } from "react";

function ProfileMainSettings() {
  const [searchParams, setSearchParamas] = useSearchParams();
  const { user, setUser } = useContext(UserContext);
  const { message, setMessage } = useContext(MessageContext);
  const [userData, setUserData] = useState({
    description: "",
    email: "",
    newPassword: "",
    oldPassword: "",
  });
  function showMessage(message) {
    setUserData({
      description: "",
      email: "",
      newPassword: "",
      oldPassword: "",
      newPassword2: "",
    });
    setMessage({ content: message, show: true });
  }
  async function handleChangeDescription(e) {
    e.preventDefault();

    const oldDescription = user.description;

    const response = await ChangeDescription(userData.description);
    // co jesli puste
    setUser({ ...user, description: userData.description });
    if (response.status !== 200) {
      setUser({ ...user, description: oldDescription });
      setMessage({
        content: response.status + " :" + response.data,
        show: true,
      });
    } else {
      showMessage("Opis został zmieniony");
    }
  }
  async function handleEmailChange(e) {
    e.preventDefault();
    const oldEmail = user.email;
    //walidacja mejla
    const response = await ChangeEmail(userData.email);
    if (response.status !== 200) {
      setUser({ ...user, email: oldEmail });
      setMessage({
        content: response.status + " :" + response.data,
        show: true,
      });
    } else {
      showMessage("Email został zmieniony");
    }
  }
  async function handlePasswordChange(e) {
    e.preventDefault();
    //walidacja czy hasla sa takie same
    const response = await ChangePassword(
      userData.oldPassword,
      userData.newPassword
    );
    console.log(response);
    if (response.status !== 200) {
      setMessage({
        content: response.status + " :" + response.data,
        show: true,
      });
    } else {
      showMessage("Hasło zostało zmienione");
    }
  }
  function handleInputChange(e) {
    const { name, value } = e.target;
    setUserData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  }
  async function openId() {
    try {
      removeAuthorization();
      const test = await http.get(config.openIdUrl + "auth/steam");
      window.location.replace(test.request.responseURL);
    } catch (error) {
      console.log("error: " + error);
    }
  }
  useEffect(() => {
    handleSteamId();
  }, []);
  console.log(user);
  async function handleSteamId() {
    const steamId = searchParams.get("steamId");
    searchParams.delete("steamId");
    setSearchParamas(searchParams);
    if (steamId === null) {
      return;
    }
    setAuthorization();
    const response = await AddSteamId(steamId);
    if (response.status !== 200) {
      setMessage({
        content: response.status + " :" + response.data,
        show: true,
      });
    } else {
      setUser({ ...user, steamId: steamId });
      showMessage("Konto steam zostało przypisane do konta");
    }
  }
  return (
    <div className="settings-wrapper">
      <div className="settings-container">
        <div className="settings-small-container">
          <div className="small-container-header">
            <h1>Change your email address</h1>
          </div>
          <div className="small-container-form">
            <form
              action=""
              className="change-email"
              onSubmit={(e) => handleEmailChange(e)}
            >
              <div className="small-container-form-content">
                <div>
                  {/*<label>New email address: </label>*/}
                  <input
                    className="small-container-form-input"
                    placeholder="Your new email address"
                    name="email"
                    value={userData.email}
                    onChange={(e) => handleInputChange(e)}
                  ></input>
                </div>
                <div>
                  <button
                    type="submit"
                    className="small-container-form-submit-button"
                  >
                    Change
                  </button>
                </div>
              </div>
            </form>
          </div>
        </div>
        <hr className="settings-line" />
        <div className="settings-small-container">
          <h1>Change your password</h1>
          <form
            action=""
            className="change-password"
            onSubmit={(e) => handlePasswordChange(e)}
          >
            <div className="small-container-form-content">
              <div>
                {/*<label>Your new password: </label> */}
                <input
                  name="oldPassword"
                  value={userData.oldPassword}
                  onChange={(e) => handleInputChange(e)}
                  className="small-container-form-input"
                  placeholder="Your current password *"
                ></input>
              </div>
              <div>
                {/*<label>Confirm your new password: </label>*/}
                <input
                  name="newPassword"
                  value={userData.newPassword}
                  onChange={(e) => handleInputChange(e)}
                  className="small-container-form-input"
                  placeholder="Your new password *"
                ></input>
              </div>
              <div>
                {/*<label>Confirm your new password: </label>*/}
                <input
                  name="newPassword2"
                  value={userData.newPassword2}
                  onChange={(e) => handleInputChange(e)}
                  className="small-container-form-input"
                  placeholder="Confirm your new password *"
                ></input>
              </div>
              <div>
                <button
                  type="submit"
                  className="small-container-form-submit-button"
                >
                  Change
                </button>
              </div>
            </div>
          </form>
        </div>
        <hr className="settings-line" />
        <div className="settings-small-container">
          <h1>Connect Your Socials</h1>
          <div className="socials-icons-container">
            <img
              src={steamLogo}
              onClick={openId}
              alt="Steam logo"
              className="setttings-socials-icon"
            />
          </div>
        </div>
        <hr className="settings-line" />
        <div className="settings-small-container">
          <h1>Update your bio</h1>
          <div className="change-bio-container">
            <form
              action=""
              className="change-bio"
              onSubmit={(e) => handleChangeDescription(e)}
            >
              <div className="small-container-form-content">
                <div>
                  <textarea
                    className="change-bio-textarea"
                    placeholder="Current bio ..."
                    name="description"
                    value={userData.description}
                    onChange={(e) => handleInputChange(e)}
                  />
                </div>
                <div>
                  <button
                    type="submit"
                    className="small-container-form-submit-button"
                  >
                    Update
                  </button>
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ProfileMainSettings;
