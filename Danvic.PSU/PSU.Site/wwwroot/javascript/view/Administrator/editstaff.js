/*!
 *   Administrator Edit Staff Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //radio
    $('input').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green',
        increaseArea: '20%' /* optional */
    });

    //show the associate field value
    $(document).on('change', '#department', function () {
        if ($(this).val() !== '-1') {
            $('#deptnumber').val($(this).val());
        } else {
            $('#deptnumber').val('');
        }
    });

    //check account
    $(document).on('blur', '#account', function () {
        if ($(this).val() !== '') {
            $.ajax({
                type: "POST",
                url: "/Administrator/Basic/CheckAccount",
                data: {
                    account: $(this).val()
                },
                dataType: "json",
                success: function (result) {
                    if (result.success) {
                        bootbox.dialog({
                            message: result.msg
                        });
                    }
                }
            });
        }
    });

    //save
    $(document).on('click', '#save', function () {
        if ($('#account').val().length === 0) {
            bootbox.dialog({
                message: "登录账户名不能为空"
            });
            return false;
        }
        if ($('#password').val().length === 0) {
            bootbox.dialog({
                message: "登录密码不能为空"
            });
            return false;
        }
        if ($('#name').val().length === 0) {
            bootbox.dialog({
                message: "用户姓名不能为空"
            });
            return false;
        }
        if ($('#idnumber').val().length === 0) {
            bootbox.dialog({
                message: "身份证号不能为空"
            });
            return false;
        }
        if ($('#department').val() === '-1') {
            bootbox.dialog({
                message: "请选择所属院系信息"
            });
            return false;
        }
        if ($('#deptnumber').val().length === 0) {
            bootbox.dialog({
                message: "院系编号不能为空"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#name').val();
        param.Account = $('#account').val();
        param.Email = $('#email').val();
        param.DepartmentId = $('#deptnumber').val();
        param.Phone = $("#phone").val();
        param.Wechat = $('#wechat').val();
        param.QQ = $('#qq').val();
        param.Password = $('#password').val();
        param.Gender = $('input:radio[name="gender"]:checked').val();
        param.Age = $('#age').val();
        param.IdNumber = $('#idnumber').val();
        param.IsMaster = $('input:radio[name="master"]:checked').val();
        param.Address = $('#address').val();
        param.IsEnabled = $('#enable').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/Basic/EditStaff",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Basic/Staff";
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
});