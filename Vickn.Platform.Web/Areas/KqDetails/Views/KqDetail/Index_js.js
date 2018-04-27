




    $(function () {


        var $dataTable = $(".dataTable");
        var _kqdetailsService = abp.services.app.kqdetail;

      

        var options = {
            listAction: {
                url: abp.appPath + "api/services/app/kqdetail/getPagedAsync",

                filters: [
                    {
                        key: "UserName",
                        selector: $("#UserName")
                    },
                    {
                        key:  "StartTime",
                        selector: $("#StartTime")
                    },
                    {
                        key: "EndTime",
                        selector: $("#EndTime")
                    },
                ],
                ingore: []
            },

            fileds: [
               
                { "data": "userName" },
                {
                    "data": "qdTime",
                    render: function (data, type, row, meta) {
                      
                        if (data)
                            return moment(data).format("YYYY-MM-DD HH:mm:ss");
                        else return "";
                    }
                },
                {
                    "data": "isNFC",
                    render: function (data, type, row, meta) {
                        if (data == "0") return "微信打卡";
                        else if (data == "1") return "NFC打卡";
                        else return "门禁刷卡";
                    }
                },
                { "data": "qdPostion" }


              
            ]
           
           
        };
        $dataTable.createDatatable(options);

        // TODO: 页面其他处理

    });


