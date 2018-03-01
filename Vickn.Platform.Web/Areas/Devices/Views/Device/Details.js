(function () {
  $(function () {
    var _deviceService = abp.services.app.device;
    $(".manage").click(function () {

      var isOnline = $("#isOnline").data("online");
      if (isOnline === "False") {
        abp.message.error("设备不在线，不能发送命令");
        return;
      }
      var id = $(this).data("id");
      var operation = $(this).data("operation");
      _deviceService.manageAsync({
        id: id,
        operation: operation
      }).done(function () {
        abp.notify.success("命令发送成功");
      });
    });
  });
})()