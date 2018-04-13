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

                        //$('<a title="班次人员" href="javascript:;" class="m-l-xs nodecoration shiftuser"><i class="glyphicon glyphicon-user"></i> </a>')
                        //    .appendTo($div);

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