(function () {
    $(function () {
        var $dataTable = $(".dataTable");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.User.CreateUser'),
            edit: abp.auth.hasPermission('Pages.User.EditUser'),
            'delete': abp.auth.hasPermission('Pages.User.DeleteUser')
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/user/getPagedUsersAsync",
                filters: [
                    {
                        key: "name",
                        selector: $("#name"),
                    },

                ]
            },
            fileds: [
                {
                    data: "id",
                    render: function (data, type, row, meta) {
                        return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
                    }
                },
                {
                    data: "name",
                },
                { "data": "userName" },
                { "data": "surname" },
                { "data": "emailAddress" },
                { "data": "phoneNumber" },
                {
                    "data": "isActive",
                    render: function (data, type, row, meta) {
                        if (data === true)
                            return '<span class="label label-success radius">已启用</span>';
                        else return '<span class="label label-warning radius">未启用</span>';
                    }
                },
                {
                    "data": "lastLoginTime",
                    render: function (data, type, row, meta) {
                        if (data)
                            return moment(data).format("YYYY-MM-DD HH:mm:ss");
                        else return "";
                    }
                },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');
                        if (_permissions.edit) {
                            if (row.isActive === true) {
                                $('<a title="禁用" href="javascript:;" class="ml-5 nodecoration disable" data-title="禁用"><i class="Hui-iconfont">&#xe631;</i></a>')
                                    .appendTo($div);
                            } else
                                $('<a title="启用" href="javascript:;" class="ml-5 nodecoration disable" data-title="启用"><i class="Hui-iconfont">&#xe631;</i></a>')
                                    .appendTo($div);

                            $('<a title="编辑" href="javascript:;" class="ml-5 nodecoration edit" data-title="编辑" ><i class="Hui-iconfont">&#xe6df;</i></a>')
                                .appendTo($div);
                        }
                        if (_permissions.delete) {
                            $('<a title="删除" href="javascript:;" class="ml-5 nodecoration delete"><i class="Hui-iconfont">&#xe6e2;</i></a>')
                                .appendTo($div);
                        }
                        return $div.html();
                    }
                }
            ],
            methods: [
                {
                    actionName: "editAction",
                    url: abp.appPath + "users/create",
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/user/deleteUserAsync",
                },
                {
                    actionName: "disableAction",
                    actionOptions: {
                        isAjax: true,
                        isConfirm: true,
                        confirmMsg: "确定更改用户启用状态？",
                    },
                    selector: "a.disable",
                    url: abp.appPath + "api/services/app/user/disableUserAsync",
                }
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    url: abp.appPath + "Users/Create"
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/user/batchDeleteUserAsync"
                },
            ]
        };
        $dataTable.createDatatable(options);
    });
})();