﻿var PermissionsTree = (function ($) {
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
                        "icon": "Hui-iconfont Hui-iconfont-weigouxuan2"
                    }
                },
                'checkbox': {
                    keep_selected_style: false,
                    three_state: false,
                    cascade: ''
                },
                plugins: ['checkbox', 'types']
            });

            $tree.on("changed.jstree", function (e, data) {
                if (!data.node) {
                    return;
                }

                var childrenNodes;

                if (data.node.state.selected) {
                    selectNodeAndAllParents($tree.jstree('get_parent', data.node));

                    childrenNodes = $.makeArray($tree.jstree('get_children_dom', data.node));
                    $tree.jstree('select_node', childrenNodes);

                } else {
                    childrenNodes = $.makeArray($tree.jstree('get_children_dom', data.node));
                    $tree.jstree('deselect_node', childrenNodes);
                }
            });
        };

        function selectNodeAndAllParents(node) {
            $tree.jstree('select_node', node, true);
            var parent = $tree.jstree('get_parent', node);
            if (parent) {
                selectNodeAndAllParents(parent);
            }
        };

        function getSelectedPermissionNames() {
            var permissionNames = [];

            var selectedPermissions = $tree.jstree('get_selected', true);
            for (var i = 0; i < selectedPermissions.length; i++) {
                permissionNames.push(selectedPermissions[i].id);
            }

            return permissionNames;
        };

        return {
            init: init,
            getSelectedPermissionNames: getSelectedPermissionNames
        }
    }
})(jQuery);