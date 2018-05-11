/*!
 *   Student Register Goods Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //detail
    $(document).on('click',
        '#goods_detail',
        function () {
            $.ajax({
                type: "GET",
                dataType: "html",
                url: '/Student/Register/GoodsInfo',
                data: {
                    id: $(this).attr('data-id')
                },
                success: function (html) {
                    bootbox.dialog({
                        title: '物品详细信息',
                        message: html
                    });
                }
            });
        });

    //add
    $(document).on('click',
        '#book_goods',
        function () {
            $.ajax({
                type: "GET",
                dataType: "html",
                url: '/Student/Register/BookingGoods',
                data: {
                    Id: $(this).attr('data-id'),
                    IsChosen: $(this).attr('data-booking')
                },
                success: function (html) {
                    bootbox.dialog({
                        title: '选择物品',
                        message: html
                    });
                }
            });
        });

    //info
    $(document).on('click',
        '#book_goodsInfo',
        function () {
            $.ajax({
                type: "GET",
                dataType: "html",
                url: '/Student/Register/BookingGoods',
                data: {
                    Id: $(this).attr('data-id'),
                    IsChosen: $(this).attr('data-booking')
                },
                success: function (html) {
                    bootbox.dialog({
                        title: '物品选择详情',
                        message: html
                    });
                }, error: function (msg) {
                    console.log(msg.responseText);
                }
            });
        });

    //save
    $(document).on('click', '#goods_save', function () {

        if ($('#goods_size').val() === '') {
            bootbox.dialog({
                message: "请输入物品尺寸"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.GoodsId = $('#goodsid').val();
        param.Size = $('#goods_size').val();
        param.Remark = $('#goods_remark').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Student/Register/BookingGoods",
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
                $('#goods_save').removeAttr('disabled');
            },
            error: function (msg) {
                console.log(msg);
                $('#goods_save').removeAttr('disabled');
            }
        });
    });
});