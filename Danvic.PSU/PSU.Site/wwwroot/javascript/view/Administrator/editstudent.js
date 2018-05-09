/*!
 *   Administrator Edit Student Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //radio
    $('input').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green',
        increaseArea: '20%' /* optional */
    });

    //datetime
    $('.date-picker').datepicker({
        autoclose: true,
        todayHighlight: true,
        language: 'zh-CN',
        format: 'yyyy-mm-dd'
    });

    //show the associate field value
    $(document).on('change', '#department', function () {
        if ($(this).val() !== '-1') {
            $('#deptnumber').val($(this).val());
        } else {
            $('#deptnumber').val('');
        }
    });
    $(document).on('change', '#majorclass', function () {
        if ($(this).val() !== '-1') {
            $('#classnumber').val($(this).val());
        } else {
            $('#classnumber').val('');
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
        if ($('#deptnumber').val().length === 0 || $('#deptnumber').val() === '0') {
            bootbox.dialog({
                message: "所属院系编号无效"
            });
            return false;
        }
        if ($('#majorclass').val() === '-1') {
            bootbox.dialog({
                message: "请选择专业班级信息"
            });
            return false;
        }
        if ($('#classnumber').val().length === 0 || $('#classnumber').val() === '0') {
            bootbox.dialog({
                message: "专业班级编号无效"
            });
            return false;
        }
        if ($('#starttime').val() === '') {
            bootbox.dialog({
                message: "请选择入学年月"
            });
            return false;
        }
        if ($('#endtime').val() === '') {
            bootbox.dialog({
                message: "请选择毕业年月"
            });
            return false;
        }
        if ($('#starttime').val() >= $('#endtime').val()) {
            bootbox.dialog({
                message: "入学年月不能大于等于毕业年月"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Account = $('#account').val();
        param.Password = $('#password').val();
        param.Email = $('#email').val();
        param.Phone = $("#phone").val();
        param.Name = $('#name').val();
        param.Gender = $('input:radio[name="gender"]:checked').val();
        param.Age = $('#age').val();
        param.Wechat = $('#wechat').val();
        param.QQ = $('#qq').val();
        param.TicketId = $('#ticketid').val();
        param.IdNumber = $('#idnumber').val();
        param.Birthday = $('#birthday').val();
        param.HighSchool = $('#highschool').val();
        param.DepartmentId = $('#department').val();
        param.MajorClassId = $('#majorclass').val();
        param.StartDate = $('#startdate').val();
        param.EndDate = $('#enddate').val();
        param.IsEnabled = $('#enable').val();
        param.ProvinceId = $("#province").find("option:selected").attr("data-code");
        param.Province = $('#province').val();
        param.CityId = $("#city").find("option:selected").attr("data-code");;
        param.City = $('#city').val();
        param.DistrictId = $("#distinct").find("option:selected").attr("data-code");;
        param.District = $('#distinct').val();
        param.Address = $('#address').val();
        param.Hobbies = $('#hobbies').val();
        param.Winning = $('#winning').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/Basic/EditStudent",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Basic/Student";
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