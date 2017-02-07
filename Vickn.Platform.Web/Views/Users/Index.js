(function() {
    $(function() {

        var _userService = abp.services.app.user;
        $('.a-disable').click(function () {
            var id = $(this).data('id');
            _userService.disableUser({ id: id }).done(function () {
                location.reload();
            });
        });
    });
})();