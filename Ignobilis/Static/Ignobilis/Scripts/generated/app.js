var app =
webpackJsonp_name_([0],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(4);


/***/ },

/***/ 4:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _interopRequireWildcard = function (obj) { return obj && obj.__esModule ? obj : { 'default': obj }; };
	
	var _React = __webpack_require__(3);
	
	var _React2 = _interopRequireWildcard(_React);
	
	var _MenuRoot = __webpack_require__(7);
	
	var _MenuRoot2 = _interopRequireWildcard(_MenuRoot);
	
	var _UserActivityRoot = __webpack_require__(8);
	
	var _UserActivityRoot2 = _interopRequireWildcard(_UserActivityRoot);
	
	$(function () {
	    var userActivityHub = $.connection.userActivityHub;
	    var eventMessageHub = $.connection.eventMessageHub;
	
	    window.EventMessageHubJoinGroup = function (groupName) {
	        $.connection.hub.start().done(function () {
	            eventMessageHub.server.joinGroup(groupName);
	        });
	    };
	
	    $.connection.hub.start().done(function () {
	        var userActivities = [];
	        $('.react-user-activity').each(function () {
	            var id = $(this).attr('id');
	            userActivities.push(id);
	        });
	
	        if (userActivities.length > 0) {
	            userActivityHub.server.joinBlockGroups(userActivities);
	        }
	    });
	
	    userActivityHub.client.updateUsersOnlineCount = function (userinfo, bGroup) {
	        //console.log(bGroup);
	        //console.log(userinfo);
	        _React2['default'].render(_React2['default'].createElement(_UserActivityRoot2['default'], {
	            users: userinfo }), document.getElementById(bGroup));
	    };
	
	    eventMessageHub.client.clearMessages = function () {
	        $('#eventMessages').html('');
	    };
	    eventMessageHub.client.broadcastMessage = function (typ, message, url) {
	        var icon;
	        switch (typ) {
	            case 'emergency':
	                icon = '<i class="fa fa-exclamation-circle"></i>';
	                break;
	            case 'warning':
	                icon = '<i class="fa fa-exclamation-triangle"></i>';
	                break;
	            case 'information':
	                icon = '<i class="fa fa-info-circle"></i>';
	                break;
	            case 'default':
	                icon = '<i class="fa fa-exclamation"></i>';
	                break;
	            case 'error':
	                icon = '<i class="fa fa-bug"></i>';
	                break;
	            default:
	                icon = '<i class="fa fa-exclamation"></i>';
	                break;
	        }
	
	        $('#eventMessages').append('<div class="message ' + typ + '">' + icon + '<strong>' + message + '</strong><a target="_blank" href="' + url + '">L�s mer</a></div>');
	    };
	});
	
	/*$('.react-menu').each(function()
	    {
	        let id = $(this).attr('id');
	        let childrenFrom = $(this).attr('data-children-from');
	        let pages = $(this).attr('data-pages');

	        React.render(<MenuRoot uid={id} childrenFrom={childrenFrom} pages={pages} />, document.getElementById(id));
	});*/

/***/ },

