const express = require("express");
const cors = require("cors");
const app = express();

const SteamAuth = require("node-steam-openid");

const steam = new SteamAuth({
  realm: "http://localhost:7195", // Site name displayed to users on logon
  returnUrl: "http://localhost:7195/auth/steam/authenticate", // Your return route
  apiKey: "28A4A65572FB7696356B3B5B5D1D3801", // Steam API key
});

app.use(cors());
app.get("/auth/steam", async (req, res) => {
  const redirectUrl = await steam.getRedirectUrl();
  return res.redirect(redirectUrl);
});

app.get("/auth/steam/authenticate", async (req, res) => {
  try {
    const user = await steam.authenticate(req);

    console.log(user);
    res.redirect("http://localhost:3000");
  } catch (error) {
    console.error("tutaj " + error);
  }
});

app.listen(7195, () => {
  console.log("SteamAPI openId");
});
