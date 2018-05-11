/*!
 *   Login Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    $('input').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green',
        increaseArea: '20%' /* optional */
    });

    if ($.cookie("Jixia_UserName") != undefined) {
        $("#RememberMe").prop("checked", "checked");

        $("#UserName").val($.cookie("Jixia_UserName"));
        $("#Password").val($.cookie("Jixia_Password"));
    }
    else {
        $("#RememberMe").removeProp("checked");
    }

    $(document).on('submit', '#loginform', function () {
        if ($("#RememberMe:checked").length > 0) {
            $.cookie("Jixia_UserName", $("#Account").val());
            $.cookie("Jixia_Password", $("#Password").val());
        } else {
            $.removeCookie("Jixia_UserName");
            $.removeCookie("Jixia_Password");
        }
    });

    if ($("#errorInfo").val()) {
        layer.tips($("#errorInfo").val(), "#btnLogin", {
            tips: [2, '#78BA32']
        });
    };
});