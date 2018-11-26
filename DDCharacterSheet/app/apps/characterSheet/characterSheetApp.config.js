(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .config(["$stateProvider", "$urlRouterProvider", characterSheetConfig])
        .factory("httpRequestInterceptor", httpRequestInterceptor)
        .config(["$httpProvider", function ($httpProvider) {
            $httpProvider.interceptors.push("httpRequestInterceptor");
        }]);

    // Config
    function characterSheetConfig($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/signUp');

        $stateProvider

            //////////////////
            // Login Layout //
            //////////////////
            .state("login", {
                url: "/login",
                templateUrl: "app/apps/characterSheet/login/loginView.html",
                controller: "LoginController",
                controllerAs: "LoginVC"
            })

            /**Sign Up Layout*/
            .state("signUp", {
              url: "/signUp",
              templateUrl: "app/apps/characterSheet/login/signUp/signUpView.html",
              controller: "SignUpController",
              controllerAs: "SignUpVC"
            })

            /////////////////
            // Home Layout //
            /////////////////

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
            .state("characterSheet.add.finalize", {
                url: "/finalize",
                views: {
                    "content@characterSheet.add": {
                        templateUrl: "app/apps/characterSheet/home/add/finalizeCharacter/finalizeCharacterView.html",
                        controller: "FinalizeCharacterController",
                        controllerAs: "FinalizeCharacterVC"
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
            .state("characterSheet.add.chooseBackground", {
                url: "/chooseBackground",
                views: {
                    "content@characterSheet.add": {
                        templateUrl: "app/apps/characterSheet/home/add/chooseBackground/chooseBackgroundView.html",
                        controller: "ChooseBackgroundController",
                        controllerAs: "ChooseBackgroundVC"
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

    // Injected Services
    httpRequestInterceptor.$inject = ["$rootScope", "$q", "$injector"];

    // Factory
    function httpRequestInterceptor($rootScope, $q, $injector) {

        // $mdToast workaround
        // there is a circular dependency on $mdToast, because it requires $http for some bizarre reason, so we have to do it this way
        var toastr;
        function getToaster() {
            if (!toastr) {
                toastr = $injector.get("$mdToast");
            }
            return toastr;
        }

        // Return
        return {
            // Request
            request: function (config) {
                if (config.headers["AccessTokenID"]) {
                    if (!config.headers["IgnoreLoadingBar"]) {
                        $rootScope.ActiveLoadingCount += 1;
                    }
                }
                return config;
            },
            // Request Error
            requestError: function (rejection) {
                if (rejection.config.headers["AccessTokenID"]) {
                    if (!rejection.config.headers["IgnoreLoadingBar"]) {
                        $rootScope.ActiveLoadingCount -= 1;
                    }
                }
                return $q.reject(rejection);
            },
            // Response
            response: function (response) {
                if (response.config.headers["AccessTokenID"]) {
                    if (!response.config.headers["IgnoreLoadingBar"]) {
                        $rootScope.ActiveLoadingCount -= 1;
                    }
                }
                return response;
            },
            // Response Error
            responseError: function (rejection) {
                console.log(rejection);
                if (rejection.config.headers["AccessTokenID"]) {
                    if (!rejection.config.headers["IgnoreLoadingBar"]) {
                        $rootScope.ActiveLoadingCount -= 1;
                    }
                }
                return $q.reject(rejection);
            }
        };

    }

})();
