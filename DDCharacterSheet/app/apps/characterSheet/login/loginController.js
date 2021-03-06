﻿(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("LoginController", LoginController);

    //Injected Dependencies
    LoginController.$inject = ["$scope", "$state", "$mdToast", "accessTokenService", "authenticationHelper"];

    // Controller
    function LoginController($scope, $state, $mdToast, accessTokenService, authenticationHelper) {
        //Declaring fields
        var logicC = this;

        //Login object
        logicC.LoginInfo = {
            Username: "",
            Password: ""
        };

        //Function callbacks
        logicC.Login = login;
        logicC.SignUp = signUp;

        //Returning logic
        return logicC;

        //Login function
        function login(userName, passWord, isLongTerm){
            accessTokenService.accessTokensLogin(userName, passWord, isLongTerm).then(function (response) {
                authenticationHelper.setAccessToken(response.data);
                $state.go("characterSheet.characters");
            }, function (response) {
                //Do Nothing
            });
        }

        //signUp Function
        function signUp(){
          //Redirecting to sign up page
          $state.go("signUp");
        }
    }
})();
