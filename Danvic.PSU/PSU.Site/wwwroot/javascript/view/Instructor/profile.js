/*!
 *   Instructor Profile Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //radio
    $('input').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green',
        increaseArea: '20%' /* optional */
    });

    //save
    $(document).on('click', '#save', function () {
        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#name').val();
        param.Address = $('#address').val();
        param.Age = $('#age').val();
        param.QQ = $('#qq').val();
        param.Wechat = $('#wechat').val();
        param.Gender = $('input:radio[name="gender"]:checked').val();
        param.Phone = $('#phone').val();
        param.Email = $("#email").val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Instructor/User/EditProfile",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = window.location.href;
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