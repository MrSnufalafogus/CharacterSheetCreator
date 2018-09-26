(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("CharactersController", CharactersController);

    //Injected Dependencies
    CharactersController.$inject = ["$scope", "$state", "$mdToast", "$mdMedia", "$mdSidenav"];

    // Controller
    function CharactersController($scope, $state, $mdToast, $mdMedia, $mdSidenav) {
        /* jshint validthis:true */

        var charactersC = this;

        charactersC.AddCharacter = addCharacter;

        charactersC.Characters = [
            {
                ClassImage: "http://www.infectedbyart.com/Images/Category_59/subcat_75/2509141648001.jpg",
                Name: "Smirnoff Heineken 0",
                ClassName: "Ranger",
                RaceName: "Gnome",
                Biography: "Smirnoff has traveled the world far and wide hunting every mythical beast he could find. From Bears to Dragons, Smirnoff has killed them all. But now he seeks a new adventure."
            },
            {
                ClassImage: "http://www.infectedbyart.com/Images/Category_59/subcat_75/2509141648001.jpg",
                Name: "Smirnoff Heineken 1",
                ClassName: "Ranger",
                RaceName: "Gnome",
                Biography: "Smirnoff has traveled the world far and wide hunting every mythical beast he could find. From Bears to Dragons, Smirnoff has killed them all. But now he seeks a new adventure."
            },
            {
                ClassImage: "http://www.infectedbyart.com/Images/Category_59/subcat_75/2509141648001.jpg",
                Name: "Smirnoff Heineken 2",
                ClassName: "Ranger",
                RaceName: "Gnome",
                Biography: "Smirnoff has traveled the world far and wide hunting every mythical beast he could find. From Bears to Dragons, Smirnoff has killed them all. But now he seeks a new adventure."
            },
            {
                ClassImage: "http://www.infectedbyart.com/Images/Category_59/subcat_75/2509141648001.jpg",
                Name: "Smirnoff Heineken 3",
                ClassName: "Ranger",
                RaceName: "Gnome",
                Biography: "Smirnoff has traveled the world far and wide hunting every mythical beast he could find. From Bears to Dragons, Smirnoff has killed them all. But now he seeks a new adventure."
            },
            {
                ClassImage: "http://www.infectedbyart.com/Images/Category_59/subcat_75/2509141648001.jpg",
                Name: "Smirnoff Heineken 4",
                ClassName: "Ranger",
                RaceName: "Gnome",
                Biography: "Smirnoff has traveled the world far and wide hunting every mythical beast he could find. From Bears to Dragons, Smirnoff has killed them all. But now he seeks a new adventure."
            }
        ];

        return charactersC;

        function addCharacter() {
            $state.go("characterSheet.add.characterStart");
        }
    }

})();