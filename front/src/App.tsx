import React, { Component, ReactNode } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";

/* Libraries */
import axios from "axios";

/* Components */

import SdnEntryTable from "./components/SdnEntryTable";
import ServiceStats from "./components/ServiceStats";

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
            <Col>
              <SdnEntryTable />
            </Col>
            <Col>
              <ServiceStats />
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default App;
