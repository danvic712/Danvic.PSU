/*!
 *   Administrator Building Page JavaScript v1.0.0
 *   Author: Danvic712
 */

//table
$.dataTableSetting = {
    "bSort": false,//关闭排序
    "serverSide": true,//服务器端加载数据
    "sServerMethod": "POST",//数据获取方式 
    "bDeferRender": true,//是否启用延迟加载
    "sScrollXInner": "100%",//表格宽度 
    "bLengthChange": false,//是否允许用户自定义分页大小
    "bFilter": false,//是否启用内置搜索功能
    "bStateSave": true,//cookies保存当前状态
    "bProcessing": true,//是否显示加载进度条
    "iDisplayLength": 15,//默认每页显示多少条记录
    "deferRender": true,
    "oLanguage": {
        "sLengthMenu": "每页显示 _MENU_ 条记录",
        "sZeroRecords": "对不起，没有匹配的数据",
        "sInfo": "第 _START_ - _END_ 条 / 共 _TOTAL_ 条数据",
        "sInfoEmpty": "没有匹配的数据",
        "sInfoFiltered": "(数据表中共 _MAX_ 条记录)",
        "sProcessing": "正在加载中...",
        "sSearch": "全文搜索：",
        "oPaginate": {
            "sFirst": "第一页",
            "sPrevious": " 上一页 ",
            "sNext": " 下一页 ",
            "sLast": " 最后一页 "
        }
    },
    "paging": true,
    "processing": true,
    "columnDefs": [
        {
            "targets": 7,
            "data": null,
            "render": function (data, type, row) {
                var html = '<a id="edit" class="btn btn-xs btn-link" data-id=' + data.id + ' data-name='
                    + data.name + ' data-floor=' + data.floor + ' data-type=' + data.typeStr
                    + ' data-enable=' + data.isEnabledStr + '>编辑</a>' +
                    '<a id="delete" class="btn btn-xs btn-link" data-id=' + data.id + '>删除</a>';
                return html;
            }
        }
    ],
    "columns": [
        { "data": "id" },
        { "data": "name" },
        { "data": "floor" },
        { "data": "typeStr" },
        { "data": "createdName" },
        { "data": "dateTime" },
        { "data": "isEnabledStr" }
    ],

    ajax: function (data, callback, settings) {
        var param = {};
        param.Limit = data.length;//页面显示记录条数，在页面显示每页显示多少项的时候
        param.Start = data.start;//开始的记录序号
        param.Page = data.start / data.length + 1;//当前页码
        param.SId = $("#code").val();//院系编号
        param.SType = $("#type").val();//院系名称
        param.SEnable = $("#enable").val();//院系联系方式

        //ajax请求数据
        $.ajax({
            type: "POST",
            url: "/Administrator/Dormitory/SearchBuilding",
            cache: false,  //禁用缓存
            data: {
                search: JSON.stringify(param)
            },  //传入组装的参数
            dataType: "json",
            success: function (result) {
                //console.log(result);
                var returnData = {};
                returnData.draw = data.draw;//这里直接自行返回了draw计数器,应该由后台返回
                returnData.recordsTotal = result.total;//返回数据全部记录
                returnData.recordsFiltered = result.total;//后台不实现过滤功能，每次查询均视作全部结果
                returnData.data = result.data;//返回的数据列表
                //console.log(returnData);
                //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染
                //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕
                callback(returnData);
            },
            error: function (msg) {
                console.log(msg.responseText);
            }
        });
    }
};
$(function () {
    var dataTable = $("#building-table").dataTable($.dataTableSetting);

    //add
    $(document).on("click", "#add", function () {

        //verification
        if ($('#edit_name').val() === '') {
            bootbox.dialog({
                message: '请输入寝室楼名称'
            });
            return false;
        }

        if ($('#edit_floor').val() === '') {
            bootbox.dialog({
                message: '请输入寝室楼总楼层'
            });
            return false;
        }

        if ($('#edit_type').val() === '0') {
            bootbox.dialog({
                message: '请选择寝室楼类型'
            });
            return false;
        }

        var param = {};
        param.Id = $('#edit_id').val();
        param.Name = $('#edit_name').val();
        param.Floor = $('#edit_floor').val();
        param.Type = $('#edit_type').val();
        param.IsEnabled = $('#edit_enable').val();

        $.ajax({
            url: '/Administrator/Dormitory/EditBuilding',
            type: 'POST',
            dataType: 'Json',
            data: param,
            success: function (result) {
                if (result.msg !== undefined) {
                    bootbox.dialog({
                        message: result.msg,
                        //closeButton: false,
                    });
                    if (result.success) {
                        setTimeout(function () {
                            window.location.href = "/Administrator/Dormitory/Building";
                        }, 2000);
                    }
                }
            },
            error: function (msg) {
                console.log(msg);
            }
        });
    });

    //search
    $(document).on("click", "#search", function () {
        dataTable.fnDestroy(false);
        dataTable = $("#building-table").dataTable($.dataTableSetting);
    });

    //edit
    $(document).on("click", "#edit", function () {
        $('#edit_id').val($(this).attr("data-id"));
        $('#edit_name').val($(this).attr("data-name"));
        $('#edit_floor').val($(this).attr("data-floor"));
        $("#edit_type option:contains(" + $(this).attr('data-type') + ")").prop('selected', true);
        $("#edit_enable option:contains(" + $(this).attr('data-enable') + ")").prop('selected', true);

        $('#myModal').modal();
    });

    //delete
    $(document).on("click", "#delete", function () {
        var id = $(this).attr("data-id");
        window.bootbox.confirm({
            message: '宿舍楼编号：<b class="text-red">' + id + '</b>，确定删除该宿舍楼数据吗？',
            buttons: {
                confirm: {
                    label: '确定',
                    className: 'btn btn-success btn-flat'
                },
                cancel: {
                    label: '取消',
                    className: 'btn btn-default btn-flat'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: '/Administrator/Dormitory/DeleteBuilding',
                        type: 'POST',
                        dataType: 'Json',
                        data: {
                            id: id
                        },
                        success: function (result) {
                            window.bootbox.alert({
                                message: result.msg,
                                buttons: {
                                    ok: {
                                        label: '确定',
                                        className: 'btn bg-olive btn-flat margin'
                                    }
                                },
                                callback: function () {
                                    window.location = "/Administrator/Dormitory/Building";
                                }
                            });
                        },
                        error: function (msg) {
                            console.log(msg);
                        }
                    });
                }
            }
        });
    });
});