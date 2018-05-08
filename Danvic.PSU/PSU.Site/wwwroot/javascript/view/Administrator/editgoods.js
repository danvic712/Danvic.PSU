/*!
 *   Administrator Admission Goods Edit Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //upload
    new AjaxUpload($('#iconpath'), {
        action: "/Administrator/Admission/Upload",
        onSubmit: function (file, ext) {
            //后缀验证
            if (!(ext && /^(GIF|BMP|PNG|JPG|JPEG)$/.test(ext))) {
                bootbox.alert({
                    message: "请上传指定类型的图片",
                    size: 'small'
                });
                return false;
            }
            //大小验证
            var size = $(this)["0"]._input.files["0"].size;
            if (size > 1 * 1024 * 1024) {
                bootbox.alert({
                    message: "请上传指定大小文件",
                    size: 'small'
                });
                return false;
            }
        },
        onComplete: function (file, data) { //上传完毕后的操作
            data = $.parseJSON(data.replace(/<.*?>/ig, ""));
            var dialog;
            if (data.success) {
                dialog = bootbox.dialog({
                    message: '<p class="text-center">上传成功</p>',
                    size: 'small'
                });
                setTimeout(function () {
                    dialog.modal('hide');
                }, 1000);
                $("#hideUrl").val(data.path);
                $("#pathName").html(file);
                $("#fname").html("图片限制1M以内，仅支持GIF,BMP,PNG,JPG,JPEG图片");
            } else {
                dialog = bootbox.dialog({
                    message: '<p class="text-center">' + data.msg + '</p>',
                    size: 'small'
                });
                setTimeout(function () {
                    dialog.modal('hide');
                }, 1000);
            }
        }
    });

    //save
    $(document).on('click', '#save', function () {

        if ($('#edit_name').val() === '') {
            bootbox.dialog({
                message: '物品名称不能为空'
            });
            return false;
        }

        //build ajax request param
        var param = {};
        param.Id = $(this).attr('data-id');
        param.Name = $('#edit_name').val();
        param.Description = $('#edit_description').val();
        param.Size = $('#edit_size').val();
        param.ImageSrc = $('#edit_hideUrl').val();
        param.IsEnabled = $('#edit_enable').val();

        $(this).attr('disabled', 'disabled');

        $.ajax({
            type: "POST",
            url: "/Administrator/Admission/EditGoods",
            data: param,
            dataType: "json",
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Admission/Goods";
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