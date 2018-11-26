(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .factory("charactersService", charactersService);

    // Injected Services
    charactersService.$inject = ["$http", "authenticationSettings", "authenticationHelper"];

    function charactersService($http, authenticationSettings, authenticationHelper) {

        ///////////////
        // Functions //
        ///////////////

        var getCharacter = function (characterID) {
            var url = authenticationSettings.serverPath + "api/Characters/" + characterID;

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

        var getCharactersByUserID = function (userID) {
            var url = authenticationSettings.serverPath + "api/Characters/User";

            var req = {
                method: "GET",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json",
                    "AccessTokenID": authenticationHelper.getAccessTokenIDForAPI()
                },
                params: {
                    userID: userID
                }
            };

            return $http(req);
        };

        var getCharacterByShareCode = function (shareCode) {
            var url = authenticationSettings.serverPath + "api/Characters/ShareCode";

            var req = {
                method: "GET",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json",
                    "AccessTokenID": authenticationHelper.getAccessTokenIDForAPI()
                },
                params: {
                    shareCode: shareCode
                }
            };

            return $http(req);
        };

        ////////////////////////
        // Returned Functions //
        ////////////////////////

        return {
            getCharacter: getCharacter,
            getCharactersByUserID: getCharactersByUserID,
            getCharacterByShareCode: getCharacterByShareCode
        };

    }

})();