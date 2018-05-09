/*!
 *   Instructor Reply Question Page JavaScript v1.0.0
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

    //save
    $(document).on('click', '#save', function () {
        if ($('#editor').val() === '') {
            bootbox.dialog({
                message: '回复信息为空'
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.ReplyContent = $('#editor').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Instructor/Question/Reply",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Instructor/Question/Information";
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