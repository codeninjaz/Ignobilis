import React from 'react';
import Root from './components/menu/root.js';
class App extends React.Component {
    render(){
        return(
            <Root />
        );
    }
}

React.render(<App />, document.getElementById('menu1'));
