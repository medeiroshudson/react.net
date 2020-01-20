import React from "react";
import ReactDOM from "react-dom";
import Routes from "./routes";

import { Provider as Redux } from "react-redux";
import store from "./store";

import "./App.css";

ReactDOM.render(
  <Redux store={store}>
    <Routes />
  </Redux>,
  document.getElementById("root")
);
