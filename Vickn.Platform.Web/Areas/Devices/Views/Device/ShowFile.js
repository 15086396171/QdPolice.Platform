(function () {
  $(function () {
    var dataDictionaryService = abp.services.app.dataDictionary;

    dataDictionaryService.getDataDictionaryItemsByDicName({
      dicKey: "Forensics.Tag"
    }).done(function (result) {
      $.each(result.items,
        function (index, data) {
          console.log(index, data);
          $("#tag").append(' <li><a href= "javascript:;" class="tag" data-value="' +
            data.value +
            '">' +
            data.displayName +
            '</a></li>');
        })
    });

    var forensicsRecordService = abp.services.app.forensicsRecord;
    var getData = function (filterText, type) {
      var input = {
        type: type,
        "filterText": filterText,
        "maxResultCount": 1000,
        deviceId: $("#deviceId").val()
      };
      forensicsRecordService.getPagedAsync(input).done(function (result) {
        console.log(result);
        $("#files").children().remove();
        if (result.items.length == 0) {
          $("#files").append('<div class="file-box"><div class="file"><a href="javascript:;"><span class="corner"></span><div class="icon"><i class="fa fa-file"></i></div><div class="file-name">没有文件<br /></div></a></div></div>');
        } else {
          $.each(result.items,
            function (index, data) {
              var icon = "fa-music";
              if (data.forensicsRecordType == 2) {
                $("#files").append('<div class="file-box"><div class="file"><a href="javascript:;" class="showFile" data-id="' + data.id + '" data-title="' + data.des + '" data-type="picture" data-src="' + data.src
                  + '"><span class="corner"></span><div class="image"><img alt="image" class="img-responsive" src="' + data.src + '"></div><div class="file-name">' + data.des + '<br /><small>添加时间：' + foramtDate(data.creationTime)
                  + '</small></div></a></div></div>');
              } else {
                if (data.forensicsRecordType == 0) {
                } else if (data.forensicsRecordType == 1) {
                  icon = "fa-film";
                }
                $("#files").append('<div class="file-box"><div class="file"><a href="javascript:;"  class="showFile"  data-id="' + data.id + '"  data-title="' + data.des + '"><span class="corner"></span><div class="icon"><i class="fa ' + icon
                  +'"></i></div><div class="file-name">'+data.des +'<br /><small>添加时间：' +foramtDate(data.creationTime) +'</small></div></a></div></div>');
              }
            });
        }
      });
    }

    $("#tag").on("click",
      ".tag",
      function () {
        getData($(this).data("value"), null);
      });

    $(".file-control").click(function () {
      getData(null, $(this).data("type"));
    });

    $("#files").on("click",
      ".showFile",
      function () {
        var id = $(this).data("id");
        var title = $(this).data("title");
        var datatype = $(this).data("type");
        if (datatype) {
          window.open($(this).data("src"));
        }
        else {
          var index = layer.open({
            title: title,
            type: 2,
            maxmin: true,
            shade: false,
            area: ['50%', '40%'],
            content: abp.appPath +
              "Devices/device/ShowFileDetails/" + id,
          });
        }
      });
    getData();

    function foramtDate(dateStr) {
      return moment(dateStr).format("YYYY-MM-DD HH:mm");
    }
  });
})()