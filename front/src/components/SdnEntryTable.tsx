import React, { Component, ReactNode } from "react";

interface Props {}
interface State {}

class SdnEntryTable extends Component<Props, State> {
  constructor(props: Props) {
    super(props);

    this.state = {};
  }

  render(): ReactNode {
    return <h1>SdnEntryTable</h1>;
  }
}

export default SdnEntryTable;
