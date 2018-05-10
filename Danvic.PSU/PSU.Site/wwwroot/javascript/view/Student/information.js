/*!
 *   Student Register Information Page JavaScript v1.0.0
 *   Author: Danvic712
 */
$(function () {
    changesTab();
});

//Tab change
function changesTab() {
    $("#chose_information").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#information').load('/Student/Register/Register');

    $("#chose_booking").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#booking').load('/Student/Register/Booking');

    $("#chose_goods").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#goods').load('/Student/Register/Goods');

    $("#chose_dormitory").click(function (e) {
        $(this).tab('show');
        e.preventDefault(); //阻止a标签的默认行为
    });
    $('#dormitory').load('/Student/Register/Dormitory');
}