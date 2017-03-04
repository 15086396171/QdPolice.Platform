﻿var DataTable = (function ($) {
    return function () {
        var $dataTable;

        var _settings;

        function init($dataTableContainer, columns, columnDefs, ajax) {
            $dataTable = $dataTableContainer;
            _settings = {
                autoWidth: false, //禁用自动调整列宽
                ordering: false, //取消默认排序查询,否则复选框一列会出现小箭头
                serverSide: true, //启用服务器端分页
                deferRender: true,
                bLengthChange: false,
                searching: false,
                stripeClasses:
                ["text-c"],
                "retrieve": true,  //保证只有一个table实例
                ajax: ajax,
                columns: columns,
                columnDefs: columnDefs
            };
            $dataTable.dataTable(_settings);
        }

        function search() {
            $dataTable.fnDraw();
        }

        return {
            Init: init,
            Search: search
        };
    }
})(jQuery);