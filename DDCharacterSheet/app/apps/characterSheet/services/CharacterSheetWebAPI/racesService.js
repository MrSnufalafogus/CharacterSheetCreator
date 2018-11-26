(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .factory("racesService", racesService);

    // Injected Services
    racesService.$inject = ["$http", "authenticationSettings", "authenticationHelper"];

    function racesService($http, authenticationSettings, authenticationHelper) {

        ///////////////
        // Functions //
        ///////////////

        var getRaces = function () {
            var url = authenticationSettings.serverPath + "api/Races";

            var req = {
                method: "GET",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json",
                    "AccessTokenID": authenticationHelper.getAccessTokenIDForAPI()
                }
            };

            return $http(req);
        };

        ////////////////////////
        // Returned Functions //
        ////////////////////////

        return {
            getRaces: getRaces
        };

    }

})();