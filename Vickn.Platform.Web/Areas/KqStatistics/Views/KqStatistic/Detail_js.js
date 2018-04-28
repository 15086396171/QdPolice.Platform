


$(function () {

    //$("#btnExport").click(function () {

    //})

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

                    var str = GetStrLength(data);
                    if (str <= 16) return $('<div><a title="' + data + '" class="m-l-xs nodecoration outgoingCauseWork" >' + data + ' </a></div>').html();
                    else return $('<div><a title="' + data + '" class="m-l-xs nodecoration outgoingCauseWork" >' + data.substring(0, 9) + "..." + ' </a></div>').html();
                }
            },
            {
                "data": "qdPostionWork",
                render: function (data, type, row, meta) {

                    return $('<div ><a title="' + data + '" class="m-l-xs nodecoration qdpostionwork" >' + data.substring(0, 9) + "..." + ' </a></div>').html();

                }
            },
            { "data": "dateColsing" },
            {
                "data": "outgoingCauseClosing",
                render: function (data, type, row, meta) {
                    var str = GetStrLength(data);
                    if (str <= 16) return $('<div><a title="' + data + '" class="m-l-xs nodecoration outgoingCauseClosing" >' + data + ' </a></div>').html();
                    return $('<div><a title="' + data + '" class="m-l-xs nodecoration outgoingCauseClosing">' + data.substring(0, 9) + "..." + ' </a></div>').html();
                }
            },
            {
                "data": "qdPostionClosing",
                render: function (data, type, row, meta) {
                    return $('<div><a title="' + data + '" class="m-l-xs nodecoration qdpostionclosing">' + data.substring(0, 9) + "..." + ' </a></div>').html();
                }
            },
            { "data": "qdType" }


        ],

        methods: [
            {
                actionName: "qdpostionworkAction",
                selector: "a.qdpostionwork",
                event: "click",
                action: function (data, tr) {
                    // TODO:处理自定义事件
                    SelectContent(data.qdPostionWork)
                },
            },
            {
                actionName: "qdpostionclosingAction",
                selector: "a.qdpostionclosing",
                event: "click",
                action: function (data, tr) {
                    // TODO:处理自定义事件
                    SelectContent(data.qdPostionClosing)
                },
            },
            {
                actionName: "outgoingCauseWorkAction",
                selector: "a.outgoingCauseWork",
                event: "click",
                action: function (data, tr) {
                    // TODO:处理自定义事件
                    SelectContent(data.outgoingCauseWork)
                },
            },
            {
                actionName: "outgoingCauseClosingAction",
                selector: "a.outgoingCauseClosing",
                event: "click",
                action: function (data, tr) {
                    // TODO:处理自定义事件
                    SelectContent(data.outgoingCauseClosing)
                },
            },

        ],

        
    }

    $dataTable.createDatatable(option);
});

//弹框查看详情
function SelectContent(data) {
    layer.msg(''+data+'', {
        skin: 'layui-layer-molv' //样式类名  自定义样式
        , closeBtn: 1    // 是否显示关闭按钮
        , anim: 1 //动画类型

        , time: 10000 //2s后自动关闭
        , icon: 6    // icon

    });
}

//获取字符串长度
function GetStrLength(str) {
   
        return str.replace(/[\u0391-\uFFE5]/g, "aa").length;  //先把中文替换成两个字节的英文，在计算长度
   
}

function Export() {
    
    var UserName = $("#UserName").val();
    var StartTime = $("#StartTime").val();
    var EndTime = $("#EndTime").val();
    window.location.href = "/KqStatistics/KqStatistic/KqDetailExport?UserName=" + UserName + "&StartTime=" + StartTime + "&EndTime=" + EndTime;

}