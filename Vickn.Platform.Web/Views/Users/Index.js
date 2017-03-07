(function () {
    $(function () {
        var _userService = abp.services.app.user;
        var _dataTable = new DataTable();

        var _permissions = {
            create: abp.auth.hasPermission('Pages.User.CreateUser'),
            edit: abp.auth.hasPermission('Pages.User.EditUser'),
            'delete': abp.auth.hasPermission('Pages.User.DeleteUser')
        };

        var ajax = function (data, callback, settings) {
            var input = {
                pageIndex: parseInt(data.start / data.length) + 1,
                maxResultCount: data.length,
                name: $("#name").val()
            };
            _userService.getPagedUsersAsync(input).done(function (result) {
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
            { "data": "userName" },
            { "data": "surname" },
            { "data": "emailAddress" },
            { "data": "phoneNumber" },
            { "data": "isActive" },
            { "data": "lastLoginTime" },
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
                targets: 6,
                render: function (data, type, row, meta) {
                    if (data === true)
                        return '<span class="label label-success radius">已启用</span>';
                    else return '<span class="label label-warning radius">未启用</span>';
                }
            },
             {
                 targets: 7,
                 render: function (data, type, row, meta) {
                     if (data)
                         return moment(data).format("YYYY-MM-DD HH:mm:ss");
                     else return "";
                 }
             },
              {
                  targets: 8,
                  render: function (data, type, row, meta) {
                      var $div = $('<div></div>');
                      if (_permissions.edit) {
                          // &#xe631;
                          if (row.isActive === true) {
                              $('<a title="禁用" href="javascript:;" class="ml-5 diable" data-title="禁用" data-id="' +
                             data +
                             '" style="text-decoration: none"><i class="Hui-iconfont">&#xe631;</i></a>')
                         .appendTo($div);
                          }
                          else
                              $('<a title="启用" href="javascript:;" class="ml-5 diable" data-title="启用" data-id="' +
                                      data +
                                      '" style="text-decoration: none"><i class="Hui-iconfont">&#xe631;</i></a>')
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
                    commonCreateOrEdit(abp.appPath + "Users/Create?Id=" + $(this).data("id"));
                }
            },
            {
                selector: ".delete",
                event: "click",
                callback: function () {
                    var id = $(this).data("id");
                    var index = layer.confirm('确定删除该用户?', function () {
                        _userService.deleteUserAsync({ id: id })
                            .done(function () {
                                location.reload();
                            });
                    });
                }
            },
            {
                selector: ".diable",
                event: "click",
                callback: function () {
                    var id = $(this).data('id');
                    _userService.disableUser({ id: id }).done(function () {
                        location.reload();
                    });
                }
            }
        ]);

        $("#search").click(function () {
            _dataTable.search();
        });
        $("#create")
            .click(function () {
                commonCreateOrEdit(abp.appPath + "Users/Create");
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
                _userService.batchDeleteUserAsync(input)
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

    });
})();