var myApp = angular.module("myApp", []);


//main controller
myApp.controller('mainController', function ($scope) {


    //login

    $scope.loginText = "Please Enter your user-name and password, provided by the insurance company.";
    $scope.validUser = true;
    $scope.validPass = true;
    $scope.notValidPass = true;
    $scope.notValidUser = true  // for future use

    $scope.loginField = function () {
        $scope.validUser = false;
        $scope.notValidUser = true;
    };
    $scope.loginFieldclick = function () {
        $scope.loginText = "User name must contain only letters!";
    };
    $scope.loginPass = function () {
        $scope.notValidPass = true;
        if ($scope.lgPass.length >= 5)
        {
            $scope.validPass = false;
            $scope.notValidPass = true;
        }
        else {
            $scope.validPass = true;
            $scope.notValidPass = false;
        }
    };

    $scope.loginPassclick = function () {
        $scope.loginText = "Minimal password length is 5 digits.";
    }; 
    $scope.loginFieldleave = function () {
        $scope.loginText = "Please Enter your user-name and password, provided by the insurance company.";
    };

    

        
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

    //social icons
    $scope.socialFunc = function (x) {
        if (x == 1) {
            window.location = "https://www.linkedin.com/";
        }
        else if(x==2)
        {
            window.location = "https://twitter.com/";
        }
        else if(x==3)
        {
            window.location = "https://www.facebook.com/";
        }
    };


       //home page buttons

        $scope.home0 = false;
        $scope.home1 = true;
        $scope.home2 = true;
        $scope.home3 = true;
        $scope.home4 = true;
        $scope.home5 = true;


        $scope.buttonsClick = function (btn) {
            if (btn == 0) {
                $scope.home0 = false;
                $scope.home1 = true;
                $scope.home2 = true;
                $scope.home3 = true;
                $scope.home4 = true;
                $scope.home5 = true;
            }
            else if (btn == 1) {
                $scope.home0 = true;
                $scope.home1 = false;
                $scope.home2 = true;
                $scope.home3 = true;
                $scope.home4 = true;
                $scope.home5 = true;
            }
            else if (btn == 2) {
                $scope.home0 = true;
                $scope.home1 = true;
                $scope.home2 = false;
                $scope.home3 = true;
                $scope.home4 = true;
                $scope.home5 = true;
            }
            else if (btn == 3) {
                $scope.home0 = true;
                $scope.home1 = true;
                $scope.home2 = true;
                $scope.home3 = false;
                $scope.home4 = true;
                $scope.home5 = true;
            }
            else if (btn == 4) {
                $scope.home0 = true;
                $scope.home1 = true;
                $scope.home2 = true;
                $scope.home3 = true;
                $scope.home4 = false;
                $scope.home5 = true;
            }
            else if (btn == 5) {
                $scope.home0 = true;
                $scope.home1 = true;
                $scope.home2 = true;
                $scope.home3 = true;
                $scope.home4 = true;
                $scope.home5 = false;
            }
        }

    
});


//client controller
myApp.controller('clientController', function ($scope) {

    
    //client page main buttons

    $scope.client0 = false;
    $scope.client1 = true;
    $scope.client2 = true;
    $scope.client3 = true;
    $scope.client4 = true;


    $scope.buttonsClick = function (btn) {
        if (btn == 1) {
            $scope.client0 = true;
            $scope.client1 = false;
            $scope.client2 = true;
            $scope.client3 = true;
            $scope.client4 = true;
        }
        else if (btn == 2) {
            $scope.client0 = true;
            $scope.client1 = true;
            $scope.client2 = false;
            $scope.client3 = true;
            $scope.client4 = true;

        }
        else if (btn == 3) {
            $scope.client0 = true;
            $scope.client1 = true;
            $scope.client2 = true;
            $scope.client3 = false;
            $scope.client4 = true;
        }
        else if (btn == 4) {
            $scope.client0 = true;
            $scope.client1 = true;
            $scope.client2 = true;
            $scope.client3 = true;
            $scope.client4 = false;
        }
    }




    $scope.myPersonalDetails = function () {
        $scope.personal = !$scope.personal;
    }

    //settings buttons

    $scope.op1 = true;
    $scope.op2 = true;
    $scope.op3 = true;

    $scope.toggleOptions = function (op) {
        if (op == 1){
            $scope.op1 = !$scope.op1;
        }
        else if (op == 2){
            $scope.op2 = !$scope.op2;
        }
        else if (op == 3) {
            $scope.op3 = !$scope.op3;
        }
        
    };

});


//Emergency form controller
myApp.controller('emergFormController', function ($scope, $filter ) {

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

    $scope.oper0 = false;
    $scope.oper1 = true;
    $scope.oper2 = true;
    $scope.oper3 = true;


    $scope.operatorClick = function (btn) {
        if (btn == 1) {
            $scope.oper0 = true;
            $scope.oper1 = false;
            $scope.oper2 = true;
            $scope.oper3 = true;
        }
        else if (btn == 2) {
            $scope.oper0 = true;
            $scope.oper1 = true;
            $scope.oper2 = false;
            $scope.oper3 = true;
        }
        else if (btn == 3) {
            $scope.oper0 = true;
            $scope.oper1 = true;
            $scope.oper2 = true;
            $scope.oper3 = false;
        }
    }

});