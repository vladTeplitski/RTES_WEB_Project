$(document).ready(function() {   //after page loads


    //controlling the textContainers on main page
    $(".resetApp,.aboutBtn").on("click", function () {
        $(".textContainer").hide();
        $(".chapter1").show();
        $(".chapter1").delay(slow);
    });
    $(".btn1").on("click", function () {
        $(".textContainer").hide();
        $(".chapter2").show();
        $(".chapter2").delay(slow);
    });
    $(".btn2").on("click", function () {
        $(".textContainer").hide();
        $(".chapter3").show();
    });
    $(".btn3").on("click", function () {
        $(".textContainer").hide();
        $(".chapter4").show();
    });
    $(".btn4").on("click", function () {
        $(".textContainer").hide();
        $(".chapter5").show();
    });
    $(".btn5").on("click", function () {
        $(".textContainer").hide();
        $(".chapter6").show();
    });


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

