(function () {
    $(function () {
        var $dataTable = $(".dataTable");
        var _platoonGroupService = abp.services.app.platoonGroup;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.PlatoonGroup.CreatePlatoonGroup'),
            edit: abp.auth.hasPermission('Pages.PlatoonGroup.EditPlatoonGroup'),
            del: abp.auth.hasPermission('Pages.PlatoonGroup.DeletePlatoonGroup'),
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/platoonGroup/getPagedAsync",
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
                { "data": "platoonGroupName" },
                { "data": "groupLeaderName" },
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
                    url: abp.appPath + "PlatoonGroups/platoonGroup/create"
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/platoonGroup/deleteAsync"
                }
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    url: abp.appPath + "PlatoonGroups/PlatoonGroup/Create"
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/platoonGroup/batchDeleteAsync"
                }
            ]
        };
        $dataTable.createDatatable(options);

        // TODO: 页面其他处理

    });
})();