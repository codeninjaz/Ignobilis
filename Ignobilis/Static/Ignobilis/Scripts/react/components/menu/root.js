import React from 'react';
import Nav from './nav';
import Store from './data/menuStore';

export default class RenderView1 extends React.Component {
    constructor(props) {
        super(props);
        this.state = this.getState();
    }

    getState(){
        return {
            menuData: Store.getItems(this.props.childrenFrom, this.props.pages)
        }
    }
    onStoreChange() {
        this.setState(this.getState());
    }
    componentDidMount() {
        Store.addChangeListener(this.onStoreChange.bind(this));
    }
    componentWillUnmount() {
        Store.removeChangeListener(this.onStoreChange.bind(this));
    }
    render(){
        return(
            <Nav menuItems={this.state.menuData} uid={this.props.uid}/>
            );
    }
}