(function(){
  "use strict";

  angular
    .module("CharacterSheetApp")
    .controller("SignUpController", SignUpController);

  //Injected Dependencies
  SignUpController.$inject = ["$scope", "$state", "$mdToast"];

  //Controller
  function SignUpController($scope, $state, $mdToast){
    
  }
})();
