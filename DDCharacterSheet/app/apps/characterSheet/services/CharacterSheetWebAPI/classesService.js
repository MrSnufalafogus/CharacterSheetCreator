(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .factory("classesService", classesService);

    // Injected Services
    classesService.$inject = ["$http", "authenticationSettings", "authenticationHelper"];

    function classesService($http, authenticationSettings, authenticationHelper) {

        ///////////////
        // Functions //
        ///////////////

        var getClasses = function () {
            var url = authenticationSettings.serverPath + "api/Classes";

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
            getClasses: getClasses
        };

    }

})();