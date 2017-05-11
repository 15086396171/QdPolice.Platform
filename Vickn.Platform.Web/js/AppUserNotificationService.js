var AppUserNotificationService = (function ($) {

    return function () {
        var notificationService = abp.services.app.notification;
        //获取图片路径
        function getNotificationImgBySeverity(severity) {
            switch (severity) {
                case abp.notifications.severity.SUCCESS:
                    return '/App/assets/yoyocms/notification/1.png';
                case abp.notifications.severity.WARN:
                    return '/App/assets/yoyocms/notification/2.png';
                case abp.notifications.severity.ERROR:
                    return '/App/assets/yoyocms/notification/3.png';
                case abp.notifications.severity.FATAL:
                    return '/App/assets/yoyocms/notification/4.png';
                case abp.notifications.severity.INFO:
                default:
                    return '/App/assets/yoyocms/notification/0.png';
            }
        }

        //格式化消息
        var formattedMessage = function (item) {

            var message = {
                id: item.id,
                text: abp.notifications.getFormattedMessageFromUserNotification(item),
                time: item.notification.creationTime,
                image: getNotificationImgBySeverity(item.notification.severity),
                state: abp.notifications.getUserNotificationStateAsString(item.state),
            }

            return message;

        }

        var makeAllAsReadService = function () {
            notificationService.makeAllUserNotificationsAsRead().then(function () {
                abp.event.trigger('abp.notifications.refresh');
            });
        }

        var makeNotificationAsReadService = function (userNotificationId, callback) {
            notificationService.makeNotificationAsRead({ id: userNotificationId }).
                then(function () {
                    abp.event.trigger('app.notifications.reflesh', userNotificationId);
                    //用于处理回调函数
                    callback && callback(userNotificationId);

                });
        }


        return {
            formattedMessage: formattedMessage,
            makeAllAsReadService: makeAllAsReadService,
            makeNotificationAsReadService: makeNotificationAsReadService
        }

    }
})(jQuery);