(function () {
    $(function () {
        var _tree = new OrganizationUnitTree();

        var $dataTable = $(".dataTable");

        var _service = abp.services.app.organizationUnit;

        var _dataTable = new DataTable();

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
                var returnData = {};
                returnData.draw = data.draw; //这里直接自行返回了draw计数器,应该由后台返回
                returnData.recordsTotal = result.totalCount;
                returnData.recordsFiltered = result.totalCount;
                returnData.data = result.items;
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
                          $('<a title="编辑" href="javascript:;" class="ml-5 btn-openWindow" data-title="编辑" data-url="' + abp.appPath + 'OrganizationUnits/Create?id=' + data + '" style="text-decoration: none"><i class="Hui-iconfont">&#xe6df;</i></a>').on("click", function () {
                              alert();
                          })
                          .appendTo($div);
                      }
                      if (_permissions.delete) {
                          $('<a title="删除" href="javascript:;" class="ml-5 btn-delete" style="text-decoration: none" data-id="' + data + '"><i class="Hui-iconfont">&#xe6e2;</i></a>')
                              .appendTo($div);
                      }
                      return $div.html();
                  }
              },
        ];

        _dataTable.Init($dataTable, columns, columnDefs, ajax);

        _tree.init($(".organizationUnit"), abp.appPath + "OrganizationUnits/Index", function (parentId) {
            _parentId = parentId;
            _dataTable.Search();
        });

        $dataTable.on('draw.dt', function () {
            $(".btn-openWindow").on("click", function () {
                var index = layer.open({
                    type: 2,
                    title: "编辑组织机构",
                    content: $(this).data("url")
                });
                layer.full(index);
            });
            $(".btn-delete").on("click", function () {
                var id = $(this).data("id");
                var index = layer.confirm('确定删除?', function () {
                    _service.deleteOrganizationUnit({ id: id }).done(function () {
                        location.reload();
                    });
                });
            });
        });

        $("#search").click(function () {
            _dataTable.Search();
        });
    });
})();