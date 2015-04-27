import React from 'react';

export default class UserActivityRoot extends React.Component {
    constructor(props) {
        super(props);
    }

    render(){
        return(
            <span>{this.props.users.TotalNumberOfConnections}</span>
            );
    }
}