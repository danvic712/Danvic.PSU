/*!
 *   Administrator Bulletin Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    $('.date-picker').datepicker({
        autoclose: true,
        todayHighlight: true,
        language: 'zh-CN',
        format: 'yyyy-mm-dd'
    });

    var editor = new Simditor({
        textarea: $('#detail'),
        toolbar: [
            'title', 'bold', 'italic', 'fontScale', 'color', 'ol', 'ul', 'table', 'link', 'hr', 'indent', 'outdent', 'alignment',
        ]
    });
})