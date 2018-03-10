/*!
 *   Administrator Bulletin Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    var editor = new Simditor({
        textarea: $('#editor')
    });

    $(document).on('click', '#save', function () {
        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Title = $('#title').val();
        param.Target = $('#target').val();
        param.Type = $('#type').val();
        param.Content = $('#editor').val();

        $.ajax({
            type: "POST",
            url: "/Administrator/Home/Edit",
            data: param,
            dataType: "json",
            success: function (result) {
                bootbox.dialog({
                    message: result.msg,
                    closeButton: false,
                });
                setTimeout(function () {
                    window.location = "/Administrator/Home/Bulletin";
                }, 2000);
            },
            error: function (msg) {
                console.log(msg);
            }
        });
    });
});