/***/ 7:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _interopRequireWildcard = function (obj) { return obj && obj.__esModule ? obj : { 'default': obj }; };
	
	var _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } };
	
	var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();
	
	var _get = function get(object, property, receiver) { var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ('value' in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };
	
	var _inherits = function (subClass, superClass) { if (typeof superClass !== 'function' && superClass !== null) { throw new TypeError('Super expression must either be null or a function, not ' + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) subClass.__proto__ = superClass; };
	
	Object.defineProperty(exports, '__esModule', {
	    value: true
	});
	
	var _React = __webpack_require__(3);
	
	var _React2 = _interopRequireWildcard(_React);
	
	var _Nav = __webpack_require__(35);
	
	var _Nav2 = _interopRequireWildcard(_Nav);
	
	var _Store = __webpack_require__(36);
	
	var _Store2 = _interopRequireWildcard(_Store);
	
	var RenderView1 = (function (_React$Component) {
	    function RenderView1(props) {
	        _classCallCheck(this, RenderView1);
	
	        _get(Object.getPrototypeOf(RenderView1.prototype), 'constructor', this).call(this, props);
	        this.state = this.getState();
	    }
	
	    _inherits(RenderView1, _React$Component);
	
	    _createClass(RenderView1, [{
	        key: 'getState',
	        value: function getState() {
	            return {
	                menuData: _Store2['default'].getItems(this.props.childrenFrom, this.props.pages)
	            };
	        }
	    }, {
	        key: 'onStoreChange',
	        value: function onStoreChange() {
	            this.setState(this.getState());
	        }
	    }, {
	        key: 'componentDidMount',
	        value: function componentDidMount() {
	            _Store2['default'].addChangeListener(this.onStoreChange.bind(this));
	        }
	    }, {
	        key: 'componentWillUnmount',
	        value: function componentWillUnmount() {
	            _Store2['default'].removeChangeListener(this.onStoreChange.bind(this));
	        }
	    }, {
	        key: 'render',
	        value: function render() {
	            return _React2['default'].createElement(_Nav2['default'], { menuItems: this.state.menuData, uid: this.props.uid });
	        }
	    }]);
	
	    return RenderView1;
	})(_React2['default'].Component);
	
	exports['default'] = RenderView1;
	module.exports = exports['default'];

/***/ },

/***/ 8:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _interopRequireWildcard = function (obj) { return obj && obj.__esModule ? obj : { 'default': obj }; };
	
	var _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } };
	
	var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();
	
	var _get = function get(object, property, receiver) { var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ('value' in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };
	
	var _inherits = function (subClass, superClass) { if (typeof superClass !== 'function' && superClass !== null) { throw new TypeError('Super expression must either be null or a function, not ' + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) subClass.__proto__ = superClass; };
	
	Object.defineProperty(exports, '__esModule', {
	    value: true
	});
	
	var _React = __webpack_require__(3);
	
	var _React2 = _interopRequireWildcard(_React);
	
	var UserActivityRoot = (function (_React$Component) {
	    function UserActivityRoot(props) {
	        _classCallCheck(this, UserActivityRoot);
	
	        _get(Object.getPrototypeOf(UserActivityRoot.prototype), 'constructor', this).call(this, props);
	    }
	
	    _inherits(UserActivityRoot, _React$Component);
	
	    _createClass(UserActivityRoot, [{
	        key: 'render',
	        value: function render() {
	            return _React2['default'].createElement(
	                'span',
	                null,
	                this.props.users.TotalNumberOfConnections
	            );
	        }
	    }]);
	
	    return UserActivityRoot;
	})(_React2['default'].Component);
	
	exports['default'] = UserActivityRoot;
	module.exports = exports['default'];

/***/ },

/***/ 35:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _interopRequireWildcard = function (obj) { return obj && obj.__esModule ? obj : { 'default': obj }; };
	
	var _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } };
	
	var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();
	
	var _get = function get(object, property, receiver) { var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ('value' in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };
	
	var _inherits = function (subClass, superClass) { if (typeof superClass !== 'function' && superClass !== null) { throw new TypeError('Super expression must either be null or a function, not ' + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) subClass.__proto__ = superClass; };
	
	Object.defineProperty(exports, '__esModule', {
	    value: true
	});
	
	var _React = __webpack_require__(3);
	
	var _React2 = _interopRequireWildcard(_React);
	
	var _import = __webpack_require__(1);
	
	var _import2 = _interopRequireWildcard(_import);
	
	var _Item = __webpack_require__(105);
	
	var _Item2 = _interopRequireWildcard(_Item);
	
	//This is a render-view only rendering allowed
	
	var RenderView1 = (function (_React$Component) {
	    function RenderView1(props) {
	        _classCallCheck(this, RenderView1);
	
	        _get(Object.getPrototypeOf(RenderView1.prototype), 'constructor', this).call(this, props);
	    }
	
	    _inherits(RenderView1, _React$Component);
	
	    _createClass(RenderView1, [{
	        key: 'makeItems',
	        value: function makeItems() {
	            var tempItems = [];
	            _import2['default'].forEach(this.props.menuItems.links, function (item, i) {
	                tempItems.push(_React2['default'].createElement(_Item2['default'], { key: i, item: item }));
	            });
	            return tempItems;
	        }
	    }, {
	        key: 'render',
	        value: function render() {
	            console.log('this.props', this.props);
	
	            return _React2['default'].createElement(
	                'nav',
	                { className: 'menu' },
	                _React2['default'].createElement(
	                    'span',
	                    null,
	                    this.props.uid,
	                    ': '
	                ),
	                this.makeItems()
	            );
	        }
	    }]);
	
	    return RenderView1;
	})(_React2['default'].Component);
	
	exports['default'] = RenderView1;
	module.exports = exports['default'];

/***/ },

/***/ 36:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _interopRequireWildcard = function (obj) { return obj && obj.__esModule ? obj : { 'default': obj }; };
	
	Object.defineProperty(exports, '__esModule', {
	    value: true
	});
	
	var _McFly = __webpack_require__(2);
	
	var _McFly2 = _interopRequireWildcard(_McFly);
	
	var _Data = __webpack_require__(152);
	
	var _Data2 = _interopRequireWildcard(_Data);
	
	var _Const = __webpack_require__(107);
	
	var _Const2 = _interopRequireWildcard(_Const);
	
	var Flux = new _McFly2['default']();
	var menuMockData = _Data2['default'];
	exports['default'] = Flux.createStore({
	    getItems: function getItems(childrenFrom, pages) {
	        return menuMockData;
	    }
	}, function (payload) {
	    console.log('payload', payload);
	    if (payload.actionType === _Const2['default'].MENU_CHANGE) {
	        console.log('RÖÖÖÖQ');
	        this.emitChange();
	    }
	});
	module.exports = exports['default'];

/***/ },

