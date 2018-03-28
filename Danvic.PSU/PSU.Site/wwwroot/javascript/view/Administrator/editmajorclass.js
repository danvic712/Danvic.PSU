/*!
 *   Administrator MajorClass Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //validate
    $("#majorclass_form").validate({
        submitHandler: function (form) {
            Submit();
        }
    });

    //show the associate field value
    $(document).on('change', '#department', function () {
        if ($(this).val() !== '-1') {
            $('#deptnumber').val($(this).val());
        } else {
            $('#deptnumber').val('');
        }
    });

    $(document).on('change', '#instructor', function () {
        if ($(this).val() !== '-1') {
            $('#insnumber').val($(this).val());
        } else {
            $('#insnumber').val('');
        }
    });

    //save
    $(document).on('click', '#save', function () {


    });

    function Submit() {
        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#name').val();
        param.MajorCode = $('#code').val();
        param.MajorName = $('#major').val();
        param.DepartmentId = $('#deptnumber').val();
        param.DepartmentName = $("#department option:selected").text();
        param.Wechat = $('#wechat').val();
        param.QQ = $('#qq').val();
        param.InstructorId = $('#insnumber').val();
        param.InstructorName = $("#instructor option:selected").text();
        param.SessionNum = $('#session').val();
        param.IsEnabled = $('#enable').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/School/EditMajorClass",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg,
                        closeButton: false,
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/School/MajorClass";
                        }, 2000);
                    } else {
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
    }

})