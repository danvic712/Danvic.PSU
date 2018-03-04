/*!
 *   Administrator Login Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
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

    var barChart = echarts.init(document.getElementById('most-bar-chart'), 'macarons');
    var bar_option = {
        tooltip: {
            trigger: 'item'
        },
        toolbox: {
            show: true,
            feature: {
                saveAsImage: { show: true },
                restore: { show: true }
            }
        },
        calculable: true,
        grid: {
            borderWidth: 0,
            y: 80,
            y2: 60
        },
        xAxis: [
            {
                type: 'category',
                show: false,
                data: ['芜湖市', '合肥市', '鹰潭市', '南京市', '马鞍山市', '成都市']
            }
        ],
        yAxis: [
            {
                type: 'value',
                show: false
            }
        ],
        series: [
            {
                name: '用户登录地点',
                type: 'bar',
                itemStyle: {
                    normal: {
                        color: function (params) {
                            var colorList = [
                                '#C1232B', '#B5C334', '#FCCE10', '#E87C25', '#27727B',
                                '#FE8463', '#9BCA63', '#FAD860', '#F3A43B', '#60C0DD',
                                '#D7504B', '#C6E579', '#F4E001', '#F0805A', '#26C0C0'
                            ];
                            return colorList[params.dataIndex]
                        },
                        label: {
                            show: true,
                            position: 'top',
                            formatter: '{b}\n{c}'
                        }
                    }
                },
                data: [12, 21, 10, 4, 12, 5],
                markPoint: {
                    tooltip: {
                        trigger: 'item',
                        backgroundColor: 'rgba(0,0,0,0)',
                        formatter: function (params) {
                            return '<img src="'
                                + params.data.symbol.replace('image://', '')
                                + '"/>';
                        }
                    },
                    data: [
                        { xAxis: 0, y: 350, name: '芜湖市' },
                        { xAxis: 1, y: 350, name: '合肥市' },
                        { xAxis: 2, y: 350, name: '鹰潭市' },
                        { xAxis: 3, y: 350, name: '南京市' },
                        { xAxis: 4, y: 350, name: '马鞍山市' },
                        { xAxis: 5, y: 350, name: '成都市' },
                    ]
                }
            }
        ]
    };
    barChart.setOption(bar_option);

    var dash = echarts.init(document.getElementById('dash-board'), 'macarons');
    var dash_option = {
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            left: 'left',
            data: ['06:00-12:00', '12:01-18:00', '18:01-05:59']
        },
        series: [
            {
                name: '时间区间',
                type: 'pie',
                radius: ['55%', '75%'],
                avoidLabelOverlap: false,
                label: {
                    normal: {
                        show: false,
                        position: 'center'
                    },
                    emphasis: {
                        show: true,
                        textStyle: {
                            fontSize: '20',
                            fontWeight: 'bold'
                        }
                    }
                },
                labelLine: {
                    normal: {
                        show: false
                    }
                },
                data: [
                    { value: 335, name: '06:00-12:00' },
                    { value: 310, name: '12:01-18:00' },
                    { value: 234, name: '18:01-05:59' }
                ]
            }
        ]
    };
    dash.setOption(dash_option);

    var pie = echarts.init(document.getElementById('browser-pie'), 'macarons');
    var pie_option = {
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        series: [
            {
                name: '访问来源',
                type: 'pie',
                radius: '55%',
                center: ['50%', '40%'],
                data: [
                    { value: 335, name: 'Chrome' },
                    { value: 310, name: 'UC Web' },
                    { value: 234, name: 'Firefox' },
                    { value: 135, name: '360' },
                    { value: 1548, name: 'IE' }
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