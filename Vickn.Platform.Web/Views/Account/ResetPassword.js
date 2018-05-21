$('form').validate({
    rules: {
        PasswordRepeat: {
            equalTo: "#Password",
        }
    },

    submitHandler: function (form) {


        var password = $("#Password").val();
        var str = password;
        var regUpper = /[A-Z]/;
        var regLower = /[a-z]/;
        var regStr = /[^A-Za-z0-9]/;
        var complex = 0;
        if (regLower.test(str)) {
            ++complex;
        }
        if (regUpper.test(str)) {
            ++complex;
        }
        if (regStr.test(str)) {
            ++complex;
        }
        if (complex < 3 || str.length < 8) {
            var data="密码必须包含大小写字母，数字,特殊字符,长度至少8位";
            layer.msg('' + data + '', {
                skin: 'layui-layer-molv' //样式类名  自定义样式
                , closeBtn: 1    // 是否显示关闭按钮
                , anim: 1 //动画类型

                , time: 10000 //2s后自动关闭
                , icon: 6    // icon

            });
            return;
        } else {

            form.submit();
        }
   

    }
});
if (window.top !== window.self) { window.top.location = window.location; }

