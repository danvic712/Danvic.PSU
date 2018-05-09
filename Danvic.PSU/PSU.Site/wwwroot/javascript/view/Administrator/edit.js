/*!
 *   Administrator Bulletin Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */

$(function () {
    //Editor
    var editor = new Simditor({
        textarea: $('#editor'),
        toolbar: [
            'title', 'bold', 'italic', 'fontScale', 'color', 'ol', 'ul', 'table', 'link', 'hr', 'indent', 'outdent', 'alignment',
        ]
    });

    //Submit button
    $(document).on('click', '#save', function () {

        if ($('#title').val().length === 0) {
            bootbox.dialog({
                message: "公告标题不能为空"
            });
            return false;
        }
        if ($('#target').val() === '0') {
            bootbox.dialog({
                message: "请选择针对用户"
            });
            return false;
        }
        if ($('#type').val() === '0') {
            bootbox.dialog({
                message: "请选择公告类型"
            });
            return false;
        }
        if ($('#editor').val().length === 0) {
            bootbox.dialog({
                message: "公告内容不能为空"
            });
            return false;
        } else if ($('#editor').val().length > 1000) {
            bootbox.dialog({
                message: "公告内容不能超过1000个字符"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Title = $('#title').val();
        param.Target = $('#target').val();
        param.Type = $('#type').val();
        param.Content = $('#editor').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/Home/Edit",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Home/Bulletin";
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