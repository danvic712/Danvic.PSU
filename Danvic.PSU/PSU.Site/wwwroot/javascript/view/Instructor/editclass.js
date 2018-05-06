/*!
 *   Instructor Edit Class Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //save
    $(document).on('click', '#save', function () {
        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Wechat = $('#wechat').val();
        param.QQ = $('#qq').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Instructor/User/EditClass",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Instructor/User/Classes";
                        }, 2000);
                    }
                }
                $('#save').removeAttr('disabled');
            },
            error: function (msg) {
                console.log(msg);
                $('#save').removeAttr('disabled');
            }
        });
    });
})