(function () {
    $(function () {
        var appUserNotificationService = new AppUserNotificationService();
        var notificationService = abp.services.app.notification;
        var _$message = $("#message");
        var _$messageContent = $("#message-Content");
        var _modal = $("#modal-MyInfo");

        var getUserNotificationsAsync = function () {
            notificationService.getPagedUserNotificationsAsync({
                state: 0,
                maxResultCount: 5
            }).then(function (result) {
                if (result.unreadCount > 0) {
                    _$message.html(result.unreadCount);
                    var $div = $("<div></div>");
                    $.each(result.items,
                        function (index, item) {
                            var $divp = $("<div class=\"prettyprint\" style=\"margin-bottom:5px;\"></div>");
                            $(' <div><span class="label label-secondary round" > <i class="Hui-iconfont Hui-iconfont-more"></i></span> ' + appUserNotificationService.formattedMessage(item).text + '</div>').appendTo($divp);
                            $('<span class="txt-small">' + moment(item.notification.creationTime).format("YYYY-MM-DD hh:mm:ss") + '</span>').appendTo($divp);
                            $('<a href="javascript:void(0)" data-id=' + item.id + '  class="clearfix txt-small markAsRead"> <span class="makeasread-text label label-secondary radius">[标为已读]</span></a >').appendTo($divp);
                            $divp.appendTo($div);
                        });
                    _$messageContent.attr("data-content", $div.html());

                } else {
                    _$message.html("");
                    _$messageContent.attr("data-content", "没有通知消息");
                }
            });
        }
        _$messageContent.on('shown.bs.popover',
            function () {
                $(".markAsRead").bind("click", function () {
                    var id = $(this).data("id");
                    makeNotificationAsRead(id);
                });
            });

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

        // 我的信息
        $("#myInfo").click(function () {
            _modal.modal("show");
            _modal.find(".modal-body").load(abp.appPath + "Users/MyInfo", {}, function () {
                // 设置form验证就不行，其他都可以
                $("form").validate({
                    rules: {
                        UserEditDto_Name: {
                            required: true,
                            minlength: 2,
                            maxlength: 16
                        },
                    },
                    onkeyup: false,
                    focusCleanup: true,
                    success: "valid",
                    submitHandler: function (form) {
                        //$(form).ajaxSubmit();
                        alert();
                    }
                });
            });
        });
        $("#btn-Ok").click(function () {
            $("form").submit();
        });
    });
})(jQuery);