(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("HomeController", HomeController);

    //Injected Dependencies
    HomeController.$inject = ["$scope", "$state", "$mdToast", "$mdMedia", "$mdSidenav"];

    // Controller
    function HomeController($scope, $state, $mdToast, $mdMedia, $mdSidenav) {
        /* jshint validthis:true */

        var homeC = this;

        homeC.IsFabOpen = false;

        homeC.ToggleSideNav = toggleSideNav;

        return homeC;

        function toggleSideNav(id) {
            $mdSidenav(id).toggle();
        }
    }

})();