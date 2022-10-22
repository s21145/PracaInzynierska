import http from "../../Services/HttpService";
import config from "../../config.json";

function Contact() {
  async function openId() {
    try {
      console.log("TEST");
      const test = await http.get(config.openIdUrl + "auth/steam");
      console.log(test);
      window.location.replace(test.request.responseURL);
    } catch (error) {
      console.log("error: " + error);
    }
  }
  return (
    <div>
      <img
        onClick={openId}
        src="https://steamcdn-a.akamaihd.net/steamcommunity/public/images/steamworks_docs/english/sits_large_noborder.png"
        alt="sits_large_noborder.png"
        title="sits_large_noborder.png"
      ></img>
    </div>
  );
}

export default Contact;
