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
        characterCreateC.info = null;

        function setRace(inRace) {
            characterCreateC.race = inRace;
        }

        function setClass(inClass) {
            characterCreateC.class = inClass;
        }

        function setChar(inChar) {
            characterCreateC.char = inChar;
        }

        function setInfo(inInfo) {
            characterCreateC.info = inInfo;
        }

        function setBackground(inBackground) {
            characterCreateC.background = inBackground;
        }

        function getBackground() {
            return characterCreateC.background;
        }

        function getInfo() {
            return characterCreateC.info;
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

        function reset() {
            characterCreateC.char = null;
            characterCreateC.race = null;
            characterCreateC.class = null;
            characterCreateC.background = null;
        }

        function wrapUp() {
            return {
                Char: characterCreateC.char,
                Race: characterCreateC.race,
                Class: characterCreateC.class,
                Background: characterCreateC.background,
                Info: characterCreateC.info
            };
        }

        return {
            //Setters
            setClass: setClass,
            setRace: setRace,
            setChar: setChar,
            setName: setName,
            setBackground: setBackground,
            setInfo: setInfo,

            //Getters
            getRace: getRace,
            getClass: getClass,
            getChar: getChar,
            getCharName: getCharName,
            getBackground: getBackground,
            getInfo: getInfo,

            //Processes
            Reset: reset,
            WrapUp: wrapUp
        };
    }

}) ();