import React from "react";
import ReactDOM from "react-dom";
import Routes from "./routes";

import { createStore, applyMiddleware } from "redux";
import promise from "redux-promise";
import multi from 'redux-multi';
import thunk from 'redux-thunk';
import reducers from "./store/reducers";
import { Provider as Redux } from "react-redux";

import "./App.css";

const devTools =
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__();
const store = applyMiddleware(promise, multi, thunk)(createStore)(reducers, devTools);

ReactDOM.render(
  <Redux store={store}>
    <Routes />
  </Redux>,
  document.getElementById("root")
);
