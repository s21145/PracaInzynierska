import { useContext } from "react";
import { MessageContext } from "../Services/MessageContext";
import styles from './MessageModal/MessageModal.module.css';

const MessageModal = () => {
  const { message, setMessage } = useContext(MessageContext);
  const handleCloseModal = () => {
    setMessage({ ...message, show: false });
  };

  return (
    <div className={styles.modalBackground}>
      <div className={styles.modalContainer}>
        <div className={styles.modalHeader}>
          <div className={styles.modalTitle}>Notice</div>
          <button className={styles.modalCloseMark} onClick={handleCloseModal}>
            <i className="fa-solid fa-xmark" />
          </button>
        </div>
        <hr />
        <div className={styles.modalContent}>{message.content}</div>
        <button className={styles.modalCloseButton} onClick={handleCloseModal}>
          CLOSE
        </button>
      </div>
    </div>
  );
};

export default MessageModal;
