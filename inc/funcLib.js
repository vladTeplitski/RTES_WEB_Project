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


});