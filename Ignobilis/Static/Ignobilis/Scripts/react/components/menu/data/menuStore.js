import McFly from 'mcfly';
import Data from './menuMockData.json';
import Const from './actionConstants'

let Flux = new McFly();
let menuMockData = Data;
export default Flux.createStore({
        getItems: function(childrenFrom, pages) {
           return menuMockData
        }
    },
    function(payload) {
        console.log('payload', payload);
        if(payload.actionType===Const.MENU_CHANGE){
        	console.log('RÖÖÖÖQ');
	        this.emitChange();
        }
    }
);
