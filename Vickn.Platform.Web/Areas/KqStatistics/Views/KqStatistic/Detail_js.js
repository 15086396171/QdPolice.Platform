﻿


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
            { "data": "outgoingCauseWork" },
            { "data": "qdPostionWork" },
            { "data": "dateColsing" },
            { "data": "outgoingCauseClosing" },
            { "data": "qdPostionClosing" },
            { "data": "qdType" }


        ]

    }

    $dataTable.createDatatable(option);
});