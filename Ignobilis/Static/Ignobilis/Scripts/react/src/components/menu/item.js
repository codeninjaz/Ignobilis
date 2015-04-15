import React from 'react';

//This is a render-view only rendering allowed
export default class RenderView1 extends React.Component {
    constructor(props) {
        super(props);
    }

    render(){
        return(
        <a className={this.props.item.state} href={this.props.item.link}>
            {this.props.item.title}
        </a>
        );
    }
}