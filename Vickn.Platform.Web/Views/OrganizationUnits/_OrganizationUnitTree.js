var OrganizationUnitTree = (function ($) {
    return function () {
        var _url;

        var $tree;
        var setting = {
            async: {
                enable: true,
                url: "/OrganizationUnits/GetTreeData"
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "Id",
                    pIdKey: "ParentId",
                    rootPId: null
                },
                key: {
                    name: "DisplayName"
                }
            },
            callback: {
                onClick:zTreeOnClick
            }
        };
        function init($treeContainer,url) {
            $tree = $treeContainer;
            _url = url;
            $.fn.zTree.init($tree, setting, null);
        }

        function zTreeOnClick(event, treeId, treeNode) {
            window.location.href = _url + "?parentId=" + treeNode.Id;
        };

        return {
            init: init
        };
    }
})(jQuery);