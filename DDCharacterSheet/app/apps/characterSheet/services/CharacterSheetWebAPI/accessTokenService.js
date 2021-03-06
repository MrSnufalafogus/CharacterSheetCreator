﻿(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .factory("accessTokenService", accessTokenService);

    // Injected Services
    accessTokenService.$inject = ["$http", "authenticationSettings", "authenticationHelper"];

    function accessTokenService($http, authenticationSettings, authenticationHelper) {

        ///////////////
        // Functions //
        ///////////////

        var getNewToken = function (credentials) {
            var safeCredential = credentials || {};
            var url = authenticationSettings.serverPath + "api/AccessTokens";

            var req = {
                method: "POST",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json"
                },
                data: safeCredential
            };

            return $http(req);
        };

        var checkIfCurrentTokenLogin = function () {
            var token = JSON.parse(localStorage.getItem("CC.AccessToken"));
            var url = authenticationSettings.serverPath + "api/AccessTokens/" + token.AccessTokenID;

            var req = {
                method: "GET",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json"
                }
            };

            return $http(req);
        };

        var accessTokensLogin = function (loginUsername, loginPassword, isLongTerm) {
            var url = authenticationSettings.serverPath + "api/AccessTokens";
            var token = authenticationHelper.getAccessToken();
            var item = {
                LoginID: loginUsername,
                LoginPassword: loginPassword,
                IsLongTerm: isLongTerm,
                AccessTokenID: token ? token.AccessTokenID : null
            };

            var req = {
                method: "POST",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json",
                    "AccessTokenID": authenticationHelper.getAccessTokenIDForAPI()
                },
                data: item
            };

            return $http(req);
        };


        var logout = function () {
            var url = authenticationSettings.serverPath + "api/AccessTokens";
            var item = {};

            var req = {
                method: "POST",
                url: url,
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                    "Accept": "application/json",
                    "AccessTokenID": authenticationHelper.getAccessTokenIDForAPI()
                },
                data: item
            };

            return $http(req);
        };

        ////////////////////////
        // Returned Functions //
        ////////////////////////

        return {
            getNewToken: getNewToken,
            checkIfCurrentTokenLogin: checkIfCurrentTokenLogin,
            accessTokensLogin: accessTokensLogin,
            logout: logout
        };

    }

})();