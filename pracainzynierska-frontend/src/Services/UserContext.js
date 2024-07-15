import { createContext } from "react";
import FriendsList from "../pages/FriendsList/FriendsList";

export const UserContext = createContext({
  login: "",
  image: "",
  steamId: null,
  age: "",
  description: "",
  friends:[],
  requests:[]
});
