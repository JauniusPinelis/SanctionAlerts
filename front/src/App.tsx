import React, { Component, ReactNode } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";

import axios from "axios";

/* React-bootstrap components */
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";

interface SdnEntry {
  uid: number;
  lastName: string;
  sdnType: string;
  LastModified: Date;
}

interface State {
  sdnEntries: SdnEntry[];
}

class App extends Component {
  state: State = {
    sdnEntries: []
  };
  componentDidMount() {
    axios.get(`/data`).then(res => {
      this.setState({ sdnEntries: res.data.sdnEntries });
    });
  }
  render(): ReactNode {
    return (
      <div className="App">
        <Container>
          <Row>
            <Col>col1</Col>
            <Col>col2</Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default App;
