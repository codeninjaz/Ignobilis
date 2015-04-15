import React from 'react';
import Root from './components/root.js';

require('./styles/bootstrap.min.css');
require('./styles/font-awesome.min.css');
require('./styles/style.scss');

class App extends React.Component {
    render(){
        return(
            <Root />
        );
    }
}

React.render(<App />, document.getElementById('app'));

