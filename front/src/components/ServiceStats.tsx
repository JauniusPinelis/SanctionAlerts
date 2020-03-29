import React, { Component, ReactNode } from "react";

interface Props {}
interface State {}

class ServiceSats extends Component<Props, State> {
  constructor(props: Props) {
    super(props);

    this.state = {};
  }

  render(): ReactNode {
    return <h1>Service Stats</h1>;
  }
}

export default ServiceSats;
