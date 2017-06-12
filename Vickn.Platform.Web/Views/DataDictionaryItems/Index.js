(function () {
    $(function () {
        var $dataTable = $(".dataTable");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.DataDictionaryItem.CreateDataDictionaryItem'),
            edit: abp.auth.hasPermission('Pages.DataDictionaryItem.EditDataDictionaryItem'),
            'del': abp.auth.hasPermission('Pages.DataDictionaryItem.DeleteDataDictionaryItem')
        };
        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/dataDictionaryItem/getPagedAsync",
                filters: [
                    {
                        key: "displayName",
                        selector: $("#displayName")
                    },
                    {
                        key: "dataDictionaryId",
                        selector: $("#dataDictionaryId")
                    }
                ],
                ingore: [
                    "dataDictionaryId"
                ]
            },
            fileds: [
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
                    }
                },
                { "data": "displayName" },
                { "data": "value" },
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
                url: abp.appPath + "DataDictionaryItems/create?dataDictionaryId=" + $("#dataDictionaryId").val()
            },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/dataDictionaryItem/deleteAsync"
                },
            ],
            commonMethods: [
              {
                  actionName: "createAction",
                  url: abp.appPath + "DataDictionaryItems/Create/?dataDictionaryId=" + $("#dataDictionaryId").val()
              },
              {
                  actionName: "batchAction",
                  url: abp.appPath + "api/services/app/dataDictionaryItem/batchDeleteAsync"
              }
            ]
        };

        $dataTable.createDatatable(options);
    });

})();