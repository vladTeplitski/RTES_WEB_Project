$(document).ready(function() {   //after page loads

    //info dropdown
    $(".drop1").on("click", function () {
        $(".EmrgPhones").fadeIn();
    });
    $(".CloseEmrgPhones").on("click", function () {
        $(".EmrgPhones").hide();
    });
    $(".drop2").on("click", function () {
        $(".ContactRtes").fadeIn();
    });
    $(".CloseContactRtes").on("click", function () {
        $(".ContactRtes").hide();
    });
    $(".drop3").on("click", function () {
        $(".AboutRTES").fadeIn();
    });
    $(".CloseAboutRTES").on("click", function () {
        $(".AboutRTES").hide();
    });
    $(".reportLabelHeadClose").on("click", function () {
        $(".opRepLabelJs").hide();
    });

});




$(function () {
    $.ajaxComplete(function () {
        $("[data-toggle='tooltip']").tooltip();
    });
});



