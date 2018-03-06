(function () {
    $(function () {
        var $dataTable = $(".dataTable");

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
                        selector:$("#Name")
                    }
                ],
                input: {
                    maxResultCount: 100
                }
            },
            fileds: [
                {
                    data: "id",
                    render: function (data, type, row, meta) {
                        if (row.isChecked) {
                            return '<input type="checkbox" class="check-box" checked name="check-box" data-checked="true" value="' + data + '">';
                        }
                        return '<input type="checkbox" class="check-box" name="check-box" value="' + data + '">';
                    }
                },
                {
                    data: "name"
                },
              {
                data: "userName"
                }
            ]
        };
        $dataTable.createDatatable(options);

    });
})();