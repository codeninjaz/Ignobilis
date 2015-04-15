import McFly from 'McFly';
import Data from '../../test/inventory.json';

let Flux = new McFly();
let _inventory = Data;
export default Flux.createStore({
        getItems: function() {
           return _inventory;
        }
    },
    function(payload) {
        console.log('payload', payload);
    }
);
