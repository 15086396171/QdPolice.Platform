(function () {
    $(function () {
        var $dataTable = $(".dataTable");
        var _service = abp.services.app.auditLog;

        var ajax = function (data, callback, settings) {
            var input = {
                pageIndex: parseInt(data.start / data.length) + 1,
                maxResultCount: data.length,
                userName: $("#userName").val()
            };
            _service.getAuditLogs(input).done(function (result) {
                var returnData = {};
                returnData.draw = data.draw; //这里直接自行返回了draw计数器,应该由后台返回
                returnData.recordsTotal = result.totalCount;
                returnData.recordsFiltered = result.totalCount; 
                returnData.data = result.items;
                callback(returnData);
            });
        };
        var columns = [
            { "data": "id" },
            { "data": "exception" },
            { "data": "executionTime" },
            { "data": "userName" },
            { "data": "serviceName" },
            { "data": "methodName" },
            { "data": "executionDuration" },
            { "data": "clientIpAddress" },
            { "data": "clientName" },
            { "data": "browserInfo" },
        ];
        var columnDefs = [
            {
                //   指定第一列，从0开始，0表示第一列，1表示第二列……
                targets: 0,
                render: function (data, type, row, meta) {
                    var $div = $('<div class=\"text-center\"></div>');
                    $div.append('<a href="javascript:void(0)" class="detail"><i class="Hui-iconfont Hui-iconfont-search2"></i></a>');

                    return $div.html();
                }
            },
            {
                targets: 1,
                render: function (data, type, row, meta) {
                    var $div = $('<div class=\"text-center\"></div>');

                    if (data) {
                        $div.append('<span class="label label-warning round"><i class="Hui-iconfont Hui-iconfont-close"></i></span>');
                    } else {
                        $div.append('<span class="label label-success round"><i class="Hui-iconfont Hui-iconfont-xuanze"></i></span>');
                    }

                    return $div.html();
                }
            },
            {
                targets: 2,
                render: function (data, type, row, meta) {
                    return moment(data).format("YYYY-MM-DD HH:mm:ss");
                }
            },
        ];
        var dataTable = new DataTable();
        dataTable.Init($dataTable, columns, columnDefs, ajax);

        $("#search").click(function () {
            dataTable.Search();
        });
    });
})();