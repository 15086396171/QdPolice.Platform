(function () {
  $(function () {
    var $dataTable = $(".dataTable");
    var _privatePhoneWhiteService = abp.services.app.privatePhoneWhite;

    var _permissions = {
      create: abp.auth.hasPermission('Pages.PrivatePhoneWhite.CreatePrivatePhoneWhite'),
      edit: abp.auth.hasPermission('Pages.PrivatePhoneWhite.EditPrivatePhoneWhite'),
      del: abp.auth.hasPermission('Pages.PrivatePhoneWhite.DeletePrivatePhoneWhite'),
    };

    var $userId = $("#userId");

    var options = {
      listAction: {
        url: abp.appPath + "api/services/app/privatePhoneWhite/getPagedAsync",
        filters: [
          {
            key: "filterText",
            selector: $("#filterText")
          },
          {
            key: "userId",
            selector: $("#userId")
          },
        ],
        ingore: []
      },
      fileds: [
        {
          "data": "id",
          render: function (data, type, row, meta) {
            return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
          }
        },
        { "data": "name" },
        { "data": "phoneNumber" },
        {
          "data": "id",
          render: function (data, type, row, meta) {
            var $div = $('<div></div>');
            if (_permissions.edit) {
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
          url: abp.appPath + "PrivatePhoneWhites/privatePhoneWhite/create?userId=" + $userId.val()
        },
        {
          actionName: "deleteAction",
          url: abp.appPath + "api/services/app/privatePhoneWhite/deleteAsync"
        }
      ],
      commonMethods: [
        {
          actionName: "createAction",
          url: abp.appPath + "PrivatePhoneWhites/PrivatePhoneWhite/Create?userId=" + $userId.val()
        },
        {
          actionName: "batchAction",
          url: abp.appPath + "api/services/app/privatePhoneWhite/batchDeleteAsync"
        }
      ]
    };
    $dataTable.createDatatable(options);

    // TODO: 页面其他处理

  });
})();