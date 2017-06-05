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
            del: abp.auth.hasPermission('Pages.Role.DeleteRole'),
            editPermissoin: abp.auth.hasPermission('Pages.Role.EditRolePermission')
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/role/getPagedAsync",
                filters: [
                    {
                        key: "roleName",
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
                { "data": "isStaticDes" },
                { "data": "isDefaultDes" },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');
                        if (_permissions.editPermissoin) {
                            $('<a title="设置权限" href="javascript:;" class="m-l-xs setPermission" data-title="设置权限"> <i class="glyphicon glyphicon-list-alt"></i> </a>')
                          .appendTo($div);
                        }
                        if (_permissions.edit) {
                            // &#xe631;
                            $('<a title="编辑" href="javascript:;" class="m-l-xs nodecoration edit" data-title="编辑" > <i class="glyphicon glyphicon-pencil"></i> </a>')
                                .appendTo($div);
                        }
                        if (_permissions.del) {
                            $('<a title="删除" href="javascript:;" class="m-l-xs nodecoration delete"> <i class="glyphicon glyphicon-trash"></i> </a>')
                                .appendTo($div);
                        }
                        return $div.html();
                    }
                }
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