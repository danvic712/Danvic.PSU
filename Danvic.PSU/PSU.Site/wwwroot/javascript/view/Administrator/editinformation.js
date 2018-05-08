/*!
 *   Administrator Dormitory Infromation Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //show the associate field value
    $(document).on('change', '#edit_bunk', function () {
        if ($(this).val() !== '-1') {
            $('#edit_count').val($('#edit_bunk').find('option:checked').attr('data_count'));
        } else {
            $('#edit_count').val('0');
        }
    });

    //save
    $(document).on('click', '#save', function () {
        if ($('#edit_name').val().length === 0) {
            bootbox.dialog({
                message: "宿舍号不能为空"
            });
            return false;
        }
        if ($('#edit_building').val() === '-1') {
            bootbox.dialog({
                message: "请选择所属宿舍楼"
            });
            return false;
        }
        if ($('#edit_floor').val() === '0') {
            bootbox.dialog({
                message: "所在楼层不能为0"
            });
            return false;
        }
        if ($('#edit_bunk').val() === '-1') {
            bootbox.dialog({
                message: "请选择宿舍类型"
            });
            return false;
        }
        if ($('#edit_count').val() === '0') {
            bootbox.dialog({
                message: "可容纳人数不能为0"
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#edit_name').val();
        param.BuildingId = $('#edit_building').val();
        param.Floor = $('#edit_floor').val();
        param.BunkId = $('#edit_bunk').val();
        param.Count = $("#edit_count").val();
        param.IsEnabled = $('#enable').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/Dormitory/EditInformation",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Dormitory/Information";
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