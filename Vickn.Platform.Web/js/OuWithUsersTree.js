var OuWithUsersTree = function ($) {
  return function () {
    var _nodeclickCallback;
    var $tree;
    var ouService = abp.services.app.organizationUnit;

    var setting = {
      async: {
        enable: false,
        url: "/OrganizationUnits/GetTreeWithUsersData"
      },
      check: {
        enable: true
      },
      data: {
        simpleData: {
          enable: true,
          idKey: "id",
          pIdKey: "parentId",
          rootPId: null
        },
        key: {
          name: "displayName",
          children: "children",
        }
      },
      callback: {
        onCheck: zTreeOnClick,
      }
    };
    function init($treeContainer, nodeclickCallback) {
      $tree = $treeContainer;
      _nodeclickCallback = nodeclickCallback;

      ouService.getAllOuWithUsersAsync().done(function (data) {
        console.log(data);
        $.each(data,
          function(index, ou) {
            getUser(ou);
          });
        $.fn.zTree.init($tree, setting, data);
      })
    }

    function getUser(ou) {
      $.each(ou.children, function(index, child) {
        getUser(child);
      });

      $.each(ou.users,
        function(index, user) {
          ou.children.push({
            displayName: user.name,
            id: user.id,
            parentId: ou.id,
            isUser:true,
          });
        });
    }

    function zTreeOnClick(event, treeId, treeNode) {
      _nodeclickCallback(treeNode);
    };

    return {
      init: init
    }
  }
}(jQuery)