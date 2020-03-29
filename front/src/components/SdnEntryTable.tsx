import React, { Component, ReactNode } from "react";

import Table from "react-bootstrap/Table";

interface SdnEntry {
  uId: number;
  lastName: string;
  sdnType: string;
  lastModified: Date;
}

interface Props {
  sdnEntries: SdnEntry[];
}
interface State {}

class SdnEntryTable extends Component<Props, State> {
  constructor(props: Props) {
    super(props);

    this.state = {};
  }

  render(): ReactNode {
    return (
      <div>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Id</th>
              <th>Last Name</th>
              <th>Type</th>
              <th>Last Modified</th>
            </tr>
          </thead>
          <tbody>
            {this.props.sdnEntries.map((sdn, i) => (
              <tr key={sdn.uId}>
                <td>{sdn.uId}</td>
                <td>{sdn.lastName}</td>
                <td>{sdn.sdnType}</td>
                <td>{sdn.lastModified}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default SdnEntryTable;
