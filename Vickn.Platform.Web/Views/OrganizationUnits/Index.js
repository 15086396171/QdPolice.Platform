(function () {
    $(function () {
        var _tree = new OrganizationUnitTree();
        _tree.init($(".organizationUnit"),"/OrganizationUnits/Index");
    });
})();