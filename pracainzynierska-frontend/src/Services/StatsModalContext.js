import { createContext } from "react";

export const statModalContext = createContext({
  stats: {},
  userName: null,
  show: false,
});
