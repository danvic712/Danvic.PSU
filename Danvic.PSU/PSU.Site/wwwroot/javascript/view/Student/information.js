/*!
 *   Student Register Information Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    changesTab();

    //datetime
    $('.date-picker').datepicker({
        autoclose: true,
        todayHighlight: true,
        language: 'zh-CN',
        format: 'yyyy-mm-dd'
    });

    $('#next').click(function () {
        nextTo();
    });

    //save
    $(document).on('click', '#save', function () {

        if ($('#way').val() === '-1') {
            bootbox.dialog({
                message: "请选择来校方式"
            });
            return false;
        }
        if ($('#place').val() === '') {
            bootbox.dialog({
                message: "请输入到达地点"
            });
            return false;
        }
        if ($('#arrivetime').val() === '') {
            bootbox.dialog({
                message: "请输入预计到达日期"
            });
            return false;
        }
        if ($('#express').val() === '-1') {
            bootbox.dialog({
                message: "请选择档案是否快递寄送"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Way = $('#way').val();
        param.Place = $('#place').val();
        param.ArriveTime = $('#arrivetime').val();
        param.IsExpress = $('#express').val();
        param.ExpressId = $('#expressid').val();
        param.Remark = $('#remark').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Student/Register/SignUp",
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
                            nextTo();
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

//Tab change
function changesTab() {
    $("#chose_booking").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#booking').load('/Student/Register/Booking');

    $("#chose_goods").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#goods').load('/Student/Register/Goods');

    $("#chose_dormitory").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#dormitory').load('/Student/Register/Dormitory');
}

function nextTo() {
    $('#chose_booking').tab('show');
    $('#booking').load('/Student/Register/Booking');
}