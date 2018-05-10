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
});