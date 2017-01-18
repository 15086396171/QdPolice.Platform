/// <reference path="~/Abp/Framework/scripts/abp.js" />
/// <reference path="~/Content/H-ui.admin_v2.5/lib/layer/2.1/layer.js" />
(function ($) {
    $('.btn-create').on('click', function () {
        var url = $(this).data('url');
        var title = $(this).data('title');
        if (title === undefined) title = '添加';
        if (url === undefined || url === "") {
            abp.log.error('url is undefined');
            return;
        }
        var index = layer.open({
            type: 2,
            title: title,
            content: url
        });
        layer.full(index);
    });
    $('.btn-delete').on('click', function () {
        var url = $(this).data('url');
        layer.confirm('确定删除?', function () {
            abp.ajax({
                url: url
            }).done(function () {
                location.reload();
            });
        });
    });
    $('.btn-delAll').on('click', function () {
        var chk_value = [];
        var url = $(this).data('url');
        $('input[class="check-box"]:checked').each(function (index, data) {
            chk_value.push($(data).val());
        });
        if (chk_value.length == 0) {
            layer.alert("请选择要删除的数据");
            return;
        }
        layer.confirm('确定删除?', function () {
            abp.ajax({
                url: url,      
                data: JSON.stringify(chk_value)
            }).done(function () {
                location.reload();
            });
        });
    });
})(jQuery);