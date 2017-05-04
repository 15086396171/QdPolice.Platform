(function () {
    $(function () {
        var $dataTable = $(".dataTable");
        var _permissionTree;
        var _roleService = abp.services.app.role;
        var _modal = $("#modal-setPermission");
        var _roleId;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Role.CreateRole'),
            edit: abp.auth.hasPermission('Pages.Role.EditRole'),
            'delete': abp.auth.hasPermission('Pages.Role.DeleteRole')
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/role/getPagedAsync",
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
                        return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
                    }
                },

                { "data": "name" },
                { "data": "displayName" },
                { "data": "isStatic" },
                { "data": "isDefault" },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');
                        if (_permissions.edit) {
                            // &#xe631;

                            $('<a title="设置权限" href="javascript:;" class="ml-5 setPermission" data-title="设置权限"><i class="Hui-iconfont">&#xe681;</i></a>')
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
                },
            ],
            methods: [
                {
                    actionName: "editAction",
                    url: abp.appPath + "roles/create",
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/role/deleteAsync",
                },
                {
                    actionName: "setPermissionAction",
                    action: function (row) {
                        _modal.modal("show");
                        _roleId = row.id;
                        var url = abp.appPath + "Roles/SetPermissions";
                        _modal.find(".modal-body").load(url, { id: _roleId }, function () {
                            _permissionTree = new PermissionsTree();
                            _permissionTree.init(_modal.find(".permission-tree"));
                        });
                    },
                    selector: "a.setPermission",

                }
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    url: abp.appPath + "Roles/Create"
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/role/batchDeleteAsync"
                },
            ]
        };
        $dataTable.createDatatable(options);

        $(".btn-SetPermissionOk").click(function () {
            abp.ui.setBusy(_modal);
            var permissions = _permissionTree.getSelectedPermissionNames();
            _roleService.updateRolePermissionsAsync({
                roleId: _roleId,
                grantedPermissionNames: permissions
            }).done(function () {
                abp.notify.success("修改权限成功");
            }).always(function () {
                abp.ui.clearBusy(_modal);
                _modal.modal("hide");
            });
        });
    });
})();