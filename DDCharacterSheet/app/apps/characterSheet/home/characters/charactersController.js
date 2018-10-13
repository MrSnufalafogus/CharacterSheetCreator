(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("CharactersController", CharactersController);

    //Injected Dependencies
    CharactersController.$inject = ["$scope", "$state", "$mdDialog"];

    // Controller
    function CharactersController($scope, $state, $mdDialog) {
        /* jshint validthis:true */

        var charactersC = this;

        charactersC.AddCharacter = addCharacter;
        charactersC.Delete = deleteChar;

        charactersC.Characters = JSON.parse(localStorage.getItem("CurrentCharacters")) || [];

        return charactersC;

        function addCharacter() {
            $state.go("characterSheet.add.characterStart");
        }

        function deleteChar(index) {
            var confirm = $mdDialog.confirm()
                .title('Delete this Character?')
                .textContent('Are you sure you want to delete your character? Everthing will be forgotten.')
                .ariaLabel('Delete character')
                .ok('Yes! Purge it from memory!')
                .cancel('No! I accidentally clicked this button!');

            $mdDialog.show(confirm).then(function () {
                charactersC.Characters.splice(index, 1);
                localStorage.setItem("CurrentCharacters", JSON.stringify(charactersC.Characters));
            }, function () {
                //Do nothing on cancel
            });
        }
    }

})();