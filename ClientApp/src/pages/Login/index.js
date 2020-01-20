import React from "react";
import { Card } from "antd";

import "antd/dist/antd.css";
import "./login.css";

class Login extends React.Component {
  componentDidMount() {
    console.log("123");
  }

  render() {
    return (
      <>
        <div className="container">
          <Card className="content">
            <p>Card content</p>
            <p>Card content</p>
            <p>Card content</p>
          </Card>
        </div>
      </>
    );
  }
}

export default Login;
