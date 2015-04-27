import React from 'react';
import MenuRoot from './menu/root';
import UserActivityRoot from './useractivity/root';

$(function() {
    var userActivityHub = $.connection.userActivityHub;
    var eventMessageHub = $.connection.eventMessageHub;

    window.EventMessageHubJoinGroup = function(groupName) {
        $.connection.hub.start().done(function() {
            eventMessageHub.server.joinGroup(groupName);            
        });
    };

    $.connection.hub.start().done(function() {
        var userActivities = [];
        $('.react-user-activity').each(function() {
            let id = $(this).attr('id');
            userActivities.push(id);
        });

        if (userActivities.length > 0) {
            userActivityHub.server.joinBlockGroups(userActivities);
        }
    });

    userActivityHub.client.updateUsersOnlineCount = function(userinfo, bGroup) {
        //console.log(bGroup);
        //console.log(userinfo);
        React.render( < UserActivityRoot
        users = { userinfo } /  > , document.getElementById(bGroup));
    }


    eventMessageHub.client.clearMessages = function() {
        $("#eventMessages").html("");
    }
    eventMessageHub.client.broadcastMessage = function(typ, message, url) {
        var icon;
        switch (typ) {
        case "emergency":
            icon = '<i class="fa fa-exclamation-circle"></i>';
            break;
        case "warning":
            icon = '<i class="fa fa-exclamation-triangle"></i>';
            break;
        case "information":
            icon = '<i class="fa fa-info-circle"></i>';
            break;
        case "default":
            icon = '<i class="fa fa-exclamation"></i>';
            break;
        case "error":
            icon = '<i class="fa fa-bug"></i>';
            break;
        default:
            icon = '<i class="fa fa-exclamation"></i>';
            break;
        }

        $("#eventMessages").append('<div class="message ' + typ + '">' + icon + '<strong>' + message + '</strong><a target="_blank" href="' + url + '">Läs mer</a></div>');
    };
});

/*$('.react-menu').each(function()
    {
        let id = $(this).attr('id');
        let childrenFrom = $(this).attr('data-children-from');
        let pages = $(this).attr('data-pages');

        React.render(<MenuRoot uid={id} childrenFrom={childrenFrom} pages={pages} />, document.getElementById(id));
});*/
