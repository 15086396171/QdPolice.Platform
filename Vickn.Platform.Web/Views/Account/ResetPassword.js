$('.pass-reset-form').validate({
    rules: {
        PasswordRepeat: {
            equalTo: "#Password"
        }
    },

    submitHandler: function (form) {
        form.submit();
    }
});