/***/ 105:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _interopRequireWildcard = function (obj) { return obj && obj.__esModule ? obj : { 'default': obj }; };
	
	var _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } };
	
	var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();
	
	var _get = function get(object, property, receiver) { var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ('value' in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };
	
	var _inherits = function (subClass, superClass) { if (typeof superClass !== 'function' && superClass !== null) { throw new TypeError('Super expression must either be null or a function, not ' + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) subClass.__proto__ = superClass; };
	
	Object.defineProperty(exports, '__esModule', {
	    value: true
	});
	
	var _React = __webpack_require__(3);
	
	var _React2 = _interopRequireWildcard(_React);
	
	//This is a render-view only rendering allowed
	
	var RenderView1 = (function (_React$Component) {
	    function RenderView1(props) {
	        _classCallCheck(this, RenderView1);
	
	        _get(Object.getPrototypeOf(RenderView1.prototype), 'constructor', this).call(this, props);
	    }
	
	    _inherits(RenderView1, _React$Component);
	
	    _createClass(RenderView1, [{
	        key: 'render',
	        value: function render() {
	            return _React2['default'].createElement(
	                'a',
	                { style: { paddingLeft: '10px' }, className: this.props.item.state, href: this.props.item.link },
	                this.props.item.title
	            );
	        }
	    }]);
	
	    return RenderView1;
	})(_React2['default'].Component);
	
	exports['default'] = RenderView1;
	module.exports = exports['default'];

/***/ },

/***/ 107:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	module.exports = {
		MENU_CHANGE: 'MENU_CHANGE'
	};

/***/ },

/***/ 152:
/***/ function(module, exports, __webpack_require__) {

	module.exports = {
		"links": [
			{
				"state": "inactive",
				"title": "link1",
				"link": "/link1"
			},
			{
				"state": "inactive",
				"title": "link2",
				"link": "/link2"
			},
			{
				"state": "active",
				"title": "link3",
				"link": "/link3"
			},
			{
				"state": "inactive",
				"title": "link4",
				"link": "/link4"
			},
			{
				"state": "inactive",
				"title": "link5",
				"link": "/link5"
			},
			{
				"state": "inactive",
				"title": "link6",
				"link": "/link6"
			},
			{
				"state": "inactive",
				"title": "link8",
				"link": "/link8"
			},
			{
				"state": "inactive",
				"title": "link9",
				"link": "/link9"
			},
			{
				"state": "inactive",
				"title": "link10",
				"link": "/link10"
			},
			{
				"state": "inactive",
				"title": "link11",
				"link": "/link11"
			}
		]
	}

/***/ }

});
//# sourceMappingURL=app.js.map