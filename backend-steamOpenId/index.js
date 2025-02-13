const express = require("express");
const cors = require("cors");
const app = express();
const SteamAuth = require("node-steam-openid");

const steam = new SteamAuth({
  realm: "https://backend-steamconnector2-czhshkb5d5ehbtfg.polandcentral-01.azurewebsites.net",
  returnUrl: "https://backend-steamconnector2-czhshkb5d5ehbtfg.polandcentral-01.azurewebsites.net/auth/steam/authenticate",
  apiKey: "D65CABD4B8E9A882FC8D5651E8787645",
});

const corsOpts = {
  origin: '*',

  methods: [
    'GET',
    'POST',
  ],

  allowedHeaders: [
    'Content-Type',
  ],
};
app.use(cors(corsOpts));

app.use((req, res, next) => {
  res.header("Access-Control-Allow-Origin", "https://effervescent-phoenix-7161e0.netlify.app");
  res.header("Access-Control-Allow-Credentials", "true");
  next();
});

app.get("/auth/steam", async (req, res) => {
  try {
    const redirectUrl = await steam.getRedirectUrl();
    return res.json({ url: redirectUrl });
  } catch (error) {
    console.error("Error getting Steam redirect URL:", error);
    res.status(500).send("Error getting Steam redirect URL");
  }
});

app.get("/auth/steam/authenticate", async (req, res) => {
  try {
    const user = await steam.authenticate(req);
    console.log(user);
    res.redirect(
      `https://effervescent-phoenix-7161e0.netlify.app/ProfileMain?tab=settings&steamId=${user.steamid}`
    );
  } catch (error) {
    console.error("Error during Steam authentication:", error);
    res.status(500).send("Error during Steam authentication");
  }
});
const port = process.env.PORT || 3000;
app.listen(port, () => {
  console.log("SteamAPI openId server is running on port " + port);
});
