(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .factory("traitsService", traitsService);

    // Injected Services
    traitsService.$inject = ["$http", "authenticationSettings", "authenticationHelper"];

    function traitsService($http, authenticationSettings, authenticationHelper) {

        ///////////////
        // Functions //
        ///////////////

        var getTraits = function () {
            var url = authenticationSettings.serverPath + "api/Traits";

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
            getTraits: getTraits
        };

    }

})();