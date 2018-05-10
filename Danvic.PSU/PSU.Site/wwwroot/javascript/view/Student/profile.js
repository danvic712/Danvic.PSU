/*!
 *   Student Profile Page JavaScript v1.0.0
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

    //save
    $(document).on('click', '#save', function () {
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

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
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
        param.StartDate = $('#startdate').val();
        param.EndDate = $('#enddate').val();
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
            url: "/Student/User/EditProfile",
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
});