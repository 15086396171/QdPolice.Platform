(function()
{
    $(function () {

        $("#BePbTime").change(function () {
            var bepbTime = $("#BePbTime").val();

          
          
            var index = layer.open({
                title: "请选择被换班人",
                type: 2,
                shadeClose: true,
                area: ['90%', '550px'],
                content: abp.appPath + "ChangeWorks/ChangeWork/GetTimeUser?time=" + bepbTime,
                btn: ['确认'],
                btnAlign: 'l'
                , yes: function (index, layero) {
                    debugger;
              
                    var body = layer.getChildFrame('body', index);
                    var selected = body.find("input[name='check']:checked");
                    var username = $(selected).attr("Remark");

                   
                    $('#ChangeWorkEditDto_BeUserName').val(username);


                    layer.close(index);
                    //按钮【按钮一】的回调
                }
              
                , cancel: function () {
                    //右上角关闭回调

                    //return false 开启该代码可禁止点击该按钮关闭
                }
            });

            layer.full(index);
        });
    });

  
})();