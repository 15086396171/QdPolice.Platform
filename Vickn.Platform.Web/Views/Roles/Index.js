(function () {
    $(function() {
        var _permissionTree;
        var _roleService = abp.services.app.role;
        var _roleId;
        var _modal = $("#modal-setPermission");

        var _dataTable = new DataTable();

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Role.CreateRole'),
            edit: abp.auth.hasPermission('Pages.Role.EditRole'),
            'delete': abp.auth.hasPermission('Pages.Role.DeleteRole')
        };

        var ajax = function (data, callback, settings) {
            var input = {
                pageIndex: parseInt(data.start / data.length) + 1,
                maxResultCount: data.length,
                roleName:$("#name").val()
            };
            _roleService.getPagedAsync(input).done(function (result) {
                var returnData = {
                    draw: data.draw, //这里直接自行返回了draw计数器,应该由后台返回
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items,
                };
                callback(returnData);
            });
        };
        var columns = [
            { "data": "id" },
            { "data": "name" },
            { "data": "displayName" },
            { "data": "isStatic" },
            { "data": "isDefault" },
            { "data": "id" },
        ];
        var columnDefs = [
            {
                //   指定第一列，从0开始，0表示第一列，1表示第二列……
                targets: 0,
                render: function (data, type, row, meta) {
                    return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
                }
            },
            
              {
                  targets: 5,
                  render: function (data, type, row, meta) {
                      var $div = $('<div></div>');
                      if (_permissions.edit) {
                          // &#xe631;
                        
                              $('<a title="设置权限" href="javascript:;" class="ml-5 setPermission" data-title="设置权限" data-id="' +
                             data +
                             '" style="text-decoration: none"><i class="Hui-iconfont">&#xe681;</i></a>')
                         .appendTo($div);

                          $('<a title="编辑" href="javascript:;" class="ml-5 edit" data-title="编辑" data-id="' + data + '" style="text-decoration: none"><i class="Hui-iconfont">&#xe6df;</i></a>')
                          .appendTo($div);
                      }
                      if (_permissions.delete) {
                          $('<a title="删除" href="javascript:;" class="ml-5 delete" style="text-decoration: none" data-id="' + data + '"><i class="Hui-iconfont">&#xe6e2;</i></a>')
                              .appendTo($div);
                      }
                      return $div.html();
                  }
              },
        ];

        _dataTable.init($(".dataTable"), columns, columnDefs, ajax);

        _dataTable.setEvents([
            {
                selector: ".edit",
                event: "click",
                callback: function () {
                    commonCreateOrEdit(abp.appPath + "Roles/Create?Id=" + $(this).data("id"));
                }
            },
            {
                selector: ".delete",
                event: "click",
                callback: function () {
                    var id = $(this).data("id");
                    var index = layer.confirm('确定删除该角色?', function () {
                        _roleService.deleteAsync({ id: id })
                            .done(function () {
                                location.reload();
                            });
                    });
                }
            },
                 {
                     selector: ".setPermission",
                     event: "click",
                     callback: function () {
                         _modal.modal("show");
                         _roleId = $(this).data('id');
                         var url = abp.appPath + "Roles/SetPermissions";
                         _modal.find(".modal-body").load(url, { id: _roleId }, function () {
                             _permissionTree = new PermissionsTree();
                             _permissionTree.init(_modal.find(".permission-tree"));
                         });
                     }
                 },
        ]);

        $("#search").click(function () {
            _dataTable.search();
        });
        $("#create")
            .click(function () {
                commonCreateOrEdit(abp.appPath + "Roles/Create");
            });
        $("#batchDelete").click(function () {
            var input = [];
            var url = $(this).data('url');
            $('input[class="check-box"]:checked').each(function (index, data) {
                input.push($(data).val());
            });
            if (input.length === 0) {
                layer.alert("请选择要删除的数据");
                return;
            }
            layer.confirm('确定删除?', function () {
                _roleService.batchDeleteAsync(input)
                    .done(function () {
                        window.location.reload();
                    });
            });
        });
        $("#research")
            .click(function () {
                $("#name").val("");
                _dataTable.search();
            });

        $(".btn-setPermission").click(function() {
            _modal.modal("show");
            _roleId = $(this).data('id');
            var url = $(this).data('url');
            _modal.find(".modal-body").load(url, { id: _roleId }, function() {
                _permissionTree = new PermissionsTree();
                _permissionTree.init(_modal.find(".permission-tree"));
            });
        });
        $(".btn-SetPermissionOk").click(function() {
            abp.ui.setBusy(_modal);
            var permissions = _permissionTree.getSelectedPermissionNames();
            _roleService.updateRolePermissionsAsync({
                roleId: _roleId,
                grantedPermissionNames: permissions
            }).done(function() {
                abp.notify.success("修改权限成功");
            }).always(function() {
                abp.ui.clearBusy(_modal);
                _modal.modal("hide");
            });
        });
    });
})();