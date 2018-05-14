﻿(function () {
    $(function () {
        var $dataTable = $(".dataTable");
        var _changeWorkService = abp.services.app.changeWork;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.ChangeWork.CreateChangeWork'),
            edit: abp.auth.hasPermission('Pages.ChangeWork.EditChangeWork'),
            del: abp.auth.hasPermission('Pages.ChangeWork.DeleteChangeWork'),
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/changeWork/getPagedAsync",
                filters: [
                    {
                        key: "filterText",
                        selector: $("#filterText")
                    },
                ],
                ingore: []
            },
            fileds: [
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
                    }
                },
                { "data": "userName" },
                { "data": "timeStr" },
                { "data": "beUserName" },
                { "data": "reason" },

                { "data": "beTimeStr" },
                { "data": "positionName" },
                { "data": "bePositionName" },
                { "data": "status" },
                { "data": "statusDes" },
                { "data": "leader" },
                {
                    "data": "isOnDuty",
                    render: function (data, type, row, meta) {
                        if (data === true)
                            return "是";
                        else
                            return "否";
                    }
                },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');
                        if (_permissions.edit) {
                            $('<a title="编辑" href="javascript:;" class="m-l-xs nodecoration edit" data-title="编辑" ><i class="glyphicon glyphicon-pencil"></i> </a>')
                                .appendTo($div);
                        }
                        if (_permissions.del) {
                            $('<a title="删除" href="javascript:;" class="m-l-xs nodecoration delete"><i class="glyphicon glyphicon-trash"></i> </a>')
                                .appendTo($div);
                        }
                        return $div.html();
                    }
                }
            ],
            methods: [
                {
                    actionName: "editAction",
                    url: abp.appPath + "ChangeWorks/changeWork/create"
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/changeWork/deleteAsync"
                }
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    url: abp.appPath + "ChangeWorks/ChangeWork/Create"
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/changeWork/batchDeleteAsync"
                }
            ]
        };
        $dataTable.createDatatable(options);

        // TODO: 页面其他处理

    });
})();