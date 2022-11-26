import { createContext } from "react";

export const UserContext = createContext({
  login: "",
  image: "",
  steamId: null,
  age: "",
  description: "",
});
