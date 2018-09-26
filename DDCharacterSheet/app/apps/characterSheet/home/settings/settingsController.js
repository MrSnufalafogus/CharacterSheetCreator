(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("SettingsController", SettingsController);

    //Injected Dependencies
    SettingsController.$inject = ["$scope", "$state", "$mdToast"];

    // Controller
    function SettingsController($scope, $state, $mdToast) {
        /* jshint validthis:true */

        var settingsC = this;

        return settingsC;
    }

})();