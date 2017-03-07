/// <reference path="~/Abp/Framework/scripts/abp.js" />
/// <reference path="~/Content/H-ui.admin_v3.0/lib/layer/2.4/layer.js" />
var commonCreateOrEdit = function (url, title) {
    var index = layer.open({
        type: 2,
        title: title,
        content: url
    });
    layer.full(index);
}

var layerClosethis = function () {
    var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
    parent.layer.close(index); //再执行关闭  
}

