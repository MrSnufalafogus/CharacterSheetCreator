(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .config(["$stateProvider", "$urlRouterProvider", characterSheetConfig]);

    // Config
    function characterSheetConfig($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/characterSheet/characters');

        $stateProvider
            // Home Layout
            .state("characterSheet", {
                url: "/characterSheet",
                templateUrl: "app/apps/characterSheet/home/homeView.html",
                controller: "HomeController",
                controllerAs: "HomeVC"
            })
            .state("characterSheet.characters", {
                url: "/characters",
                views: {
                    "content@characterSheet": {
                        templateUrl: "app/apps/characterSheet/home/characters/charactersView.html",
                        controller: "CharactersController",
                        controllerAs: "CharactersVC"
                    }
                }
            })

            //////////////////////
            // Character Create //
            //////////////////////

            .state("characterSheet.add", {
                url: "/add",
                views: {
                    "content@characterSheet": {
                        templateUrl: "app/apps/characterSheet/home/add/addView.html",
                        controller: "AddController",
                        controllerAs: "AddVC"
                    }
                }
            })
            .state("characterSheet.add.characterStart", {
                url: "/start",
                views: {
                    "content@characterSheet.add": {
                        templateUrl: "app/apps/characterSheet/home/add/characterStart/characterStartView.html",
                        controller: "CharacterStartController",
                        controllerAs: "CharacterStartVC"
                    }
                }
            })
            .state("characterSheet.add.chooseClass", {
                url: "/chooseClass",
                views: {
                    "content@characterSheet.add": {
                        templateUrl: "app/apps/characterSheet/home/add/chooseClass/chooseClassView.html",
                        controller: "ChooseClassController",
                        controllerAs: "ChooseClassVC"
                    }
                }
            })
            .state("characterSheet.add.chooseRace", {
                url: "/chooseRace",
                views: {
                    "content@characterSheet.add": {
                        templateUrl: "app/apps/characterSheet/home/add/chooseRace/chooseRaceView.html",
                        controller: "ChooseRaceController",
                        controllerAs: "ChooseRaceVC"
                    }
                }
            })

            //////////////
            // Settings //
            //////////////

            .state("characterSheet.settings", {
                url: "/settings",
                views: {
                    "content@characterSheet": {
                        templateUrl: "app/apps/characterSheet/home/settings/settingsView.html",
                        controller: "SettingsController",
                        controllerAs: "SettingsVC"
                    }
                }
            });
    }

})();