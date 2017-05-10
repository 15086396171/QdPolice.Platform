var OrganizationUnitTree = (function ($) {
    return function () {
        var _nodeclickCallback;

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
                onClick: zTreeOnClick
            }
        };
        function init($treeContainer, nodeclickCallback) {
            $tree = $treeContainer;
            _nodeclickCallback = nodeclickCallback;
            $.fn.zTree.init($tree, setting, null);
        }

        function zTreeOnClick(event, treeId, treeNode) {
            _nodeclickCallback(treeNode);
        };

        return {
            init: init
        };
    }
})(jQuery);