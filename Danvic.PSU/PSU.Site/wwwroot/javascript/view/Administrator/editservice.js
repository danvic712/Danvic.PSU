/*!
 *   Administrator Admission Service Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //datetime
    $('.date-picker').datetimepicker({
        autoclose: true,
        todayHighlight: true,
        language: "zh-CN",
        weekStart: 1,
        format: 'yyyy-mm-dd hh:ii'
    });

    //save
    $(document).on('click', '#save', function () {
        if ($('#name').val().length === 0) {
            bootbox.dialog({
                message: "服务名称不能为空"
            });
            return false;
        }

        if ($('#starttime').val() === '') {
            bootbox.dialog({
                message: "请选择服务开始时间"
            });
            return false;
        }

        if ($('#endtime').val() === '') {
            bootbox.dialog({
                message: "请选择服务结束时间"
            });
            return false;
        }

        if ($('#starttime').val() >= $('#endtime').val()) {
            bootbox.dialog({
                message: "开始时间不能大于等于结束时间"
            });
            return false;
        }

        if ($('#address').val() === '-1') {
            bootbox.dialog({
                message: "请选择服务地点"
            });
            return false;
        }

        if ($('#address_custom').val() === '') {
            bootbox.dialog({
                message: "请输入服务详细地点"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#name').val();
        param.Description = $('#description').val();
        param.StartTime = $('#starttime').val();
        param.EndTime = $('#endtime').val();
        param.Place = $("#address").val();
        param.Address = $("#address_custom").val();
        param.IsEnabled = $('#enable').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/Admission/EditService",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Admission/Service";
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