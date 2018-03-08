/*!
 *   Instructor Dormitory Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    $('.date-picker').datepicker({
        autoclose: true,
        todayHighlight: true,
        language: 'zh-CN',
        format: 'yyyy-mm-dd'
    });

    $('#bulletin-table').DataTable({
        "processing": true,//加载效果
        /* 
         * sServerMethod 
         * 数据获取方式 
         * POST/GET，默认是GET 
         */
        "sServerMethod": "POST",
        /* 
         * bDeferRender 
         * 是否启用延迟加载：当你使用AJAX数据源时，可以提升速度。 
         * 默认为false 
         */
        "bDeferRender": true,
        /* 
         * bLengthChange 
         * 是否允许用户，在下拉列表自定义选择分页大小(10, 25, 50 and 100),需要分页支持 
         * 默认为true 
         */
        "bLengthChange": false,
        /* 
         * bFilter 
         * 是否启用内置搜索功能：可以跨列搜索。 
         * 默认为true 
         */
        "bFilter": false,
        /* 
         * bProcessing 
         * 是否显示加载时进度条，默认为false 
         */
        "bProcessing": true,
        /* 
         * iDisplayLength 
         * 默认每页显示多少条记录 
         */
        "iDisplayLength": 15,
        /* 
         * oLanguage 
         * 语言设置，dataTable默认为英文，可再此设置中文显示 
         * 注意：_MENU_、_START_、_END_、_TOTAL_、_MAX_等通配 
         */
        "oLanguage": {
            "sLengthMenu": "每页显示 _MENU_ 条记录",
            "sZeroRecords": "对不起，没有匹配的数据",
            "sInfo": "第 _START_ - _END_ 条 / 共有 _TOTAL_ 条数据",
            "sInfoEmpty": "没有匹配的数据",
            "sInfoFiltered": "(数据表中共 _MAX_ 条记录)",
            "sProcessing": "正在加载中...",
            "sSearch": "全文搜索：",
            "oPaginate": {
                "sFirst": "第一页",
                "sPrevious": " 上一页 ",
                "sNext": " 下一页 ",
                "sLast": " 最后一页 "
            },
        }
    });

    $(document).on('click', '#add', function () {
        window.location.href = '/Administrator/Dormitory/EditBuliding';
    });

    $(document).on('click', '#detail', function () {
        window.location.href = '/Administrator/School/MajorDetail';
    });

    $(document).on('click', '#search', function () {

    });
})