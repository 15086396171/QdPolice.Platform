﻿(function () {
  $(function () {
    var $dataTable = $(".dataTable");
    var _pbPositionService = abp.services.app.pbPosition;

    var _permissions = {
      create: abp.auth.hasPermission('Pages.PbPosition.CreatePbPosition'),
      edit: abp.auth.hasPermission('Pages.PbPosition.EditPbPosition'),
      del: abp.auth.hasPermission('Pages.PbPosition.DeletePbPosition'),
    };

    var options = {
      listAction: {
        url: abp.appPath + "api/services/app/pbPosition/getPagedAsync",
        filters: [
          {
            key: "pbTitleId",
            selector: $("#pbTitleId")
          },
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
          data: "position",
          render:function(data) {
            if (data)
              return data.name;

            return "";
          }
        },
        {
          "data": "isTrue",
          render: function (data, type, row, meta) {
            if (data === true)
              return "是";
            else
              return "否";
          }
        },
        {
          "data": "month",
          render: function (data, type, row, meta) {
            return moment(data).format("YYYY-MM");
          }
        },
        {
          "data": "id",
          render: function (data, type, row, meta) {
            var $div = $('<div></div>');
            //if (_permissions.edit) {
            //  $('<a title="编辑" href="javascript:;" class="m-l-xs nodecoration edit" data-title="编辑" ><i class="glyphicon glyphicon-pencil"></i> </a>')
            //    .appendTo($div);
            //}
            //if (_permissions.del) {
            //  $('<a title="删除" href="javascript:;" class="m-l-xs nodecoration delete"><i class="glyphicon glyphicon-trash"></i> </a>')
            //    .appendTo($div);
            //}
            return $div.html();
          }
        }
      ],
      methods: [
        {
          actionName: "editAction",
          url: abp.appPath + "PbPositions/pbPosition/create"
        },
        {
          actionName: "deleteAction",
          url: abp.appPath + "api/services/app/pbPosition/deleteAsync"
        }
      ],
      commonMethods: [
        {
          actionName: "createAction",
          url: abp.appPath + "PbPositions/PbPosition/Create"
        },
        {
          actionName: "batchAction",
          url: abp.appPath + "api/services/app/pbPosition/batchDeleteAsync"
        }
      ]
    };
    $dataTable.createDatatable(options);

    // TODO: 页面其他处理

  });
})();