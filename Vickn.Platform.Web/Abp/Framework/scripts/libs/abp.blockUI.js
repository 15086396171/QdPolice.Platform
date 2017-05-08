var abp = abp || {};
(function () {

    if (!$.blockUI) {
        return;
    }

    $.extend($.blockUI.defaults, {
        message: ' ',
        css: {},
        overlayCSS: {
            backgroundColor: '#AAA',
            opacity: 0.3,
            cursor: 'wait'
        }
    });

    var index = -1;
    abp.ui.block = function (elm) {
        if (!elm) {
            index = layer.load(2);
        } else {
            $(elm).block();
        }
        return index;
    };

    abp.ui.unblock = function (elm) {
        if (!elm) {
            layer.close(index);
        } else {
            $(elm).unblock();
        }
    };

})();