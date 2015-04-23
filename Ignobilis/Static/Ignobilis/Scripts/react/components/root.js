import React from 'react';
import MenuRoot from './menu/root';

var userActivityHub = $.connection.userActivityHub;

$.connection.hub.start().done(function() {

    $('.react-user-activity').each(function() {
        let id = $(this).attr('id');
        userActivityHub.server.joinBlockGroup(id);
    });
});

userActivityHub.client.updateUsersOnlineCount = function(userinfo) {
    console.log(userinfo);
}

/*$('.react-menu').each(function()
    {
        let id = $(this).attr('id');
        let childrenFrom = $(this).attr('data-children-from');
        let pages = $(this).attr('data-pages');

        React.render(<MenuRoot uid={id} childrenFrom={childrenFrom} pages={pages} />, document.getElementById(id));
});*/
