/*!
 *   Instructor Home Index Page JavaScript v1.0.0
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