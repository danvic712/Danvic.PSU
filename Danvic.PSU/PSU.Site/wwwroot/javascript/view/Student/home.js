/*!
 *   Administrator Student Home Page JavaScript v1.0.0
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

    //save
    $(document).on('click', '#save', function () {
        if ($('#editor').val() === '') {
            bootbox.dialog({
                message: '提问信息为空'
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Content = $('#editor').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Student/Home/Ask",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Student";
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