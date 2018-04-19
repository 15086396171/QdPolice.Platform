


$(function () {
    DataList();


    $("#Btnkqmonth").click(function () {
       
        $("#StartTime").val("2018-05-01");
        $("#EndTime").val("2018-05-31");
        $("#search").click();
    });
});


function DataList() {
    var $dataTable = $(".dataTable");
    var _kqstatisticsService = abp.services.app.kqstatistic;

    var option = {
        listAction: {
            url: abp.appPath + "api/services/app/kqstatistic/getKqStatisticAsync",
            filters: [
                {
                    key: "UserName",
                    selector: $("#UserName")
                },
                {
                    key: "StartTime",
                    selector: $("#StartTime")
                },
                {
                    key: "EndTime",
                    selector: $("#EndTime")
                }
            ]
        },

        fileds: [
            { "data": "userName" },
            { "data": "groupName" },
            { "data": "normalDay" },
            { "data": "lateDay" },
            { "data": "leaveEarlyDay" },
            { "data": "absenteeismDay" },
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    var $div = $('<div></div>');

                    $('<a title="查看" href="javascript:;" class="m-l-xs nodecoration details" data-title="查看" ><i class="glyphicon glyphicon-search"></i> </a>')
                        .appendTo($div);


                    return $div.html();
                }
            }
        ],

        methods: [

            {
                actionName: "details",
                selector: "a.details",
                action: function (data) {
                    var StartTime = $("#StartTime").val();
                    var EndTime = $("#EndTime").val();

                    var index = layer.open({
                        title: "",
                        type: 2,
                        area: ['90%', '550px'],
                        content: abp.appPath +

                        "KqStatistics/KqStatistic/Detail?UserName=" + data.userName + "&StartTime=" + StartTime + "&EndTime=" + EndTime
                    });

                    layer.full(index);
                }
            }

        ]

        //,
        //commonMethods: [
        //    {
        //        actionName: "kqmonthAction",
        //        url: abp.appPath + "api/services/app/kqstatistic/getKqMonthStatisticAsync"
        //    },
        //    {
        //        actionName: "kqyearAction",
        //        url: abp.appPath + "api/services/app/kqstatistic/getKqYearStatisticAsync"
        //    }
        //]
    }

    console.info(option);

    $dataTable.createDatatable(option);
}