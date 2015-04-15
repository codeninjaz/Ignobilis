import React from 'react';

export default class Menu extends React.Component{
    constructor(){
        super();
    }
    itemList(){
        let listItems = [];
        let n=0;
        _.forEach(this.props.images, function(image){
            listItems.push(
            	<CarouselItem>
            		<img style={{paddingRight:'10px',paddingBottom:'10px',}} key={'image-' + n} src={image} />
            	</CarouselItem>
                );
            n+=1;
        });
        return listItems;
    }

    render(){
        return (
        		<Carousel style={{width:'400px', padding:'0'}}>
       				{this.itemList()}
       			</Carousel>
        	);
    }
}