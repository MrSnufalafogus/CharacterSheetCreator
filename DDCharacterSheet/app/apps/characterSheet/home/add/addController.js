(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("AddController", AddController)
        .filter('percentage', ['$filter', function ($filter) {
            return function (input, decimals) {
                return $filter('number')(input, decimals) + '%';
            };
        }]);

    //Injected Dependencies
    AddController.$inject = ["$scope", "$state", "$mdToast", "$mdMedia", "characterCreateHelper"];

    // Controller
    function AddController($scope, $state, $mdToast, $mdMedia, characterCreateHelper) {
        /* jshint validthis:true */

        var addC = this;

        addC.CharacterName = "Character";

        var watcher = $scope.$watch(characterCreateHelper.getCharName, function (newValue, oldValue) {
            if (newValue !== null && newValue !== "") {
                addC.CharacterName = newValue;
                return;
            }
            addC.CharacterName = "Character";
        });

        addC.AddConfig = {
            Title: "Choose your Race",
            PercentComplete: 10,
            Step: 1
        };

        var catcher = $scope.$on('title-change', function (event, config) {
            addC.AddConfig = config;
        });

        var destroyer = $scope.$on("$destroy", function () {
            // remove event listener
            catcher();
            watcher();
            destroyer();
        });

        return addC;
    }

})();