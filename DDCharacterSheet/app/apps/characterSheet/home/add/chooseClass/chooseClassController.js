(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("ChooseClassController", ChooseClassController);

    //Injected Dependencies
    ChooseClassController.$inject = ["$scope", "$state", "characterCreateHelper"];

    // Controller
    function ChooseClassController($scope, $state, characterCreateHelper) {
        /* jshint validthis:true */

        var chooseClassC = this;

        var emitter = $scope.$emit('title-change', {
            Title: "Choose your Class",
            PercentComplete: 30,
            Step: 3
        });

        if (!characterCreateHelper.getRace()) {
            $state.go("characterSheet.add.chooseRace");
        }

        chooseClassC.ChooseClass = chooseClass;

        chooseClassC.Classes = [
            {
                ID: 0,
                Name: "Barbarian",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/342/420/618/636272680339895080.png",
                Description: "A fierce warrior of primitive background who can enter a battle rage.",
                HitDie: "d12",
                PrimaryAbility: "Strength",
                SavingThrows: "Strength and Constitution",
                ArmorProf: "Light and Medium armor, shields, ",
                WeaponProf: "Simple and Martial Weapons"
            },
            {
                ID: 1,
                Name: "Bard",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/369/420/618/636272705936709430.png",
                Description: "An inspiring magician whose power echoes the music of creation.",
                HitDie: "d8",
                PrimaryAbility: "Charisma",
                SavingThrows: "Dexterity and Charisma",
                ArmorProf: "Light armor, ",
                WeaponProf: "simple weapons, hand crossbows, longswords, rapiers, shortswords"
            },
            {
                ID: 2,
                Name: "Cleric",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/371/420/618/636272706155064423.png",
                Description: "A priestly champion who wields divine magic in service of a higher power.",
                HitDie: "d8",
                PrimaryAbility: "Wisdom",
                SavingThrows: "Wisdom and Charisma",
                ArmorProf: "Light and medium armor, shields, ",
                WeaponProf: "simple weapons"
            },
            {
                ID: 3,
                Name: "Druid",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/346/420/618/636272691461725405.png",
                Description: "A priest of the Old Faith, wielding the powers of nature - moonlight and plant growth, fire and lightning - and adopting animal forms.",
                HitDie: "d8",
                PrimaryAbility: "Wisdom",
                SavingThrows: "Wisdom and Intelligence",
                ArmorProf: "Light and medium armor (nonmetal), shields (nonmetal), ",
                WeaponProf: "clubs, daggers, darts, javelins, maces, quarterstaffs, scimitars, sickles, slings, spears"
            },
            {
                ID: 4,
                Name: "Fighter",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/359/420/618/636272697874197438.png",
                Description: "A master of martial combat, skilled with a variety of weapons and armor.",
                HitDie: "d10",
                PrimaryAbility: "Strength or Dexterity",
                SavingThrows: "Strength and Constitution",
                ArmorProf: "All armors, shields, ",
                WeaponProf: "simple and martial weapons"
            },
            {
                ID: 5,
                Name: "Monk",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/489/420/618/636274646181411106.png",
                Description: "A master of martial arts, harnessing the power of the body in pursuit of physical and spiritual perfection",
                HitDie: "d8",
                PrimaryAbility: "Dexterity and Wisdom",
                SavingThrows: "Strength and Dexterity",
                ArmorProf: "No armors, ",
                WeaponProf: "shortswords"
            },
            {
                ID: 6,
                Name: "Paladin",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/365/420/618/636272701937419552.png",
                Description: "A holy warrior bound to a sacred oath.",
                HitDie: "d10",
                PrimaryAbility: "Strength and Charisma",
                SavingThrows: "Wisdom and Charisma",
                ArmorProf: "All armors, shields, ",
                WeaponProf: "simple and martial weapons"
            },
            {
                ID: 7,
                Name: "Ranger",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/367/420/618/636272702826438096.png",
                Description: "A warrior who uses martial prowess and nature magic to combat threats on the edges of civilization.",
                HitDie: "d10",
                PrimaryAbility: "Dexterity and Wisdom",
                SavingThrows: "Strength and Dexterity",
                ArmorProf: "Light and medium armor, shields, ",
                WeaponProf: "simple and martial weapons"
            },
            {
                ID: 8,
                Name: "Rogue",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/384/420/618/636272820319276620.png",
                Description: "A scoundrel who uses stealth and trickery to overcome obstacles and enemies.",
                HitDie: "d8",
                PrimaryAbility: "Dexterity",
                SavingThrows: "Dexterity and Intelligence",
                ArmorProf: "Light armor, ",
                WeaponProf: "simple weapons, hand crossbows, longswords, rapiers, shortswords"
            },
            {
                ID: 9,
                Name: "Sorcerer",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/485/420/618/636274643818663058.png",
                Description: "A spellcaster who draws on inherent magic from a gift or bloodline.",
                HitDie: "d6",
                PrimaryAbility: "Charisma",
                SavingThrows: "Constitution and Charisma",
                ArmorProf: "No armor, ",
                WeaponProf: "daggers, darts, slings, quarterstaffs, light crossbows"
            },
            {
                ID: 10,
                Name: "Warlock",
                ClassImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/375/420/618/636272708661726603.png",
                Description: "A wielder of magic that is derived from a bargain with an extraplanar entity.",
                HitDie: "d8",
                PrimaryAbility: "Charisma",
                SavingThrows: "Wisdom and Charisma",
                ArmorProf: "Light armor, ",
                WeaponProf: "simple weapons"
            },
            {
                ID: 11,
                Name: "Wizard",
                ClassImage: "https://i.pinimg.com/originals/71/e1/13/71e11328ed967b50c126fd5e47114ec0.png",
                Description: "A scholarly magic-user capable of manipulating the structures of reality",
                HitDie: "d6",
                PrimaryAbility: "Intelligence",
                SavingThrows: "Wisdom and Intelligence",
                ArmorProf: "No armor, ",
                WeaponProf: "daggers, darts, slings, quarterstaffs, light crossbows"
            }
        ];

        return chooseClassC;

        function chooseClass(inClass) {
            characterCreateHelper.setClass(inClass);
            $state.go("characterSheet.add.chooseClass");
        }
    }

})();