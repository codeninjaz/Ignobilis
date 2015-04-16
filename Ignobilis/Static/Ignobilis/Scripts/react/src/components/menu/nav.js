import React from 'react';
import _ from 'lodash';
import Item from './item';

//This is a render-view only rendering allowed
export default class RenderView1 extends React.Component {
    constructor(props) {
        super(props);
    }

    makeItems(){
        var tempItems=[];
        _.forEach(this.props.menuItems.links, function(item, i){
            tempItems.push(<Item key={i} item={item}/>)
        })
        return tempItems;
    }

    render(){
        console.log('this.props',this.props)

        return(
        <nav className="menu">
            <span>{this.props.uid}: </span>
            {this.makeItems()}
        </nav>
        );
    }
}