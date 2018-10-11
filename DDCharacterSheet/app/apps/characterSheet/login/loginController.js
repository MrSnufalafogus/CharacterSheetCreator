(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("LoginController", LoginController);

    //Injected Dependencies
    LoginController.$inject = ["$scope", "$state", "$mdToast", "accessTokenService", "authenticationHelper"];

    // Controller
    function LoginController($scope, $state, $mdToast, accessTokenService, authenticationHelper){
      //Declaring fields
      var logicC = this;

      logicC.LoginInfo = {
        Username: "",
        Password: ""
      };

      logicC.Update = update;

      return logicC;

      function update(value){
        console.log(value);
      }

        function login(userName, passWord, isLongTerm) {
            accessTokenService.accessTokensLogin(userName, passWord, isLongTerm).then(function (response) {
                authenticationHelper.setAccessToken(response.data);
                $state.go("characterSheet.characters");
            }, function (response) {
                //Do Nothing
            });
        }
    }


})();
