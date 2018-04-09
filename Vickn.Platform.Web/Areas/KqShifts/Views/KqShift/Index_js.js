(function () {
    $(function () {
        var $dataTable = $(".dataTable");
        var _kqshiftsService = abp.services.app.kqshift;
      
        var _permissions = {
            create: abp.auth.hasPermission('Pages.KqShift.CreateKqShift'),
            edit: abp.auth.hasPermission('Pages.KqShift.EditKqShift'),
            del: abp.auth.hasPermission('Pages.KqShift.DeleteKqShift'),

        };
      
        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/kqshift/getPagedAsync",
               
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
                { "data": "shiftName" },
                { "data": "workTime" },
                { "data": "closingTime" },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');

                        $('<a title="班次人员" href="javascript:;" class="m-l-xs nodecoration shiftuser"><i class="glyphicon glyphicon-user"></i> </a>')
                            .appendTo($div);

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
                    url: abp.appPath + "KqShifts/KqShift/Create"
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/kqshift/deleteAsync"
                },
                {
                    actionName: "details",
                    selector: "a.details",
                    action: function (data) {
                        var index = layer.open({
                            title: "",
                            type: 2,
                            area: ['90%', '550px'],
                            content: abp.appPath +
                            "Announcements/announcement/SelectMessage/" + data.id //这里content是一个URL，如果你不想让iframe出现滚动条，你还可以content: ['http://sentsin.com', 'no']
                        });
                        layer.full(index);
                    }
                }

            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    url: abp.appPath + "KqShifts/KqShift/Create"
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/kqshift/batchDeleteAsync"
                }
            ]
        };
        $dataTable.createDatatable(options);

        // TODO: 页面其他处理

    });
})();