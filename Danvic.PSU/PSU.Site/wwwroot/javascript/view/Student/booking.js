/*!
 *   Student Register Booking Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //detail
    $(document).on('click',
        '#service_detail',
        function () {
            $.ajax({
                type: "GET",
                dataType: "html",
                url: '/Student/Register/ServiceInfo',
                data: {
                    id: $(this).attr('data-id')
                },
                success: function (html) {
                    bootbox.dialog({
                        title: '迎新服务详细信息',
                        message: html
                    });
                }
            });
        });

    //add
    $(document).on('click',
        '#book_service',
        function () {
            $.ajax({
                type: "GET",
                dataType: "html",
                url: '/Student/Register/BookingService',
                data: {
                    Id: $(this).attr('data-id'),
                    IsBooking: $(this).attr('data-booking')
                },
                success: function (html) {
                    bootbox.dialog({
                        title: '预定迎新服务',
                        message: html
                    });
                }
            });
        });

    //info
    $(document).on('click',
        '#book_serviceInfo',
        function () {
            $.ajax({
                type: "GET",
                dataType: "html",
                url: '/Student/Register/BookingService',
                data: {
                    id: $(this).attr('data-id'),
                    IsBooking: $(this).attr('data-booking')
                },
                success: function (html) {
                    bootbox.dialog({
                        title: '迎新服务预定详情',
                        message: html
                    });
                }, error: function (msg) {
                    console.log(msg.responseText);
                }
            });
        });

    //save
    $(document).on('click', '#book_save', function () {

        if ($('#book_tel').val() === '') {
            bootbox.dialog({
                message: "请输入联系电话"
            });
            return false;
        }
        if ($('#book_count').val() === '0' || $('#book_count').val() === '') {
            bootbox.dialog({
                message: "请输入人数"
            });
            return false;
        }
        if ($('#book_place').val() === '') {
            bootbox.dialog({
                message: "请输入需要服务地点"
            });
            return false;
        }
        if ($('#book_departuretime').val() === '') {
            bootbox.dialog({
                message: "请输入需要服务时间"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.ServiceId = $('#serviceid').val();
        param.Tel = $('#book_tel').val();
        param.Count = $('#book_count').val();
        param.DepartureTime = $('#book_departuretime').val();
        param.Place = $('#book_place').val();
        param.Remark = $('#book_remark').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Student/Register/BookingService",
            data: param,
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
                $('#book_save').removeAttr('disabled');
            },
            error: function (msg) {
                console.log(msg);
                $('#book_save').removeAttr('disabled');
            }
        });
    });
});