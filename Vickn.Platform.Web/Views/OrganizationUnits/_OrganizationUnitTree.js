var OrganizationUnitTree = (function($) {
    return function() {
        var $tree;

        function init($treeContainer) {
            $tree = $treeContainer;
            $tree.jstree({
                "types": {
                    "default": {
                        "icon": "Hui-iconfont Hui-iconfont-file"
                    },
                    "file": {
                        "icon": "Hui-iconfont Hui-iconfont-system"
                    }
                },
                plugins: ['types']
            });

            $tree.on("changed.jstree", function(e, data) {
                if (!data.node) {
                    return;
                }
                window.location.href = "/OrganizationUnits/Index?parentId=" + data.node.id;
            });
        }

        return {
            init: init
        };
    }
})(jQuery);