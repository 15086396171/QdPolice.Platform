(function () {
    $(function () {
        if (window.top !== window.self) { window.top.location = window.location; }
        var appUserNotificationService = new AppUserNotificationService();
        var notificationService = abp.services.app.notification;
        var _$message = $("#messageCount");
        var _$messageContent = $("#messageContent");

        var getUserNotificationsAsync = function () {
            notificationService.getPagedUserNotificationsAsync({
                state: 0,
                maxResultCount: 5
            }).then(function (result) {
                if (result.unreadCount > 0) {
                    _$message.html(result.unreadCount);
                    _$messageContent.children("li.m-t-xs").remove();
                    _$messageContent.children("li.divider").remove();
                    $.each(result.items, function (index, item) {
                        var li = '<li class="m-t-xs">'+
                        '<div class="dropdown-messages-box">' + ' <a href="javascript:;" class="pull-left"><img alt="image" class="img-circle" src="/Images/SystemMsg.png"></a>' + '<div class="media-body">' +
                             appUserNotificationService.formattedMessage(item).text +
                            '<br><small class="text-muted">' + moment(item.notification.creationTime).format("YYYY-MM-DD hh:mm:ss") +
                            '<a href="javascript:void(0)" data-id=' + item.id + '  class="markAsRead"><span class="label label-primary radius">[标为已读]</span></a></small></div></div></li><li class="divider"></li>';
                        $("#messageContent li").eq(0).after(li);
                    });
                    //_$messageContent.append('<li><div class="text-center link-block"><a class="J_menuItem" href="/Notifications/MyNotification"><i class="fa fa-envelope"></i> <strong> 查看所有消息</strong></a></div></li>');
                    $(".markAsRead").bind("click", function () {
                        var id = $(this).data("id");
                        makeNotificationAsRead(id);
                    });
                } else {
                    //_$messageContent.append('<li><div class="text-center link-block"><a class="J_menuItem" href="/Notifications/MyNotification"><i class="fa fa-envelope"></i> <strong> 查看所有消息</strong></a></div></li>');
                }
            });
        }

        function makeNotificationAsRead(userNotificationId) {
            appUserNotificationService.makeNotificationAsReadService(userNotificationId);
        }
        getUserNotificationsAsync();

        abp.event.on("app.notifications.reflesh", function () {
            _$messageContent.popover('hide');
            getUserNotificationsAsync();
        });
        abp.event.on('abp.notifications.received', function (userNotification) {
            getUserNotificationsAsync();
        });

    });
})(jQuery);