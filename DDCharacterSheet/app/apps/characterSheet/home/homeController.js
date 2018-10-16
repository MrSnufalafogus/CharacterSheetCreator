(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("HomeController", HomeController);

    //Injected Dependencies
    HomeController.$inject = ["$scope", "$state", "$mdToast", "$mdMedia", "$mdSidenav", "accessTokenService", "authenticationHelper"];

    // Controller
    function HomeController($scope, $state, $mdToast, $mdMedia, $mdSidenav, accessTokenService, authenticationHelper) {
        /* jshint validthis:true */

        var homeC = this;

        homeC.IsFabOpen = false;

        homeC.ToggleSideNav = toggleSideNav;
        homeC.Logout = logout;

        var watcher = $scope.$watch($state.$current.name, function (newVal, oldVal) {
            accessTokenService.checkIfCurrentTokenLogin().then(function (response) {
                //Do nothing
            }, function (response) {
                $state.go("login");
            });
        });

        return homeC;

        function toggleSideNav(id) {
            $mdSidenav(id).toggle();
        }

        function logout() {
            $state.go("login");
        }
    }

})();
