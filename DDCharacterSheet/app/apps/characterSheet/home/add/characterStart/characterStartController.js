(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("CharacterStartController", CharacterStartController);

    //Injected Dependencies
    CharacterStartController.$inject = ["$scope", "$state", "$mdMedia", "characterCreateHelper"];

    // Controller
    function CharacterStartController($scope, $state, $mdMedia, characterCreateHelper) {
        /* jshint validthis:true */

        var startC = this;

        var emitter = $scope.$emit('title-change', {
            Title: "Create your Character",
            PercentComplete: 10,
            Step: 1
        });

        startC.CharacterInfo = {
            Name: "",
            STR: 0,
            DEX: 0,
            CON: 0,
            WIS: 0,
            INT: 0,
            CHA: 0,
            Alignment: null
        };

        if (characterCreateHelper.getChar()) {
            $state.go("characterSheet.add.chooseRace");
        }

        startC.Next = next;
        startC.UpdateName = updateName;
        startC.Roll = roll;

        return startC;

        function getRandomInt(min, max) {
            return Math.floor(Math.random() * Math.floor(max-min) + min);
        }

        function updateName(name) {
            characterCreateHelper.setName(name);
        }

        function roll(type) {
            startC.CharacterInfo[type] = getRandomInt(3, 18);
        }

        function next() {
            if (startC.CharacterInfo.STR === 0) {
                roll("STR");
            }
            if (startC.CharacterInfo.DEX === 0) {
                roll("DEX");
            }
            if (startC.CharacterInfo.CON === 0) {
                roll("CON");
            }
            if (startC.CharacterInfo.INT === 0) {
                roll("INT");
            }
            if (startC.CharacterInfo.WIS === 0) {
                roll("WIS");
            }
            if (startC.CharacterInfo.CHA === 0) {
                roll("CHA");
            }
            if (!startC.CharacterInfo.Alignment) {
                startC.CharacterInfo.Alignment = "NN";
            }
            characterCreateHelper.setChar(startC.CharacterInfo);
            $state.go("characterSheet.add.chooseRace");
        }
    }

})();
