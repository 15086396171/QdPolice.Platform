(function ($) {
    $.fn.extend({
        createDatatable: function (options) {
            var customerInput = options.listAction.input || {};
            var settings = options.settings || {};

            var _settings = {
                ordering: settings.ordering != undefined ? settings.ordering : false, //取消默认排序查询,否则复选框一列会出现小箭头
                autoWidth: settings.autoWidth != undefined ? settings.autoWidth : true, //禁用自动调整列宽
                "aLengthMenu": [customerInput.maxResultCount || 10],
                bPaginate: settings.bPaginate != undefined ? settings.bPaginate : true,
                info: settings.info != undefined ? settings.info : true,
                serverSide: true, //启用服务器端分页
                "retrieve": true,  //保证只有一个table实例
                deferRender: true,
                bLengthChange: false,
                searching: false,
                stripeClasses: ["text-c"],
                processing: false,
                ajax: options.listAction.method || function (data, callback, setting) {
                    var input = {
                        pageIndex: customerInput.pageIndex || parseInt(data.start / data.length) + 1,
                        maxResultCount: customerInput.maxResultCount || 10,
                        draw: data.draw
                    };

                    if (options.listAction.filters) {
                        $.each(options.listAction.filters, function (index, value) {
                            if (value) // 兼容IE8
                                eval("input." + value.key + " ='" + $(value.selector).val() + "'");
                        });
                    }
                    abp.ajax({
                        url: options.listAction.url,
                        data: JSON.stringify(input)
                    }).done(function (result) {
                        var returnData = {
                            draw: data.draw, //这里直接自行返回了draw计数器,应该由后台返回
                            recordsTotal: result.totalCount,
                            recordsFiltered: result.totalCount,
                            data: result.items,
                        };
                        callback(returnData);
                    });
                },
                columns: options.fileds
            };
            $(this).dataTable(_settings);
            addEvent(this, options);
            addCommonEvents({ target: this, listAction: options.listAction, commonMethods: options.commonMethods });
        },
        search: function () {
            $(this).DataTable().draw();
        }
    });

    function addEvent(target, options) {
        if (!options.methods)
            return;
        $.each(options.methods, function (index, data) {
            if (data) {// 兼容IE8
                var actionOptions = {};
                if (data.actionName === "editAction") {
                    actionOptions.isAjax = false;
                    actionOptions.selector = data.selector || "a.edit";
                }
                else if (data.actionName === "deleteAction") {
                    actionOptions.isAjax = true;
                    actionOptions.isConfirm = true;
                    actionOptions.selector = data.selector || "a.delete";
                    actionOptions.confirmMsg = "确定删除本条数据？";
                }
                else {
                    var dataActionOptions = data.actionOptions || {};
                    actionOptions.isAjax = dataActionOptions.isAjax || false;
                    actionOptions.isConfirm = dataActionOptions.isConfirm || true;
                    actionOptions.confirmMsg = dataActionOptions.confirmMsg;
                    actionOptions.selector = data.selector;
                }
                actionOptions.target = target;
                actionOptions.event = data.event || "click";
                actionOptions.action = data.action;
                actionOptions.url = data.url;
                bindAction(actionOptions);
            }
        });
    }

    function bindAction(options) {
        $(options.target).on(options.event || "click", options.selector, function () {
            var table = $(options.target).DataTable();
            var tr = $(this).closest('tr');
            var data = table.row($(this).parents('tr')).data();
            if (options.action) {
                options.action(data,tr);
            } else {
                if (options.isAjax) {
                    if (options.isConfirm)
                        var index1 = layer.confirm(options.confirmMsg || "确定操作？",
                            function () {
                                abp.ajax({
                                    url: options.url,
                                    data: JSON.stringify({ id: data.id })
                                }).done(function () {
                                    table.draw();
                                });
                                layer.close(index1);
                            });
                    else {
                        alert("操作成功");
                    }
                } else {
                    var url = options.url || "/";
                    if (url.indexOf("?") > 0) {
                        url += "&id=" + data.id;
                    } else {
                        url += "?id=" + data.id;
                    }
                    if (options.isConfirm) {
                        var index2 = layer.confirm(options.confirmMsg || "确定操作？",
                            function () {
                                window.location.href = url;
                                layer.close(index2);
                            });
                    } else {
                        window.location.href = url;
                    }
                }
            }
        });
    }

    function addCommonEvents(options) {
        $("#search").on("click", function () {
            if (options.listAction.search) {
                options.listAction.search();
            }
            else {
                $(options.target).search();
            }
        });
        $("#research").click(function () {
            if (options.listAction.research) {
                options.listAction.research();
            }
            else {
                if (options.listAction.filters) {
                    $.each(options.listAction.filters,
                        function (index, value) {
                            $(value.selector).val("");
                        });
                }
                $(options.target).search();
            }
        });
        if (!options.commonMethods)
            return;
        $.each(options.commonMethods,
            function (index, data) {
                if (data) { //兼容IE8
                    if (data.actionName === "createAction") {
                        $("#create").click(function () {
                            if (data.action)
                                data.action();
                            else {
                                window.location.href = data.url;
                            }
                        });
                    }
                    else if (data.actionName === "batchAction") {
                        $("#batchDelete").click(function () {
                            if (data.action)
                                data.action();
                            else {
                                var input = [];
                                $('input[class="check-box"]:checked').each(function (index2, data2) {
                                    input.push($(data2).val());
                                });
                                if (input.length === 0) {
                                    layer.alert("请选择要删除的数据");
                                    return;
                                }
                                var index1 = layer.confirm('确定删除?',
                                    function () {
                                        abp.ajax({
                                            url: data.url,
                                            data: JSON.stringify(input)
                                        }).done(function () {
                                            $(options.target).search();
                                        });
                                        layer.close(index1);
                                    });
                            }
                        });
                    }
                }
                // 不必实现else，由index.js自行实现
            });
    }

    $(function() {
        $(".checkall").click(function () {
            var check = $(this).prop("checked");
            $("input[type='checkbox']").prop("checked", check);
        });
    });
})(jQuery);