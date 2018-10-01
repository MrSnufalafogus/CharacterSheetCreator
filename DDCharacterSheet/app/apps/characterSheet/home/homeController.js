(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("HomeController", HomeController);

    //Injected Dependencies
    HomeController.$inject = ["$scope", "$state", "$mdToast", "$mdMedia", "$mdSidenav", "accessTokenService"];

    // Controller
    function HomeController($scope, $state, $mdToast, $mdMedia, $mdSidenav, accessTokenService) {
        /* jshint validthis:true */

        var homeC = this;

        homeC.IsFabOpen = false;

        homeC.ToggleSideNav = toggleSideNav;

        var watcher = $scope.$watch(function () {
            return $state.$current.name;
        }, function (newVal, oldVal) {
            if (newVal !== oldVal) {
                accessTokenService.checkIfCurrentTokenLogin().then(function (response) {

                }, function (response) {
                    $state.go("login");
                });
            }
        });

        return homeC;

        function toggleSideNav(id) {
            $mdSidenav(id).toggle();
        }
    }

})();