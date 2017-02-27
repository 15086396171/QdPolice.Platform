(function () {
    $(function () {
        var _tree;
        $(".organizationUnit").load('/OrganizationUnits/OrganizationUnitTree', function () {

            _tree = new OrganizationUnitTree();
            _tree.init($(".organizationUnit-tree"));
        });
    });
})();