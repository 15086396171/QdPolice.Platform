(function () {
  $(function () {
    var $dataTable = $(".dataTable");
    var _announcementService = abp.services.app.announcement;

    var _permissions = {
      create: abp.auth.hasPermission('Pages.Announcement.CreateAnnouncement'),
      edit: abp.auth.hasPermission('Pages.Announcement.EditAnnouncement'),
      del: abp.auth.hasPermission('Pages.Announcement.DeleteAnnouncement'),
    };

    var options = {
      listAction: {
        url: abp.appPath + "api/services/app/announcement/getPagedAsync",
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
        { "data": "title" },
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
          url: abp.appPath + "Announcements/announcement/create"
        },
        {
          actionName: "deleteAction",
          url: abp.appPath + "api/services/app/announcement/deleteAsync"
        }
      ],
      commonMethods: [
        {
          actionName: "createAction",
          url: abp.appPath + "Announcements/Announcement/Create"
        },
        {
          actionName: "batchAction",
          url: abp.appPath + "api/services/app/announcement/batchDeleteAsync"
        }
      ]
    };
    $dataTable.createDatatable(options);

    // TODO: 页面其他处理

  });
})();