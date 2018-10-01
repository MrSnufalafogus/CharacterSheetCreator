(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("FinalizeCharacterController", FinalizeCharacterController);

    //Injected Dependencies
    FinalizeCharacterController.$inject = ["$scope", "$state", "characterCreateHelper"];

    // Controller
    function FinalizeCharacterController($scope, $state, characterCreateHelper) {
        /* jshint validthis:true */

        var finalizeC = this;

        if (!characterCreateHelper.getBackground()) {
            $state.go("characterSheet.add.chooseBackground");
        }
        else {
            finalizeC.CharacterName = characterCreateHelper.getChar().Name;
        }

        var emitter = $scope.$emit('title-change', {
            Title: "Finalizing your Character",
            PercentComplete: 90,
            Step: 5
        });

        return finalizeC;

    }

})();