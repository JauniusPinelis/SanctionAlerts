import React, { Component, ReactNode } from "react";

import moment from "moment";

import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";

interface Props {
  lastModified: string;
  lastHeadersChecked: string;
  lastDownloaded: string;
  loadData: Function;
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
            <td>
              {moment(this.props.lastHeadersChecked).format(
                "MMMM Do YYYY, h:mm:ss a"
              )}
            </td>
          </tr>
          <tr>
            <td>Last Downloaded</td>
            <td>
              {moment(this.props.lastDownloaded).format(
                "MMMM Do YYYY, h:mm:ss a"
              )}
            </td>
          </tr>
          <tr>
            <td>Last Content Modified</td>
            <td>
              {moment(this.props.lastModified).format(
                "MMMM Do YYYY, h:mm:ss a"
              )}
            </td>
          </tr>
          <tr>
            <td>Refresh</td>
            <td>
              <Button onClick={() => this.props.loadData()} variant="success">
                Refresh
              </Button>
            </td>
          </tr>
        </tbody>
      </Table>
    );
  }
}

export default ServiceSats;
