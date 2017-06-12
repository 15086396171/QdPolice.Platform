$('form').validate({
    rules: {
        PasswordRepeat: {
            equalTo: "#Password",
        }
    },

    submitHandler: function (form) {
        form.submit();
    }
});
if (window.top !== window.self) { window.top.location = window.location; }
