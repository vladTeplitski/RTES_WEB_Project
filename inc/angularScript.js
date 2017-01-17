//use ng-click="$event.preventDefault();"  into html tags where routing is not needed

var myApp = angular.module("myApp", ["ngRoute"]);


myApp.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "HomePage.html",
        controller: 'mainController'
    })

    .when("/root", {
        templateUrl: "HomePage.html",
        controller: 'mainController'
    })

    .when("/clientPage", {
        templateUrl: "ClientPage.html",
        controller: 'clientController'        
    })
    .when("/emergForm", {
            templateUrl: "emergForm.html",
            controller: 'clientController'
    })
});


//main controller
myApp.controller('mainController', function ($scope) {

        //Main functions
        $(".resetApp,.aboutBtn").on("click", function () {
            $(".textContainer").hide();
            $(".chapter1").fadeIn();
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
        //Home page functions
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



});


//client controller
myApp.controller('clientController', function ($scope) {

    //Main functions
    $(".resetApp,.aboutBtn").on("click", function () {
        $(".textContainer").hide();
        $(".chapter1").fadeIn();
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

    //Home page functions  (The part of client functions)
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

});