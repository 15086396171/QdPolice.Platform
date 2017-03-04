var OrganizationUnitTree = (function ($) {
    return function () {
        var _url;
        var _search;

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
        function init($treeContainer,url,search) {
            $tree = $treeContainer;
            _url = url;
            _search = search;
            $.fn.zTree.init($tree, setting, null);
        }

        function zTreeOnClick(event, treeId, treeNode) {
            _search(treeNode.Id);
        };

        return {
            init: init
        };
    }
})(jQuery);