(function () {
    $(function () {
        var _tree = new OrganizationUnitTree();

        var _service = abp.services.app.organizationUnit;

        var _$parentId = $("<input></input>");

        var $dataTable = $(".dataTable");

        var _permissions = {
            create: abp.auth.hasPermission('Pages.OrganizationUnit.CreateOrganizationUnit'),
            edit: abp.auth.hasPermission('Pages.OrganizationUnit.EditOrganizationUnit'),
            del: abp.auth.hasPermission('Pages.OrganizationUnit.DeleteOrganizationUnit')
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
                        if (_permissions.edit) {
                            $('<a title="编辑" href="javascript:;" class="ml-5 edit" data-title="编辑"><i class="Hui-iconfont">&#xe6df;</i></a>')
                                .appendTo($div);
                        }
                        if (_permissions.del) {
                            $('<a title="删除" href="javascript:;" class="ml-5 delete"><i class="Hui-iconfont">&#xe6e2;</i></a>')
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
                    url: abp.appPath + "api/services/app/organizationUnit/deleteOrganizationUnitAsync",
                },
            ],
            commonMethods: [
                {
                    actionName: "createAction",
                    action: function () {
                        $("#create").click(function () {
                            window.location.href = abp
                                .appPath +
                                "OrganizationUnits/Create?parentId=" +
                                _$parentId.val();
                        });
                    }
                },
                {
                    actionName: "batchAction",
                    url: abp.appPath + "api/services/app/organizationUnit/batchDeleteOrganizationUnitAsync"
                }
            ]
        };
        $dataTable.createDatatable(options);

        _tree.init($(".organizationUnit"), abp.appPath + "OrganizationUnits/Index", function (parentId) {
            _$parentId.val(parentId);
            $dataTable.DataTable().draw();
        });
    });
})();