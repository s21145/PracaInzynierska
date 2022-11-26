import { createContext } from "react";

export const MessageContext = createContext({
  content: "",
  show: false,
});
