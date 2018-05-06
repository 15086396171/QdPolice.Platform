function showMenu() {
    //页面层
    layer.open({
        type: 1,
        title: "选择用户",
        skin: 'layui-layer-rim', //加上边框
        shade: 0,
        area: ['420px', '400px'], //宽高
        content: $("#menuContent"),
        btn: ["确定"],
        yes: function (index) {
            layer.close(index);
        }
    });
}





$(document).ready(function () {



    $("#btnKeep").click(function () {
        var selectUser = $("#names").val();
        if (selectUser == "") {

            layer.alert('班次对应用户不能为空', {
                skin: 'layui-layer-lan'
                , closeBtn: 0
                , anim: 4 //动画类型
            });


        }
        else {
            $("form").submit();
        }
    })

    var selectedUsers = [];
    var selectedUserNames = [];


    var ouTree = new OuWithUsersTree();

    ouTree.init($(".organizationUnit"), function (node) {
        console.log(node)
        getChildrenUsers(node);

        $("#names").val(selectedUserNames.join(','));
        $("#users").children().remove();
        $.each(selectedUsers, function (index, data) {
            $("#users").append('<input name="KqShiftEditDto.KqShiftUsers[' +
                index +
                '].Id" type="hidden" value="">');
            $("#users").append('<input name="KqShiftEditDto.KqShiftUsers[' +
                index +
                '].UserId" type="hidden" value="' +
                data +
                '">');
            $("#users").append('<input name="KqShiftEditDto.KqShiftUsers[' +
                index +
                '].KqShiftId" type="hidden" value="' +
                $("#KqShiftEditDto_Id").val() +
                '">');
        })
    })

    function getChildrenUsers(node) {
        console.log(node.isUser, node.displayName);
        if (node.isUser) {
            if (node.checked === true) {
                selectedUsers.push(node.id);
                selectedUserNames.push(node.displayName);
            } else {
                selectedUsers.splice($.inArray(node.id, selectedUsers), 1);
                selectedUserNames.splice($.inArray(node.displayName, selectedUserNames), 1);
            }
        }
        $.each(node.children,
            function (index, child) {
                getChildrenUsers(child);
            });
    }
})



