import React from 'react';

//This is a render-view only rendering allowed
export default class RenderView1 extends React.Component {
    constructor(props) {
        super(props);
    }

    render(){
        return(
        <div>
            BAJS!
        </div>
        );
    }
}