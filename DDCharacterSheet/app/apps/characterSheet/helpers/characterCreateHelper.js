(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .factory("characterCreateHelper", characterCreateHelper);

    characterCreateHelper.$inject = [];

    function characterCreateHelper() {
        /* jshint validthis:true */

        var characterCreateC = this;
        characterCreateC.char = null;
        characterCreateC.race = null;
        characterCreateC.class = null;
        characterCreateC.background = null;

        function setRace(inRace) {
            characterCreateC.race = inRace;
        }

        function setClass(inClass) {
            characterCreateC.class = inClass;
        }

        function setChar(inChar) {
            characterCreateC.char = inChar;
        }

        function setBackground(inBackground) {
            characterCreateC.background = inBackground;
        }

        function getBackground() {
            return characterCreateC.background;
        }

        function getRace() {
            return characterCreateC.race;
        }

        function getClass() {
            return characterCreateC.class;
        }

        function getChar() {
            return characterCreateC.char;
        }

        function getCharName() {
            if (characterCreateC.char) {
                return characterCreateC.char.Name;
            }
            return null;
        }

        function setName(name) {
            if (!characterCreateC.char) {
                characterCreateC.char = {};
            }
            characterCreateC.char.Name = name;
        }

        return {
            //Setters
            setClass: setClass,
            setRace: setRace,
            setChar: setChar,
            setName: setName,
            setBackground: setBackground,

            //Getters
            getRace: getRace,
            getClass: getClass,
            getChar: getChar,
            getCharName: getCharName,
            getBackground: getBackground

            //Processes
        };
    }

}) ();