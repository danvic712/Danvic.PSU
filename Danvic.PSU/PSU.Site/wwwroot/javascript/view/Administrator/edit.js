/*!
 *   Administrator Bulletin Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */

$(function () {
    //Editor
    var editor = new Simditor({
        textarea: $('#editor')
    });

    //Submit button
    $(document).on('click', '#save', function () {

        if ($('#title').val().length === 0) {
            bootbox.alert("公告标题不能为空");
            return;
        } else if ($('#title').val().length > 20) {
            bootbox.alert("公告标题不能超过20个字符");
            return;
        }
        if ($('#target').val() === '0') {
            bootbox.alert("请选择针对用户");
            return;
        }
        if ($('#type').val() === '0') {
            bootbox.alert("请选择公告类型");
            return;
        }
        if ($('#editor').val().length === 0) {
            bootbox.alert("请输入公告内容");
            return;
        } else if ($('#editor').val().length > 1000) {
            bootbox.alert("公告内容不能超过1000个字符");
            return;
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
                if (result.msg != undefined) {
                    bootbox.dialog({
                        message: result.msg,
                        closeButton: false,  
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