/*!
 *   Administrator Department Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //Edit
    var editor = new Simditor({
        textarea: $('#editor')
    });

    //Submit button
    $(document).on('click', '#save', function () {
        if ($('#name').length === 0) {
            bootbox.alert('院系名称不能为空');
            return;
        } else if ($('#name').length > 20) {
            bootbox.alert('院系名称不能超过20个字符');
            return;
        }

        if ($('#tel').length === 0) {
            bootbox.alert('联系电话不能为空');
            return;
        } else if ($('#tel').length > 20) {
            bootbox.alert('联系电话不能超过20个字符');
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
                if (result.msg !== undefined) {
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

})