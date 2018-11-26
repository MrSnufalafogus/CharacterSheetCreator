(function(){
  "use strict";

  angular
    .module("CharacterSheetApp")
    .controller("SignUpController", SignUpController);

  //Injected Dependencies
  SignUpController.$inject = ["$scope", "$state", "$mdToast"];

  //Controller
  function SignUpController($scope, $state, $mdToast){
    //Declaring fields
    var logicC = this;

    //Function callbacks
    logicC.Update = update;
    logicC.Back = back;

    //Returning logic
    return logicC;

    //Update function
    function update(value){
      console.log(value);
    }

    //Back function
    function back(){
      //Returning to login page
      $state.go("login");
    }
  }
})();
