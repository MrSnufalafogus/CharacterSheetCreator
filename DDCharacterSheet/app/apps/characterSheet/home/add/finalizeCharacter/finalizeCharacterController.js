(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("FinalizeCharacterController", FinalizeCharacterController);

    //Injected Dependencies
    FinalizeCharacterController.$inject = ["$scope", "$state", "$mdDialog", "characterCreateHelper"];

    // Controller
    function FinalizeCharacterController($scope, $state, $mdDialog, characterCreateHelper) {
        /* jshint validthis:true */

        var finalizeC = this;

        finalizeC.Reset = reset;
        finalizeC.Save = save;

        finalizeC.CharacterInfo = {};

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

        function reset() {
            var confirm = $mdDialog.confirm()
                .title('Reset your Character?')
                .textContent('Are you sure you want to reset your character? All progress will be lost.')
                .ariaLabel('Reset character')
                .ok('Yes! Purge it from memory!')
                .cancel('No! I accidentally clicked this button!');

            $mdDialog.show(confirm).then(function () {
                characterCreateHelper.Reset();
                $state.go("characterSheet.add.characterStart");
            }, function () {
                //Do nothing on cancel
            });
        }

        function save() {
            characterCreateHelper.setInfo(finalizeC.CharacterInfo);
            var currentChars = JSON.parse(localStorage.getItem("CurrentCharacters")) || [];
            var char = characterCreateHelper.WrapUp();
            currentChars.push(char);
            localStorage.setItem("CurrentCharacters", JSON.stringify(currentChars));
            $state.go("characterSheet.characters");
        }
    }

})();