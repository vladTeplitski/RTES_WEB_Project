var myApp = angular.module("myApp", []);


//main controller
myApp.controller('mainController', function ($scope) {
        
    //Text from json

    //HomePage
    $scope.welcomeText = HomePage[0].text;
    $scope.theServiceText = HomePage[1].text;
    $scope.registrationText = HomePage[2].text;
    $scope.emergencyText = HomePage[3].text;
    $scope.appraisingText = HomePage[4].text;
    $scope.towingText = HomePage[5].text;

    //bottom
    $scope.bottomText = bottom[0].bottomText;

    //END Text from json

        //Main nav functions
        $(".resetApp,.aboutBtn").on("click", function () {
            $(".textContainer").hide();
            $(".chapter1").fadeIn();
        });
        //end main nav functions

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
    //Main nav functions
    $(".resetApp,.aboutBtn").on("click", function () {
        $(".textContainer").hide();
        $(".chapter1").fadeIn();
    });
    //end main nav functions

    //Client functions:
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

    $scope.myPersonalDetails = function () {
        $scope.personal = !$scope.personal;
    }

    //settings
    $(".changePswdJS").on("click", function () {
        $(".subchangePswdJS").toggle();
    });
    $(".changeEmailJS").on("click", function () {
        $(".subchangeEmailJS").toggle();
    });
    $(".changePhoneJS").on("click", function () {
        $(".subchangePhoneJS").toggle();
    });

});


//Emergency form controller
myApp.controller('emergFormController', function ($scope) {

    //Main nav functions
    $(".resetApp,.aboutBtn").on("click", function () {
        $(".textContainer").hide();
        $(".chapter1").fadeIn();
    });
    //end main nav functions

    $scope.myPersonalDetails = function () {
        $scope.personal = !$scope.personal;
    }

    $scope.thirdPartyDetails = function () {

        $scope.driverDetailsBut = !$scope.driverDetailsBut;
        $scope.carDetailsBut = !$scope.carDetailsBut;
        $scope.insuranceDetailsBut = !$scope.insuranceDetailsBut;
        if ($scope.driverDetailsBut == false) { $scope.showMe = false; }
        if ($scope.carDetailsBut == false) { $scope.myValue = false; }
        if ($scope.insuranceDetailsBut == false) { $scope.myValue1 = false; }
    }

    $scope.myFunc = function () {
        $scope.showMe = !$scope.showMe;
    }
    $scope.myFunc1 = function () {
        $scope.myValue = !$scope.myValue;
    }
    $scope.myFunc2 = function () {
        $scope.myValue1 = !$scope.myValue1;
    }

});

    //operator controller
myApp.controller('operatorController', function ($scope) {
    //Main nav functions
    $(".resetApp,.aboutBtn").on("click", function () {
        $(".textContainer").hide();
        $(".chapter1").fadeIn();
    });
    //end main nav functions

    //operator functions:


});