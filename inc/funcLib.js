$(document).ready(function() {   //after page loads


    //controlling the textContainers on main page
    $(".resetApp,.aboutBtn").on("click", function () {
        $(".textContainer").hide();
        $(".chapter1").fadeIn();
    });
    $(".btn1").on("click", function () {
        $(".textContainer").hide();
        $(".chapter2").fadeIn();
    });
    $(".btn2").on("click", function () {
        $(".textContainer").hide();
        $(".chapter3").fadeIn();
    });
    $(".btn3").on("click", function () {
        $(".textContainer").hide();
        $(".chapter4").fadeIn();
    });
    $(".btn4").on("click", function () {
        $(".textContainer").hide();
        $(".chapter5").fadeIn();
    });
    $(".btn5").on("click", function () {
        $(".textContainer").hide();
        $(".chapter6").fadeIn();
    });
    $(".logjs").on("click", function () {
        $(".loginBox").toggle();
    });
    $(".closeLoginContainer").on("click", function () {
        $(".loginBox").hide();
    });
    $(".regjs").on("click", function () {
        $(".registerBox").toggle();
    });
    $(".closeRegContainer").on("click", function () {
        $(".registerBox").hide();
    });


});