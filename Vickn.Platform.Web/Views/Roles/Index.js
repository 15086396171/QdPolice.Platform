$(function () {
    var _permissionTree;
    var _roleServices = abp.services.app.role;
    var _roleId;
    var _modal = $("#modal-setPermission");

    $(".btn-setPermission").click(function () {
        _modal.modal("show");
        _roleId = $(this).data('id');
        var url = $(this).data('url');
        _modal.find(".modal-body").load(url, { id: _roleId }, function () {
            _permissionTree = new PermissionsTree();
            _permissionTree.init(_modal.find(".permission-tree"));
        });
    });
    $(".btn-SetPermissionOk").click(function () {
        abp.ui.setBusy(_modal);
        var permissions = _permissionTree.getSelectedPermissionNames();
        _roleServices.updateRolePermissionsAsync({
            roleId: _roleId,
            grantedPermissionNames: permissions
        }).done(function () {
            abp.notify.success("修改权限成功");
        }).always(function () {
            abp.ui.clearBusy(_modal);
            _modal.modal("hide");
        });
    });
})();