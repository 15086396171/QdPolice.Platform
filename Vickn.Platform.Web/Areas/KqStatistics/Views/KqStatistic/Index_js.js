


$(function () {
    DataList();


    $("#Btnkqmonth").click(function () {

        var date = new Date();
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var StartTime = year + '-' + month + '-01';//当月第一天  
        var day = new Date(year, month, 0);
        var EndTime = year + '-' + month + '-' + day.getDate();//当月最后一天  

        $("#StartTime").val(StartTime);
        $("#EndTime").val(EndTime);
        $("#search").click();
    });

    $("#Btnkqyear").click(function () {

        var now = new Date();
        var year = now.getFullYear();
        var StartTime = year + "-01-01";
        var EndTime = year + "-12-31";

        $("#StartTime").val(StartTime);
        $("#EndTime").val(EndTime);
        $("#search").click();
    });
    $("#Btnkqweek").click(function () {
   

        var now = new Date();
        var nowTime = now.getTime();
        var day = now.getDay();
        var oneDayLong = 24 * 60 * 60 * 1000;

        var MondayTime = nowTime - (day - 1) * oneDayLong;
        var SundayTime = nowTime + (7 - day) * oneDayLong;


        var StartTimes = new Date(MondayTime);
        var EndTimes = new Date(SundayTime);

        var y = StartTimes.getFullYear();
        var m = StartTimes.getMonth() + 1;
        if (m < 10) {
            m = "0" + m;
        }
        var d = StartTimes.getDate();
        if (d < 10) {
            d = "0" + d;
        }
        var StartTime = y + "-" + m + "-" + d;

        var y2 = EndTimes.getFullYear();
        var m2 = EndTimes.getMonth() + 1;
        if (m2 < 10) {
            m2 = "0" + m2;
        }
        var d2 = EndTimes.getDate();
        if (d2 < 10) {
            d2 = "0" + d2;
        }
        var EndTime = y2 + "-" + m2 + "-" + d2;

        $("#StartTime").val(StartTime);
        $("#EndTime").val(EndTime);
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
            { "data": "kqShiftName" },
            { "data": "normalDay" },
            { "data": "lateDay" },
            { "data": "leaveEarlyDay" },
            { "data": "absenteeismDay" },
            { "data": "abnormalDay" },

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