var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var path = require('path');

module.exports = {
    //Delar upp genererad js i två filer, en för tredjeparts moduler (vendor) och en för min kod (app)
    entry: {
        app: [
            'webpack-dev-server/client?http://localhost:8090',
            'webpack/hot/dev-server',
            './src/app.js'
        ],
        vendor: ['react','lodash','pubsub-js','mcfly','node-uuid']
    },
    //Skapa source maps för js filerna så att dev-tools kan länka till rätt källkod
    devtool: 'source-map',
    //Lägg saker default i dist mappen, döp rot js till app.js och se till att sökvägar i genererad kod läggs under ./
    output: {
        path: path.resolve('./dist'),
        library: '[name]',
        filename: '[name].js',
    },
    //Här ställer man in vilka filtyper webpack ska göra något med. Loaders installeras via npm
    //och används här. T.ex. bildfiler som inkluderas i jsx filerna med require lägger webpack i images
    //katalogen. Sass filer compileras till css och läggs in inline.
    module: {
        loaders: [{
            test: /\.(jsx|js)$/,
            exclude: /node_modules/,
            loader: 'babel-loader'
        }, {
            test: /\.(scss|sass)$/,
            loader: 'style!css!sass'
        }, {
            test: /\.css$/,
            loader: 'style!css'
        }, {
            test: /\.(jpe?g|png|gif|svg)$/i,
            loader: 'image?name=images/[name].[ext]&optimizationLevel=7&interlaced=false'
        }, {
            test: /\.json$/,
            loader: 'json'
        }, {
            test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
            loader: "url-loader?limit=10000&minetype=application/font-woff"
        }, {
            test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
            loader: "file-loader"
        }]
    },
    //Kolla på dessa filtyper (osäker på vad denna gör :) )
    resolve: {
        extensions: ['', '.js', '.jsx']
    },
    node: {
        fs: "empty"
    },
    //Ladda plugins till webpack
    plugins: [
        new webpack.optimize.CommonsChunkPlugin('vendor', 'vendor.js', Infinity),
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NoErrorsPlugin(),
        new HtmlWebpackPlugin({
            title: 'Calendar test',
            template: 'src/index.html',
            assets: {
                'app': 'app.js',
                'vendor': 'vendor.js'
            }
        })
    ]
};
