import React from 'react';
import Store from '../data/datastore1';
import Chart from './chart';

//This is a render-view only rendering allowed
export default class RenderView1 extends React.Component {
    constructor(props) {
        super(props);
        let sampleData = [
          {id: '5fbmzmtc', x: 7, y: 41, z: 6},
          {id: 's4f8phwm', x: 11, y: 45, z: 9},
          {id: 's4f8phss', x: 10, y: 50, z: 14}
        ];
        this.state={
            data: sampleData,
            domain: {x: [0, 100], y: [0, 100]},
            bgcolor: '#A4D1FF',
            colors: ['#D5FFBB','#F5E25A','#FF33DB','#4477FD','#04ECFF','#C68C8C','#C49C00','#00FF00','#9994C5']
        }
    }
    handleColorUpdate(color){
        this.setState({
            bgcolor: color
        });
    }
    render(){
        return(
        <div>
            <Chart
                data={this.state.data}
                domain={this.state.domain}
                bgcolor={this.state.bgcolor}
            />
        </div>
        );
    }
}