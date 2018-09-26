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
        addC.RaceName = "";
        addC.ClassName = "";
        addC.BackgroundName = "";

        var watcher = $scope.$watch(characterCreateHelper.getCharName, function (newValue, oldValue) {
            if (newValue !== null && newValue !== "") {
                addC.CharacterName = newValue;
                return;
            }
            addC.CharacterName = "Character";
        });

        var watcher2 = $scope.$watch(characterCreateHelper.getRace, function (newValue, oldValue) {
            if (newValue !== null && newValue !== "") {
                addC.RaceName = "the " + newValue.Name;
                return;
            }
            addC.RaceName = "";
        });

        var watcher3 = $scope.$watch(characterCreateHelper.getClass, function (newValue, oldValue) {
            if (newValue !== null && newValue !== "") {
                addC.ClassName = newValue.Name;
                return;
            }
            addC.ClassName = "";
        });

        var watcher4 = $scope.$watch(characterCreateHelper.getBackground, function (newValue, oldValue) {
            if (newValue !== null && newValue !== "") {
                addC.BackgroundName = newValue.Name;
                return;
            }
            addC.BackgroundName = "";
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
            watcher2();
            watcher3();
            watcher4();
            destroyer();
        });

        addC.Back = back;

        return addC;

        function back() {
            switch (addC.AddConfig.Step) {
                case 2:
                    characterCreateHelper.setChar(null);
                    $state.go("characterSheet.add.characterStart");
                    break;
                case 3:
                    characterCreateHelper.setRace(null);
                    $state.go("characterSheet.add.chooseRace");
                    break;
                case 4:
                    characterCreateHelper.setClass(null);
                    $state.go("characterSheet.add.chooseClass");
                    break;
                case 5:
                    characterCreateHelper.setBackground(null);
                    $state.go("characterSheet.add.chooseBackground");
                    break;
            }
        }
    }

})();