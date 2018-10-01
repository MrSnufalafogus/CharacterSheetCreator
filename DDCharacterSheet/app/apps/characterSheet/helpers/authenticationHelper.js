(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .service("authenticationHelper", authenticationHelper)
        .constant("authenticationSettings", {
            // WebAPI Server Path
            serverPath: function () {
                var url = null;
                return (url === null ? "http://localhost/" : url) + "CharacterSheetWebAPI/";
                //return localStorage.getItem("eGenIndexJSOptions.apiURL") + "/eGenuityWebAPI/";
            }()
        });

    // Injected Dependencies
    authenticationHelper.$inject = ["$rootScope", "$q", "$state", "$injector", "$location"];

    // Service
    // This service hold the access token profile
    function authenticationHelper($rootScope, $q, $state, $injector, $location) {

        ///////////////
        // Variables //
        ///////////////

        var appName = null;

        // Service Storage Variables
        var accessToken = null;

        // Service Placeholders
        var accessTokenService;
        var sessionProfileService;
        var webUserPreferencesService;
        var authenticationService;
        var customerService;
        var userProfilesService;
        var mdToastService;
        var eGenHttpHelperService;

        ///////////////
        // Functions //
        ///////////////

        //
        // Get Services - Circular Dependency Workaround
        //

        ///////////////////
        // Set Functions //
        ///////////////////

        // Set Access Token
        function setAccessToken(accessTokenIn) {
            localStorage.setItem("CC.AccessToken", JSON.stringify(accessTokenIn));
            accessToken = accessTokenIn;
        }

        ///////////////////
        // Get Functions //
        ///////////////////

        function padString(pad, str, padLeft) {
            if (typeof str === 'undefined')
                return pad;
            if (padLeft) {
                return (pad + str).slice(-pad.length);
            } else {
                return (str + pad).substring(0, pad.length);
            }
        }


        // Get Access Token
        function getAccessToken() {
            if (accessToken === null || accessToken === void 0) {
                if (localStorage.getItem("CC.AccessToken") !== null) {
                    return JSON.parse(localStorage.getItem("CC.AccessToken"));
                }
            }
            return accessToken;
        }

        // return the accessTokenID value formatted for the WebAPI
        function getAccessTokenIDForAPI() {
            var returnValue = "";
            if (accessToken === null || accessToken === void 0) {
                if (localStorage.getItem("CC.AccessToken") !== null) {
                    var at = JSON.parse(localStorage.getItem("CC.AccessToken"));
                    returnValue = returnValue + at.AccessTokenID;
                }
            } else {
                returnValue = returnValue + accessToken.AccessTokenID;
            }
            return returnValue;
        }


        ////////////////////////
        // Returned Functions //
        ////////////////////////

        return {
            // Set
            setAccessToken: setAccessToken,

            // Get
            getAccessToken: getAccessToken,
            getAccessTokenIDForAPI: getAccessTokenIDForAPI
        };

    }

})();
