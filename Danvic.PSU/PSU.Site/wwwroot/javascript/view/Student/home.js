/*!
 *   Administrator Student Home Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    //Editor
    var editor = new Simditor({
        textarea: $('#editor'),
        toolbar: [
            'title', 'bold', 'italic', 'fontScale', 'color', 'ol', 'ul', 'table', 'link', 'hr', 'indent', 'outdent', 'alignment',
        ]
    });
});