define([
    // These are the dependencies for our created widget.
    'dojo/dom',
   '_templatedMixin'
], function (dom, _templatedMixin) {
    // Once all modules in the dependency list have loaded, this
    // function is called. It's important to understand that this function need to be 
    // passed all the modules in your dependency list, for example we have the 'dojo/dom' dependency
    // which is why we pass our function an argument of dom.
    // This is so that we can access those dependencies in our actual widget.

    declare('ignobilis.ListBlockSelectorWidget', _templatedMixin, {
        // The next step is to call the declare function
        // The first argument is the name and optional namespace of our newly created widget
        // The second argument is the widget we inherit from.
        // If we want to inherit several widgets we can put them in an array []
        // The third argument is this javascript object (the one that contains this comment).
        // This is where we declare any custom properties or functions for our widget
        myprop: function () { alert("ehhh"); }
    });
});