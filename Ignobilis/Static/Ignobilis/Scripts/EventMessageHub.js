$(function () {
    var msg = $.connection.eventMessageHub;

    msg.client.clearMessages = function () {
        $("#eventMessages").html("");
    }
    msg.client.broadcastMessage = function (typ, message, url) {
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

    window.EventMessageHubJoinGroup = function (groupName) {
        $.connection.hub.start().done(function () {
            msg.server.joinGroup(groupName);
        });
    };
});