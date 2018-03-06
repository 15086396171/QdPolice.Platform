﻿(function () {
    $(function () {
        if (window.top !== window.self) { window.top.location = window.location; }

        $('#LoginButton').click(function (e) {
          e.preventDefault();
          if (!$("#vCode").val()) {
            abp.message.warn("验证码不能为空");
            return;
          }
            abp.ui.setBusy();
            abp.ajax({
                url: abp.appPath + 'Account/Login',
                type: 'POST',
                data: JSON.stringify({
                    tenancyName: $('#TenancyName').val(),
                    usernameOrEmailAddress: $('#EmailAddressInput').val(),
                    password: $('#PasswordInput').val(),
                    rememberMe: $('#RememberMeInput').is(':checked'),
                    returnUrlHash: $('#ReturnUrlHash').val()
                })
            }).fail(function() {
                abp.ui.clearBusy();
            });
        });

        $('a.social-login-link').click(function () {
            var $a = $(this);
            var $form = $a.closest('form');
            $form.find('input[name=provider]').val($a.attr('data-provider'));
            $form.submit();
        });

        $('#ReturnUrlHash').val(location.hash);

        $('#LoginForm input:first-child').focus();
    });

})();