/*!
 *   Student Register Dormitory Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //save
    $(document).on('click', '#book_dormitory', function () {
        var id = $(this).attr('data-id');
        bootbox.confirm({
            buttons: {
                confirm: {
                    label: '确认',
                    className: 'btn-success'
                },
                cancel: {
                    label: '取消',
                    className: 'btn-default'
                }
            },
            message: '寝室信息选择后不可更改，确定选择当前寝室？',
            callback: function (result) {
                if (result) {
                    $.ajax({
                        type: "POST",
                        url: "/Student/Register/BookingDormitory",
                        data: {
                            id: id
                        },
                        dataType: "json",
                        success: function (result) {
                            if (result.msg !== undefined) {
                                bootbox.dialog({
                                    message: result.msg
                                });
                                if (result.success) {
                                    setTimeout(function () {
                                        bootbox.hideAll();
                                        window.location.href = window.location.href;
                                    }, 2000);
                                }
                            }
                            $('#book_dormitory').removeAttr('disabled');
                        },
                        error: function (msg) {
                            console.log(msg);
                            $('#book_dormitory').removeAttr('disabled');
                        }
                    });
                }
            }, 
        }); 
    });
});