﻿(function () {
    $(function () {
        var $dataTable = $(".dataTable");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.DataDictionary.CreateDataDictionary'),
            edit: abp.auth.hasPermission('Pages.DataDictionary.EditDataDictionary'),
            'del': abp.auth.hasPermission('Pages.DataDictionary.DeleteDataDictionary')
        };
        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/dataDictionary/getPagedAsync",
                filters: [
                    {
                        key: "displayName",
                        selector: $("#displayName")
                    }
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
                { "data": "key" },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');

                        if (_permissions.edit) {

                            $('<a title="管理字典项" href="javascript:;" class="m-l-xs nodecoration manage" ><i class="glyphicon glyphicon-th-list"></i> </a>')
                                .appendTo($div);
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
                url: abp.appPath + "DataDictionaries/create"
            },
            {
                actionName: "deleteAction",
                url: abp.appPath + "api/services/app/dataDictionary/deleteAsync"
            },
            {
                actionName: "manageAction",
                selector: "a.manage",
                action: function (data) {
                    window.location.href = abp.appPath + "DataDictionaryItems?dataDictionaryId=" + data.id;
                }
            }
            ],
            commonMethods: [
              {
                  actionName: "createAction",
                  url: abp.appPath + "DataDictionaries/Create"
              },
              {
                  actionName: "batchAction",
                  url: abp.appPath + "api/services/app/dataDictionary/batchDeleteAsync"
              }
            ]
        };

        $dataTable.createDatatable(options);
    });

})();