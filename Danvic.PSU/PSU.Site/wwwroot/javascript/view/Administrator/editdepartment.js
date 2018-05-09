/*!
 *   Administrator Department Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //Edit
    var editor = new Simditor({
        textarea: $('#editor'),
        toolbar: [
            'title', 'bold', 'italic', 'fontScale', 'color', 'ol', 'ul', 'table', 'link', 'hr', 'indent', 'outdent', 'alignment',
        ]
    });

    //Submit button
    $(document).on('click', '#save', function () {
        if ($('#name').val().length === 0) {
            bootbox.dialog({
                message: "部门/院系名称不能为空"
            });
            return false;
        }
        if ($('#tel').val().length === 0) {
            bootbox.dialog({
                message: "联系电话不能为空"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#name').val();
        param.Address = $('#address').val();
        param.Tel = $('#tel').val();
        param.Email = $('#email').val();
        param.Weibo = $('#weibo').val();
        param.Wechat = $('#wechat').val();
        param.QQ = $('#qq').val();
        param.Introduction = $('#editor').val();
        param.IsEnabled = $('#enable').val();
        param.IsBranch = $('#branch').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/School/EditDepartment",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/School/Department";
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