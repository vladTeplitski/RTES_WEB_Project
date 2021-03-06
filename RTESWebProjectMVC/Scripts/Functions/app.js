﻿var myApp = angular.module('myApp', []);

myApp.directive('tooltip', function () {  //tool-tip directive

    return {
        restrict: 'A', //We want our directive to be attribute directive

        scope: {
            toolinfo: '@',   // the tooltip text
            toolstyle: '@'    //for custom css style
        },

        controller:
            function ($scope, $element) { //controller to the tool tip directive which would control the visibility of the tool tip
                $scope.isShown = false;
                this.showHover = function () {
                    $scope.isShown = $scope.isShown == true ? false : true;
                }
                this.hideHover = function () {
                    $scope.isShown = $scope.isShown == true ? false : true;
                }
            },

        transclude: true, //transclude option prevents the directive from replacing the existing items

        link:
            function (scope, element, attr, ctrl) {
                element.bind('mouseenter', function () {
                    scope.$apply(function () {
                        ctrl.showHover();
                    });

                });
                element.bind('mouseleave', function () {
                    scope.$apply(function () {
                        ctrl.hideHover();
                    });
                });
            },
        //template to the tool tip directive
        template: '<div ng-transclude></div>' +
                  '<div ng-show="isShown">' +
                  '<div class="{{toolstyle}}">' +   //use style chosen by user
                  '<span>' +
                  '{{toolinfo}}' +   //bind with the text added to the directive
                  '</span>' +
                  '</div>' +
                  '</div>' +
                  '</div>'
    }
});


//end custom angular tooltip directive

myApp.controller('mainController', ['$scope', function ($scope) {

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
        $scope.loginText = "Please enter your user name!";
    };

    $scope.loginPass = function () {
        $scope.notValidPass = true;
        $scope.validPass = true;
        if ($scope.lgPass.length >= 5) {
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

    //Settings

    //settings buttons

    $scope.op1 = true;
    $scope.op2 = true;
    $scope.op3 = true;

    $scope.toggleOptions = function (op) {
        if (op == 1) {
            $scope.op1 = !$scope.op1;
        }
        else if (op == 2) {
            $scope.op2 = !$scope.op2;
        }
        else if (op == 3) {
            $scope.op3 = !$scope.op3;
        }

    };

    //end settings


    //social icons
    $scope.socialFunc = function (x) {
        if (x == 1) {
            window.location = "https://www.linkedin.com/";
        }
        else if (x == 2) {
            window.location = "https://twitter.com/";
        }
        else if (x == 3) {
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

}]);


myApp.controller('clientController', ['$scope', function ($scope) {


    $scope.hideClientRepInfo = function () {
        $scope.clientRepCont = true;
    }



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



}]);


//operator controller
myApp.controller('operatorController',['$scope',function ($scope) {

    $scope.onlyLetters = /^[a-zA-Z]+$/;
    $scope.onlyNumbers = /^[0-9]*$/;

    $scope.oper0 = false;
    $scope.oper1 = true;
    $scope.oper2 = true;
    $scope.oper3 = true;
    
    $scope.btnPanel = false;
    $scope.btnPanel2 = true;
    
    $scope.operatorClick = function (btn) {
        if (btn == 1) {
            $scope.oper0 = true;
            $scope.oper1 = false;  
            $scope.oper2 = true;
            $scope.oper3 = true;

            $scope.btnPanel2 = true;
            $scope.btnPanel = false;  //show main btn panel
            
            
        }
        else if (btn == 2) {
            $scope.oper0 = true;
            $scope.oper1 = true;
            $scope.oper2 = false;
            $scope.oper3 = true;

            $scope.btnPanel2 = true;
            $scope.btnPanel = false; //show main btn panel
            
            
        }
        else if (btn == 3) {
            $scope.oper0 = true;
            $scope.oper1 = true;
            $scope.oper2 = true;
            $scope.oper3 = false;

            $scope.btnPanel = true;
            $scope.btnPanel2 = false; //show secondary - operations room btn panel
            
        }
    }

}]);


//Emergency form controller
myApp.controller('emergFormController', ['$scope', function ($scope) {


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

    $scope.onlyLetters = /^[a-zA-Z]+$/;
    $scope.onlyNumbers = /^[0-9]*$/;


    //shai-20.04.2017

    //call for towing button
    $scope.callTowingFunc = function () {
        $scope.callTowingSucceed = !$scope.callTowingSucceed;
    }
    // end call for towing button

    //Upload documents button
    $scope.showUploadDocWindow = function () {
        $scope.UploadDocuments = !$scope.UploadDocuments;
    }
    $scope.closeView = function () {
        $scope.UploadDocuments = false;
    }
    //End Upload documents button

    //Upload Images button
    $scope.showUploadImageWindow = function () {
        $scope.UploadImages = !$scope.UploadImages;
    }

  

	  //shai-05.05.2017
    $scope.ViewImagesUpload = function () {
        $scope.UploadImages = !$scope.UploadImages;
    }
    //End Upload Images button


    $scope.delete1 = function () {
        angular.element(document.getElementById('fileInput1')).val(null);
        //    angular.element(document.getElementById('fileInput1').val('').clone(true));
    };
	
	

    //angular.element(document.getElementById('remove')).on('click', function () {
    //angular.element(document.getElementById('fileInput1')).val('');
    //});

    //$scope.clear = function () {

    // angular.element(document.getElementById('fileInput1')).val('');
    // }

    //End shai-20.04.2017

}]);


//truck driver app controller

myApp.controller('truckDriverController', ['$scope', function ($scope) {


    $scope.truck0 = false;
    $scope.truck1 = true;

    $scope.truckDriverClick = function (btn) {
        if (btn == 1) {
            $scope.truck0 = true;
            $scope.truck1 = false;

        }
    }

}]);




//Appraiser app controller

myApp.controller('appraiserController', ['$scope', function ($scope) {


    // $scope.inputCounter = 0;


    // $scope.description1 = false;
    //s $scope.description2 = false;
    //$scope.description3 = false;

    $scope.showDescription1 = function () {
        $scope.description1 = !$scope.description1;
    }


    $scope.showDescription2 = function () {
        $scope.description2 = !$scope.description2;
    }

    $scope.showDescription3 = function () {
        $scope.description3 = !$scope.description3;
    }
    $scope.showDescription4 = function () {
        $scope.description4 = !$scope.description4;
    }
    $scope.showDescription5 = function () {
        $scope.description5 = !$scope.description5;
    }
    $scope.onlyLetters = /^[a-zA-Z]+$/;
    $scope.onlyNumbers = /^[0-9]*$/;

    //$scope.add = function () {
    // $scope.inputTemplate = {
    // id: 'subject-' + $scope.inputCounter,
    // name: ''
    //  };
    // if ($scope.inputCounter < 5) {
    //   $scope.description2 = true;
    //   $scope.description3 = true;
    //}
    // $scope.inputCounter += 1;
    // $scope.inputs.push($scope.inputTemplate);
    //};

}]);