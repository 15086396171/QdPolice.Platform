(function () {
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
                    }
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
                { "data": "reason" },
                { "data": "positionName" },
                { "data": "beUserName" },
                { "data": "beTimeStr" },
                { "data": "bePositionName" },
                { "data": "status", "className":"status_red" },
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
                        
                        if (row.status== "待领导审核") {
                            if (_permissions.edit) {
                                $(
                                    '<a title="同意换班" href="javascript:;" class="m-l-xs nodecoration edit" data-title="同意换班" ><i class="glyphicon glyphicon-ok"></i> </a>')
                                    .appendTo($div);


                                $(
                                    '<a title="不同意换班" href="javascript:;" class="m-l-xs nodecoration remove" data-title="不同意换班" ><i class="glyphicon glyphicon-remove"></i> </a>')
                                    .appendTo($div);
                            }



                        }



                        if (row.status!= "换班完成") {
                            if (_permissions.del) {
                                $(
                                    '<a title="删除" href="javascript:;" class="m-l-xs nodecoration delete"><i class="glyphicon glyphicon-trash"></i> </a>')
                                    .appendTo($div);
                            }
                        }


                        return $div.html();
                    }
                }
            ],
            methods: [
                {
                    actionName: "editAction",
                    url: abp.appPath + "api/services/app/changeWork/leaderAgreeChangeWorkAsync"
                },
                {
                    actionName: "removeAction",
                   
                    url: abp.appPath + "api/services/app/changeWork/leaderNotAgreeChangeWorkAsync"
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