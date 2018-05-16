$(function () {


    $("#btnlogin").click(function() {


        var username = $("#username").val();
        var password = $("#password").val();

        if (username == "" && password == "") {
            alert("用户名和密码不能为空！");
            return;
        }
        if (username == "") {
            alert("用户名不能为空！");
            return;
        }

        if (password == "") {
            alert("密码不能为空！");
            return;
        }


        abp.ajax({
            url: abp.appPath + 'Account/Login',
            type: 'POST',
            data: JSON.stringify({
                tenancyName: "Kq",
                usernameOrEmailAddress: username,
                password: password,


            })
        }).fail(function() {
            abp.ui.clearBusy();
        });
    });


})