(function () {
    $(function () {
        var $dataTable = $(".dataTable");
        var _schedulingPostService = abp.services.app.schedulingPost;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.SchedulingPost.CreateSchedulingPost'),
            edit: abp.auth.hasPermission('Pages.SchedulingPost.EditSchedulingPost'),
            del: abp.auth.hasPermission('Pages.SchedulingPost.DeleteSchedulingPost'),
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/schedulingPost/getPagedAsync",
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
                { "data": "postName" },
          
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        console.log(row);
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
                    url: abp.appPath + "SchedulingPosts/schedulingPost/create"
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/schedulingPost/deleteAsync"
                }
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    url: abp.appPath + "SchedulingPosts/SchedulingPost/Create"
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/schedulingPost/batchDeleteAsync"
                }
            ]
        };
        $dataTable.createDatatable(options);

        // TODO: 页面其他处理

    });
})();