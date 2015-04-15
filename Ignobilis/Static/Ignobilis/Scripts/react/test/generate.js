var FS = require('fs');
var uuid = require('uuid');

var _items = [];
var words = 'Lebowski ipsum donny was a good bowler, and a good man. He was… He was one of us. He was a man who loved the outdoors, and bowling, and as a surfer explored the beaches of southern California from Redondo to Calabassos. And he was an avid bowler. And a good friend. He died—he died as so many of his generation, before his time. In your wisdom you took him, Lord. As you took so many bright flowering young men, at Khe San and Lan Doc. Dolor sit amet, consectetur adipiscing elit praesent ac magna.';
var allWords = words.split(' ');

var getRandom = function(min, max) {
    return Math.round(Math.random() * (max - min) + min);
};

var getAWord = function() {
    return allWords[getRandom(0, allWords.length - 1)];
};

var getDescription = function() {
    var max = getRandom(10, allWords.length - 1);
    var sentence = [];
    for (var n = 0; n < max; n++) {
        sentence.push(allWords[n]);
    }
    return sentence.join(' ');
};

for (var i = 0; i < 100; i++) {
    var item = {
        id: uuid.v4(),
        name: getAWord(),
        description: getDescription(),
    };
    _items.push(item);
}

var filename = './junkdata.json';
FS.writeFile(filename, JSON.stringify(_items,null,'\t'), function(err) {
    if (err) {
        throw err;
    }
    console.info(filename + ' skapad!');
});
