import React, { Component, ReactNode } from "react";
import "./App.css";

import axios from "axios";

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
        <header className="App-header">
          {this.state.sdnEntries.map(entry => (
            <div>
              <div>{entry.uid}</div>
              <div>{entry.lastName}</div>
              <div>{entry.sdnType}</div>
              <div>{entry.LastModified}</div>
            </div>
          ))}
        </header>
      </div>
    );
  }
}

export default App;
