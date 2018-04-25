$(function () {
   
    $("#btnlogin").click(function () {


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

      
       
        $.post("/WeiXingDK/IsLoginSucces", { username: username, password: password }, function (data) {

            
        })
    })
   

    //action = "~/Views/WeiXingDK/Login.cshtml"

})