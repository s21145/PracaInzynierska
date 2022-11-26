import { useContext } from "react";
import { MessageContext } from "../Services/MessageContext";

const MessageModal = () => {
  const { message, setMessage } = useContext(MessageContext);
  const handleCloseModal = () => {
    console.log("zamykam");
    setMessage({ ...message, show: false });
  };
  return (
    <div className="modal-background">
      <div className="modal-container">
        <div className="modal-close-button">
          <div className="modal-title">E-MATES</div>
          <button className="modal-close-mark" onClick={handleCloseModal}>
            <i className="fa-solid fa-xmark" />
          </button>
        </div>

        <div className="modal-select-login-signup"></div>
        <hr></hr>
        {message.content}
        <button onClick={handleCloseModal}>CLOSE</button>
        <div className="modal-login-body"></div>
      </div>
    </div>
  );
};

export default MessageModal;
