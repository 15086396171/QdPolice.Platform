(function () {
    $(function () {
        var _tree = new OrganizationUnitTree();
        var _dataTable = new DataTable();

        var _service = abp.services.app.organizationUnit;

        var _parentId;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.OrganizationUnit.CreateOrganizationUnit'),
            edit: abp.auth.hasPermission('Pages.OrganizationUnit.EditOrganizationUnit'),
            'delete': abp.auth.hasPermission('Pages.OrganizationUnit.DeleteOrganizationUnit')
        };

        var ajax = function (data, callback, settings) {
            var input = {
                pageIndex: parseInt(data.start / data.length) + 1,
                maxResultCount: data.length,
                parentId: _parentId,
                displayName: $("#displayName").val()
            };
            _service.getPagedOrganizationUnitAsync(input).done(function (result) {
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
            { "data": "displayName" },
            { "data": "creationTime" },
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
                targets: 2,
                render: function (data, type, row, meta) {
                    return moment(data).format("YYYY-MM-DD HH:mm:ss");
                }
            },
              {
                  targets: 3,
                  render: function (data, type, row, meta) {
                      var $div = $('<div></div>');
                      if (_permissions.edit) {
                          $('<a title="编辑" href="javascript:;" class="ml-5 edit" data-title="编辑" data-id="'+ data + '" style="text-decoration: none"><i class="Hui-iconfont">&#xe6df;</i></a>').on("click", function () {
                              alert();
                          })
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

        _tree.init($(".organizationUnit"), abp.appPath + "OrganizationUnits/Index", function (parentId) {
            _parentId = parentId;
            _dataTable.search();
        });

        _dataTable.init($(".dataTable"), columns, columnDefs, ajax);

        _dataTable.setEvents([
            {
                selector: ".edit",
                event: "click",
                callback: function () {
                    commonCreateOrEdit(abp.appPath + "OrganizationUnits/Create?Id=" + $(this).data("id"));
                }
            },
            {
                selector: ".delete",
                event: "click",
                callback: function () {
                    var id = $(this).data("id");
                    var index = layer.confirm('确定删除该组织机构?', function () {
                        _service.deleteOrganizationUnit({ id: id })
                            .done(function () {
                                location.reload();
                            });
                    });
                }
            }
        ]);

        $("#search").click(function () {
            _dataTable.search();
        });
        $("#create")
            .click(function() {
                if (_parentId)
                    commonCreateOrEdit(abp.appPath + "OrganizationUnits/Create?parentId=" + _parentId);
                else
                    commonCreateOrEdit(abp.appPath + "OrganizationUnits/Create");
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
                _service.batchDeleteOrganizationUnitAsync(input)
                    .done(function() {
                        window.location.reload();
                    });
            });
        });
        $("#research")
            .click(function() {
                $("#displayName").val("");
                _parentId = null;
                _dataTable.search();
            });
    });
})();