var abp = abp || {};
(function ($) {

    /* DEFAULTS *************************************************/

    abp.libs = abp.libs || {};
    abp.libs.sweetAlert = {
        config: {
            'default': {

            },
            info: {
                type: 'info'
            },
            success: {
                type: 'success'
            },
            warn: {
                type: 'warning'
            },
            error: {
                type: 'error'
            },
            confirm: {
                type: 'warning',
                title: 'Are you sure?',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                confirmButtonColor: "#DD6B55",
                confirmButtonText: 'Yes'
            }
        }
    };

    /* MESSAGE **************************************************/

    var showMessage = function (type, message, title) {
        if (!title) {
            title = message;
            message = undefined;
        }

        var opts = $.extend(
            {},
            abp.libs.sweetAlert.config['default'],
            abp.libs.sweetAlert.config[type],
            {
                title: title,
                text: message
            }
        );

        return $.Deferred(function ($dfd) {
            sweetAlert(opts, function () {
                $dfd.resolve();
            });
        });
    };

    abp.message.info = function (message, title) {
        return layer.alert(message, { icon: 7, title: title });
    };

    abp.message.success = function (message, title) {
        return layer.alert(message, { icon: 1, title: title });
    };

    abp.message.warn = function (message, title) {
        return layer.alert(message, { icon: 7, title: title });
    };

    abp.message.error = function (message, title) {
        //return showMessage('error', message, title);
        return layer.alert(message, { icon: 2, title: title });
    };

    abp.message.confirm = function (message, titleOrCallback, callback) {

        var title = "确定操作？";

        if ($.isFunction(titleOrCallback)) {
            callback = titleOrCallback;
        } else if (titleOrCallback) {
            title = titleOrCallback;
        };

       return  layer.confirm(message, { icon: 3, title:title }, function (index) {
            callback();
            layer.close(index);
        });
    };

    abp.event.on('abp.dynamicScriptsInitialized', function () {
        abp.libs.sweetAlert.config.confirm.title = abp.localization.abpWeb('AreYouSure');
        abp.libs.sweetAlert.config.confirm.cancelButtonText = abp.localization.abpWeb('Cancel');
        abp.libs.sweetAlert.config.confirm.confirmButtonText = abp.localization.abpWeb('Yes');
    });

})(jQuery);
