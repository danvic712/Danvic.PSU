/*!
 *   Administrator Home Index Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    InitLineChart();
    InitPieChart();
});

//Line Chart
function InitLineChart() {
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
                data: ['暂无数据']
            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value} 人'
                }
            }
        ]
    };
    lineChart.setOption(line_option);

    var xdatas = [];//x轴
    var ydatas = [];//y轴

    $.ajax({
        type: 'post',
        url: '/Administrator/Home/GetLineChart',
        dataType: 'json',
        success: function (data) {
            if (data.length !== 0) {
                //push data
                for (var i = 0; i < data.length; i++) {
                    xdatas.push(data[i].day);
                    ydatas.push(data[i].count);
                }

                JSON.stringify(xdatas);
                JSON.stringify(ydatas);

                var line_option = {
                    xAxis: [
                        {
                            type: 'category',
                            boundaryGap: false,
                            data: xdatas
                        }
                    ],
                    series: [
                        {
                            type: 'line',
                            data: ydatas,
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
            }
        }
    });
    window.onresize = lineChart.resize;
}

//Pie Chart
function InitPieChart() {
    var pie = echarts.init(document.getElementById('map-pie'), 'macarons');
    var pie_option = {
        title: {
            text: '新生生源地分布',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            left: 'left',
            data: ['暂无数据']
        },
        series: [
            {
                name: '生源地',
                type: 'pie',
                radius: '55%',
                center: ['50%', '60%'],
                data: [
                    { value: 0, name: '暂无数据' }
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

    var datas = [];//数据

    $.ajax({
        type: 'post',
        url: '/Administrator/Home/GetPieChart',
        dataType: 'json',
        success: function (data) {
            if (data.length !== 0) {
                //push data
                for (var i = 0; i < data.length; i++) {
                    datas.push(data[i]);
                }

                JSON.stringify(datas);

                var pie_option = {
                    legend: {
                        orient: 'vertical',
                        left: 'left',
                        data: (function () {
                            var res = [];
                            var len = datas.length;
                            for (var i = 0, size = len; i < size; i++) {
                                res.push(datas[i].province);
                            }
                            return res;
                        })()
                    },
                    series: [
                        {
                            name: '生源地',
                            type: 'pie',
                            radius: '55%',
                            center: ['50%', '60%'],
                            data: (function () {
                                var res = [];
                                var len = datas.length;
                                for (var i = 0, size = len; i < size; i++) {
                                    res.push({
                                        name: datas[i].province,
                                        value: datas[i].count
                                    });
                                }
                                console.log(res);
                                return res;
                            })(),
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
            }
        }
    });
    window.onresize = pie.resize;
}