(function () {
    $(function () {
        var _tree = new OrganizationUnitTree();

        var _service = abp.services.app.organizationUnit;

        var _$parentId = $("<input></input>");

        var $dataTable = $(".dataTable");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.OrganizationUnit.CreateOrganizationUnit'),
            edit: abp.auth.hasPermission('Pages.OrganizationUnit.EditOrganizationUnit'),
            del: abp.auth.hasPermission('Pages.OrganizationUnit.DeleteOrganizationUnit'),
            manageuser: abp.auth.hasPermission("Pages.OrganizationUnit.ManageUser")
        };

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/organizationUnit/getPagedOrganizationUnitAsync",
                filters: [
                    {
                        key: "displayName",
                        selector: $("#displayName")
                    },
                    {
                        key: "parentId",
                        selector: _$parentId
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
                {
                    "data": "creationTime",
                    render: function (data, type, row, meta) {
                        return moment(data).format("YYYY-MM-DD HH:mm:ss");
                    }
                },
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        var $div = $('<div></div>');

                        if (_permissions.manageuser) {
                            if (_permissions.edit) {
                                $('<a title="管理用户" href="javascript:;" class="m-l-xs nodecoration manageUser"><i class="glyphicon glyphicon-user"></i></a>')
                                    .appendTo($div);
                            }
                        }
                        if (_permissions.edit) {
                            $('<a title="编辑" href="javascript:;" class="m-l-xs nodecoration edit"><i class="glyphicon glyphicon-pencil"></i> </a>')
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
                    url: abp.appPath + "organizationUnits/create",
                },
                {
                    actionName: "deleteAction",
                    url: abp.appPath + "api/services/app/organizationUnit/deleteOrganizationUnit",
                },
                {
                    actionName: "manageUser",
                    selector: "a.manageUser",
                    action: manageUser
                }
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    action: function () {
                            window.location.href = abp
                                .appPath +
                                "OrganizationUnits/Create?parentId=" +
                                _$parentId.val();
                    }
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/organizationUnit/batchDeleteOrganizationUnitAsync"
                }
            ]
        };
        $dataTable.createDatatable(options);

        _tree.init($(".organizationUnit"), function (node) {
            _$parentId.val(node.Id);
            $dataTable.DataTable().draw();
        });

        function manageUser(row) {
            var ouId = row.id;
            layer.open({
                type: 2,
                area: ['600px', '80%'],
                fix: false, //不固定
                maxmin: true,
                shade: 0.4,
                title: row.displayName + "用户管理",
                content: abp.appPath + "OrganizationUnits/UserAddToOu?ouId=" + ouId,
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    //do something
                    var body = layer.getChildFrame('body', index);

                    var input = {
                        ouId: ouId,
                        userIds: [],
                        delUserIds: []
                    };

                    var $selected = $(body).find('input[class="check-box"]');
                    $.each($selected, function (i, data) {
                        if ($(data).is(":checked")) {

                            input.userIds.push($(data).val());
                        } else {
                            if ($(data).data("checked"))
                                input.delUserIds.push($(data).val());
                        }
                    });

                    _service.addUserToOuAsync(input).done(function () {
                        abp.notify.success("用户已添加到" + row.displayName);
                        layer.close(index); //如果设定了yes回调，需进行手工关闭
                    });


                },
                cancel: function (index, layero) {
                    layer.close(index);
                    return false;
                }
            });
        }
    });
})();