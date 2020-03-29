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
  uId: number;
  lastName: string;
  sdnType: string;
  lastModified: Date;
}

interface State {
  sdnEntries: SdnEntry[];
  lastModified: string;
  lastHeadersChecked: string;
  lastDownloaded: string;
}

class App extends Component {
  state: State = {
    sdnEntries: [],
    lastModified: "",
    lastHeadersChecked: "",
    lastDownloaded: ""
  };
  componentDidMount() {
    this.loadData();
  }
  loadData = () => {
    axios.get(`/data`).then(res => {
      this.setState({
        sdnEntries: res.data.sdnEntries,
        lastModified: res.data.lastModified,
        lastHeadersChecked: res.data.lastHeadersChecked,
        lastDownloaded: res.data.lastDownloaded
      });
    });
  };
  render(): ReactNode {
    return (
      <div className="App">
        <Container>
          <Row>
            <Col>
              <SdnEntryTable sdnEntries={this.state.sdnEntries} />
            </Col>
            <Col>
              <ServiceStats
                lastDownloaded={this.state.lastDownloaded}
                lastHeadersChecked={this.state.lastHeadersChecked}
                lastModified={this.state.lastModified}
                loadData={this.loadData}
              />
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default App;
