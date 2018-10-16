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
        charactersC.Share = shareChar;

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

        function shareChar(char) {
            var id = makeid();
            var confirm = $mdDialog.prompt()
                .title('Share '+char.Char.Name)
                .textContent('Here is the share ID for your character, copy it and send it to your friends!')
                .placeholder('Share ID')
                .ariaLabel('Share ID')
                .initialValue(id)
                .required(true)
                .ok('Cool Thanks!')
                .cancel('Close');

            $mdDialog.show(confirm).then(function (result) {
                
            }, function () {

            });
        }

        function makeid() {
            var text = "";
            var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (var i = 0; i < 5; i++)
                text += possible.charAt(Math.floor(Math.random() * possible.length));

            return text;
        }

    }

})();