(function () {
  $(function () {
    var _tree = new OrganizationUnitTree();
    var $dataTable = $(".dataTable");
    var _$ouId = $("#ouId");

    var _permissions = {
      create: abp.auth.hasPermission('Pages.User.CreateUser'),
      edit: abp.auth.hasPermission('Pages.User.EditUser'),
      del: abp.auth.hasPermission('Pages.User.DeleteUser'),
      resetPassword: abp.auth.hasPermission('Pages.User.ResetPasswordUser'),
      privatePhone: abp.auth.hasPermission("Pages.PrivatePhoneWhite.CreatePrivatePhoneWhite")
    };

    var options = {
      listAction: {
        url: abp.appPath + "api/services/app/user/getPagedUsersAsync",
        filters: [
          {
            key: "name",
            selector: $("#name")
          },
          {
            key: "OuId",
            selector: _$ouId
          }
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
          data: "name"
        },
        { "data": "userName" },
        { "data": "policeNo" },
        { "data": "position" },
        { "data": "phoneNumber" },
        { "data": "emailAddress" },
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

            if (_permissions.privatePhone) {
              $('<a title="个人白名单" href="javascript:;" class="m-l-xs nodecoration privatePhone"><i class="glyphicon glyphicon-user"></i> </a>')
                .appendTo($div);
            }
            if (_permissions.resetPassword) {
              $('<a title="重置密码" href="javascript:;" class="m-l-xs nodecoration resetPassword"><i class="glyphicon glyphicon-refresh"></i> </a>')
                .appendTo($div);
            }
            if (_permissions.edit) {
              if (row.isActive === true) {
                $('<a title="禁用" href="javascript:;" class="m-l-xs nodecoration disable"><i class="glyphicon glyphicon-off"></i> </a>')
                  .appendTo($div);
              } else
                $('<a title="启用" href="javascript:;" class="m-l-xs nodecoration disable"><i class="glyphicon glyphicon-off"></i> </a>')
                  .appendTo($div);

              $('<a title="编辑" href="javascript:;" class="m-l-xs nodecoration edit" data-title="编辑" ><i class="glyphicon glyphicon-pencil"></i> </a>')
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
          url: abp.appPath + "users/create"
        },
        {
          actionName: "deleteAction",
          url: abp.appPath + "api/services/app/user/deleteUserAsync"
        },
        {
          actionName: "deleteAction",
          selector:"a.privatePhone",
          //url: 
          action:function(data) {
            location.href = abp.appPath + "PrivatePhoneWhites/PrivatePhoneWhite/Index?userId=" + data.id;
          }
        },
        {
          actionName: "disableAction",
          actionOptions: {
            isAjax: true,
            isConfirm: true,
            isNeedSuccessAlert: true,
            confirmMsg: "确定更改用户启用状态？"
          },
          selector: "a.disable",
          url: abp.appPath + "api/services/app/user/disableUserAsync"
        },
        {
          actionName: "resetPasswordAction",
          actionOptions: {
            isAjax: true,
            isConfirm: true,
            confirmMsg: "确认重置密码？"
          },
          selector: "a.resetPassword",
          url: abp.appPath + "api/services/app/user/resetPasswordAsync"
        }
      ],
      commonMethods: [
        {
          actionName: "createAction",
          action: function () {
            if (!_$ouId.val()) {
              abp.message.warn("请选择组织");
              return;
            }
            window.location.href = abp.appPath + "Users/Create?ouId=" + _$ouId.val();
          }
        },
        {
          actionName: "batchAction",
          url: abp.appPath + "api/services/app/user/batchDeleteUserAsync"
        }
      ]
    };
    $dataTable.createDatatable(options);

    _tree.init($(".organizationUnit"), function (node) {
      _$ouId.val(node.Id);
      $dataTable.DataTable().draw();
    });
  });
})();