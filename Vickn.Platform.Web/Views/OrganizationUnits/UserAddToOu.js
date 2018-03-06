(function () {
  $(function () {
    var $dataTable = $(".dataTable");

    var $chose = $("#chose");
    var options = {
      //settings: {
      //    bPaginate: false,
      //    info:false
      //},
      listAction: {
        url: abp.appPath + "api/services/app/organizationUnit/getOrganizationUnitWithAllUserForAdd",
        filters: [
          {
            key: "Id",
            selector: $("#ouId")
          },
          {
            key: "Name",
            selector: $("#Name")
          }
        ],
        input: {
          maxResultCount: 1000
        }
      },
      fileds: [
        {
          data: "id",
          render: function (data, type, row, meta) {
            if (row.isChecked) {
              if ($chose.children("#" + data).length == 0) {
                $chose.append('<a href="javascript:;" class="chose_a" id=' +
                  data +
                  '><i class="glyphicon glyphicon-remove"></i>' +
                  row.name +
                  '  &nbsp;</a>');
              }
              return '<input type="checkbox" id="check_'+data+'" class="check-box" checked name="check-box" data-checked="true" value="' + data + '">';
            }
            return '<input type="checkbox" id="check_' + data +'" class="check-box" name="check-box" value="' + data + '">';
          }
        },
        {
          data: "name"
        },
        {
          data: "userName"
        }
      ],
      methods: [
        {
          actionName: "checkAction",
          selector: ".check-box",
          event: "click",
          action: function (data, tr) {
            var $check = tr.find("#check_"+data.id);
            if ($check.prop("checked"))
              $chose.append('<a href="javascript:;" class="chose_a" id=' +
                data.id +
                '><i class="glyphicon glyphicon-remove"></i>' +
                data.name +
                '  &nbsp;</a>');
            else {
              $chose.children("#" + data.id).remove();
            }
          },
        }]
    };
    $dataTable.createDatatable(options);

    $chose.on("click", ".chose_a",
      function () {
        $("#check_" + $(this).attr("id")).attr("checked", false);
        $(this).remove();
      });
  });
})();