/*!
 *   Administrator Statistics Book Page JavaScript v1.0.0
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
                var html = '<a id="detail" class="btn btn-xs btn-link" data-id=' + data.id + '>查看</a>';
                return html;
            }
        }
    ],
    "columns": [
        { "data": "name" },
        { "data": "tel" },
        { "data": "countStr" },
        { "data": "scheduledTime" },
        { "data": "serviceName" },
        { "data": "departureTime" },
        { "data": "isCancelStr" }
    ],

    ajax: function (data, callback, settings) {
        var param = {};
        param.Limit = data.length;//页面显示记录条数，在页面显示每页显示多少项的时候
        param.Start = data.start;//开始的记录序号
        param.Page = (data.start / data.length) + 1;//当前页码
        param.SName = $('#servicename').val();//迎新服务名称
        param.SStudent = $('#name').val();//迎新服务地点
        param.SDate = $('#datetime').val();//服务时间

        //ajax请求数据
        $.ajax({
            type: "POST",
            url: "/Administrator/Statistics/SearchService",
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
    //datetime
    $('.date-picker').datepicker({
        autoclose: true,
        todayHighlight: true,
        language: 'zh-CN',
        format: 'yyyy-mm-dd'
    });

    var dataTable = $('#book-table').dataTable($.dataTableSetting);

    //radio
    $('input').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green',
        increaseArea: '20%' /* optional */
    });

    //search
    $(document).on('click', '#search', function () {
        dataTable.fnDestroy(false);
        dataTable = $('#book-table').dataTable($.dataTableSetting);
    });

    //detail
    $(document).on('click', '#detail', function () {
        var id = $(this).attr('data-id');
        $.ajax({
            type: "GET",
            dataType: "html",
            url: '/Administrator/Statistics/BookInfo',
            data: {
                id: id
            },
            success: function (html) {
                window.bootbox.dialog({
                    title: '预定信息详情',
                    message: html
                });
            }
        });
    });
});