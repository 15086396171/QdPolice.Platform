(function () {
  $(function () {
    var $dataTable = $(".dataTable");
    var _deviceService = abp.services.app.device;

    var _permissions = {
      create: abp.auth.hasPermission('Pages.Device.CreateDevice'),
      edit: abp.auth.hasPermission('Pages.Device.EditDevice'),
      del: abp.auth.hasPermission('Pages.Device.DeleteDevice'),
    };

    var options = {
      listAction: {
        url: abp.appPath + "api/services/app/device/getPagedAsync",
        filters: [
          {
            key: "filterText",
            selector: $("#filterText")
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
        {
          data: "user", render: function (user) {
            if (user)
              return user.name;

            return "";
          }
        },
        {
          data: "user", render: function (user) {
            if(user)
              return user.policeNo;

            return "";
          }
        },
        { "data": "no" },
        { "data": "imei" },
        { "data": "appVersion" },
        { "data": "systemVersion" },
        {
          "data": "isOnline",
          render: function (data, type, row, meta) {
            if (data === true)
              return "是";
            else
              return "否";
          }
        },
        {
          "data": "id",
          render: function (data, type, row, meta) {
            var $div = $('<div></div>');
            $('<a title="查看" href="javascript:;" class="m-l-xs nodecoration details" data-title="查看" ><i class="glyphicon glyphicon-search"></i> </a>')
              .appendTo($div);

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
          url: abp.appPath + "Devices/device/create"
        },
        {
          actionName: "deleteAction",
          url: abp.appPath + "api/services/app/device/deleteAsync"
        },
        {
          actionName: "details",
          selector: "a.details",
          action: function (data) {
            var index = layer.open({
              title: "管控设备",
              type: 2,
              area: ['90%', '550px'],
              content: abp.appPath +
              "Devices/Device/Details/" + data.id //这里content是一个URL，如果你不想让iframe出现滚动条，你还可以content: ['http://sentsin.com', 'no']
            });
            layer.full(index);
          }
        }
      ],
      commonMethods: [
        {
          actionName: "createAction",
          url: abp.appPath + "Devices/Device/Create"
        },
        {
          actionName: "batchAction",
          url: abp.appPath + "api/services/app/device/batchDeleteAsync"
        }
      ]
    };
    $dataTable.createDatatable(options);

    // TODO: 页面其他处理

  });
})();