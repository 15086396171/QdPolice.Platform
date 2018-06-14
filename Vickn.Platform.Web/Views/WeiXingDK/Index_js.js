$(function () {

    var lng = "";
    var lat = "";


    gaodeDingWei();
    getDate();

    //获取当前登陆用户的用户名
    $.get("/Account/KqZSGetUserName",
        function(data) {

            $("#username").html(data);

        });




    $("#btnlogin").click(function () {

        var outgoincausetxt = $("#outgoingcause").val();
        outgoincause = outgoincausetxt.replace(/(^\s*)|(\s*$)/g, "")

        //经纬度
        var JWD = $("#location").attr("Remark");
        var position = $("#location").html() + ",地理位置：(" + JWD + ")";

        if (JWD == "") {
            alert("您当前还没有成功定位");
            return;
        }
        debugger;
        console.log(outgoincause);

        if (outgoincause == "") {

            //outgoincause = "无";

            alert("外出事由不能为空");
            return;

        }




        var username = $("#username").html();

        abp.ajax({
            url: abp.appPath + 'api/services/app/kqDetail/CreateWeiXingAllDetailAsync',
            type: 'POST',
            data: JSON.stringify({
                IsNFC: "0", OutGoingCause: outgoincause, Position: position, UserName: username

            })
        }).fail(function () {
            abp.ui.clearBusy();
        });

        var d = new Date();
        var nowtime = d.getHours() + ":" + d.getMinutes()

        alert("打卡成功(时间:" + nowtime + ")");

        window.location.href = "javascript:WeixinJSBridge.call('closeWindow');";
    });



})



//百度定位
function baiduDingWei() {
    var map = new BMap.Map("allmap");
    var point = new BMap.Point(116.331398, 39.897445);
    map.centerAndZoom(point, 15);
    debugger;
    var geolocation = new BMap.Geolocation();
    geolocation.getCurrentPosition(function (r) {
        if (this.getStatus() == BMAP_STATUS_SUCCESS) {
            var mk = new BMap.Marker(r.point);
            map.addOverlay(mk);
            map.panTo(r.point);



            lng = r.point.lng;
            lat = r.point.lat;
            var geocoder = new BMap.Geocoder();
            geocoder.getLocation(r.point,
                function (result) {
                    abp.ui.clearBusy();


                    $("#location").html(result.formattedAddress);
                    $("#location").attr("Remark", lng + "," + lat);
                });
        }
        else {
            alert('failed' + this.getStatus());
        }
    });

}

//高德定位
function gaodeDingWei() {
    var mapObj = new AMap.Map('iCenter');
    mapObj.plugin('AMap.Geolocation', function () {
        geolocation = new AMap.Geolocation({
            enableHighAccuracy: true, // 是否使用高精度定位，默认:true
            timeout: 10000,           // 超过10秒后停止定位，默认：无穷大
            maximumAge: 0,            // 定位结果缓存0毫秒，默认：0
            convert: true,            // 自动偏移坐标，偏移后的坐标为高德坐标，默认：true
            showButton: true,         // 显示定位按钮，默认：true
            buttonPosition: 'LB',     // 定位按钮停靠位置，默认：'LB'，左下角
            buttonOffset: new AMap.Pixel(10, 20), // 定位按钮与设置的停靠位置的偏移量，默认：Pixel(10, 20)
            showMarker: true,         // 定位成功后在定位到的位置显示点标记，默认：true
            showCircle: true,         // 定位成功后用圆圈表示定位精度范围，默认：true
            panToLocation: true,      // 定位成功后将定位到的位置作为地图中心点，默认：true
            zoomToAccuracy: true       // 定位成功后调整地图视野范围使定位位置及精度范围视野内可见，默认：false
        });
        mapObj.addControl(geolocation);
        geolocation.getCurrentPosition();
        AMap.event.addListener(geolocation, 'complete', onComplete); // 返回定位信息
        AMap.event.addListener(geolocation, 'error', onError);       // 返回定位出错信息
    });
}

function onComplete(obj) {
    var res = '经纬度：' + obj.position +
        '\n精度范围：' + obj.accuracy +
        '米\n定位结果的来源：' + obj.location_type +
        '\n状态信息：' + obj.info +
        '\n地址：' + obj.formattedAddress +
        '\n地址信息：' + JSON.stringify(obj.addressComponent, null, 4);
    //alert(res);
    $("#location").html(obj.formattedAddress);
    $("#location").attr("Remark", obj.position);
}

function onError(obj) {
    alert(obj.info + '--' + obj.message);
    console.log(obj);
}

//获得当前日期
function getDate() {
    var date = new Date();
    var nowdate = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    $("#nowdate").html(nowdate);
}