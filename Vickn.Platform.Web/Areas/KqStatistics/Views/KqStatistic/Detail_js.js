


$(function () {

    var $dataTable = $(".dataTable");
    var _kqstatisticsService = abp.services.app.kqstatistic;

    var option = {
        listAction: {
            url: abp.appPath + "api/services/app/kqstatistic/getKqDetailStatisticAsync",
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
            { "data": "dateYMD" },
            { "data": "dateWork" },
            {
                "data": "outgoingCauseWork",
                render: function (data, type, row, meta) {
                    return $('<div><a title="' + data + '" href="#" >' + data.substring(0, 9) + "..." + ' </a></div>').html();
                }
            },
            {
                "data": "qdPostionWork",
                render: function (data, type, row, meta) {

                    return $('<div ><a title="' + data + '" onclick="' + SelectContent(data) +'">' + data.substring(0, 9) + "..." + ' </a></div>').html();

                }
            },
            { "data": "dateColsing" },
            {
                "data": "outgoingCauseClosing",
                render: function (data, type, row, meta) {
                    return $('<div><a title="' + data + '">' + data.substring(0, 9) + "..." + ' </a></div>').html();
                }
            },
            {
                "data": "qdPostionClosing",
                render: function (data, type, row, meta) {
                    return $('<div><a title="' + data + '">' + data.substring(0, 9) + "..." + ' </a></div>').html();
                }
            },
            { "data": "qdType" }


        ],

        //commonMethods: [
           
        //    {
        //        actionName: "btnexport",
        //        url: abp.appPath + "api/services/app/kqstatistic/batchDeleteAsync"
        //    }
        //]
    }

    $dataTable.createDatatable(option);
});

function SelectContent(data) {
    //layer.msg(''+data+'', {
    //    skin: 'layui-layer-molv' //样式类名  自定义样式
    //    , closeBtn: 1    // 是否显示关闭按钮
    //    , anim: 1 //动画类型
       
    //    , time: 10000 //2s后自动关闭
    //    , icon: 6    // icon
      
    //});
}