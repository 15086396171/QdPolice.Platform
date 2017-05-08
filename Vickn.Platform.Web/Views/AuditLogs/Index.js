(function () {
    $(function () {
        var $dataTable = $(".dataTable");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.AuditLog.CreateAuditLog'),
            edit: abp.auth.hasPermission('Pages.AuditLog.EditAuditLog'),
            'delete': abp.auth.hasPermission('Pages.AuditLog.DeleteAuditLog')
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/auditLog/getAuditLogs",
                filters: [
                    {
                        key: "name",
                        selector: $("#name")
                    }
                ]
            },
            fileds: [
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div class=\"text-center\"></div>');
                        $div.append('<a href="javascript:void(0)" class="detail"><i class="Hui-iconfont Hui-iconfont-search2"></i></a>');

                        return $div.html();
                    }
                },
                {
                    "data": "exception",
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
                    "data": "executionTime",
                    render: function (data, type, row, meta) {
                        return moment(data).format("YYYY-MM-DD HH:mm:ss");
                    }
                },
                { "data": "userName" },
                { "data": "serviceName" },
                { "data": "methodName" },
                { "data": "executionDuration" },
                { "data": "clientIpAddress" },
                { "data": "clientName" },
                { "data": "browserInfo" }
            ]
        };
        $dataTable.createDatatable(options);
    });
})();