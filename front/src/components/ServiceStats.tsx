import React, { Component, ReactNode } from "react";

import Table from "react-bootstrap/Table";

interface Props {
  lastModified: string;
  lastHeadersChecked: string;
  lastDownloaded: string;
}
interface State {}

class ServiceSats extends Component<Props, State> {
  constructor(props: Props) {
    super(props);

    this.state = {};
  }

  render(): ReactNode {
    return (
      <Table striped bordered hover>
        <tbody>
          <tr>
            <td>Last Checked Headers</td>
            <td>{this.props.lastHeadersChecked}</td>
          </tr>
          <tr>
            <td>Last Downloaded</td>
            <td>{this.props.lastDownloaded}</td>
          </tr>
          <tr>
            <td>Last Content Modified</td>
            <td>{this.props.lastModified}</td>
          </tr>
          <tr>
            <td>Refresh</td>
            <td></td>
          </tr>
        </tbody>
      </Table>
    );
  }
}

export default ServiceSats;
