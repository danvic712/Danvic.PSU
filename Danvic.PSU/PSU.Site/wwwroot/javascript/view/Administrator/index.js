/*!
 *   Instructor Home Index Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //Add New Bulletin
    $(document).on('click', '#add', function () {
        window.location.href = '/Administrator/Home/Edit';
    });

    //Delete Bulletin Inormation
    $(document).on('click', '#delete', function () {
        var id = $(this).attr('data-id');
        bootbox.confirm({
            message: '公告名称：<b class="text-red">' + $(this).attr('data-title') + '</b>，确定删除该条公告吗？',
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
                        url: '/Administrator/Home/Delete',
                        type: 'POST',
                        dataType: 'Json',
                        data: {
                            id: id
                        },
                        success: function (result) {
                            bootbox.alert({
                                message: result.msg,
                                buttons: {
                                    ok: {
                                        label: '确定',
                                        className: 'btn bg-olive btn-flat margin'
                                    }
                                },
                                callback: function () {
                                    window.location = "/Administrator/Home/Index";
                                }
                            });
                        },
                        error: function (msg) {
                            console.log(msg);
                        }
                    });
                }
            }
        })
    });

    //See More Bulletin Information
    $(document).on('click', '#more_bulletin', function () {
        window.location.href = '/Administrator/Home/Bulletin';
    });

    //See More Question Information
    $(document).on('click', '#more_question', function () {
        window.location.href = '/Administrator/Admission/Question';
    });

    //Line Chart
    //
    var lineChart = echarts.init(document.getElementById('register-line-chart'), 'macarons');
    var line_option = {
        tooltip: {
            trigger: 'axis'
        },
        toolbox: {
            show: true,
            feature: {
                mark: { show: true },
                saveAsImage: { show: true },
                magicType: { show: true, type: ['line', 'bar'] },
                restore: { show: true }
            }
        },
        calculable: true,
        xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                data: ['2018-02-26', '2018-02-27', '2018-02-28', '2018-03-01', '2018-03-02', '2018-03-03', '2018-03-04']
            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} 人'
                }
            }
        ],
        series: [
            {
                type: 'line',
                data: [11, 10, 15, 13, 17, 13, 12],
                markPoint: {
                    data: [
                        { type: 'max', name: '最大值' },
                        { type: 'min', name: '最小值' }
                    ]
                },
                markLine: {
                    data: [
                        { type: 'average', name: '平均值' }
                    ]
                }
            }
        ]
    };
    lineChart.setOption(line_option);

    //Set Question List Height 
    $('#chat-box').slimScroll({
        height: '303px'
    });

    //Pie Chart
    //
    var pie = echarts.init(document.getElementById('map-pie'), 'macarons');
    var pie_option = {
        title: {
            text: '2014级新生生源地分布',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            left: 'left',
            data: ['安徽', '江苏', '浙江', '山东', '湖南']
        },
        series: [
            {
                name: '访问来源',
                type: 'pie',
                radius: '55%',
                center: ['50%', '60%'],
                data: [
                    { value: 335, name: '山东' },
                    { value: 310, name: '江苏' },
                    { value: 234, name: '浙江' },
                    { value: 135, name: '湖南' },
                    { value: 1548, name: '安徽' }
                ],
                itemStyle: {
                    emphasis: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
    };
    pie.setOption(pie_option);
})