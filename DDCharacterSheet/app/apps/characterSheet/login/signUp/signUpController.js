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

    //Sign-Up object
    logicC.SignUpInfo = {
      Username: "",
      Email: "",
      Password: "",
      PasswordConfirm: ""
    };

    //Function callbacks
    logicC.SignUp = signUp;
    logicC.Back = back;

    //Returning logic
    return logicC;

    //SignUp function
    function signUp(){
      //Declaring fields
      let info = logicC.SignUpInfo;

      //Checking for errors
      let errResult = errorCheck(info);
      if(errResult.err == true){
        //Displaying error message
        alert(errResult.message);
      }else{
        /**USE DATA*/
      }
    }

    //Back function
    function back(){
      //Returning to login page
      $state.go("login");
    }

    //ErrorCheck function
    function errorCheck(input){
      //Declaring fields
      let errObj = {
        err: true,
        message: ""
      };

      //Checking for empty fields
      if(input.Username == ""){
        //Setting error message
        errObj.message = "Username cannot be empty!";
      }else if(input.Email == ""){
        //Setting error message
        errObj.message = "Email cannot be empty!";
      }else if(input.Password == ""){
        //Setting error message
        errObj.message = "Password cannot be empty!";
      }else if(input.PasswordConfirm == ""){
        //Setting error message
        errObj.message = "Confirm Password cannot be empty!";
      }else if(input.Password != input.PasswordConfirm){
        //Setting error message
        errObj.message = "Passwords do not match!";
      }else{
        //No errors found
        errObj.err = false;
      }

      //Returning error object
      return errObj;
    }
  }
})();
