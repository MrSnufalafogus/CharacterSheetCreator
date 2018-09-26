(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("ChooseRaceController", ChooseRaceController);

    //Injected Dependencies
    ChooseRaceController.$inject = ["$scope", "$state", "$mdToast", "characterCreateHelper"];

    // Controller
    function ChooseRaceController($scope, $state, $mdToast, characterCreateHelper) {
        /* jshint validthis:true */

        var chooseRaceC = this;

        var emitter = $scope.$emit('title-change', {
            Title: "Choose your Race",
            PercentComplete: 20,
            Step: 2
        });

        if (!characterCreateHelper.getChar()) {
            $state.go("characterSheet.add.characterStart");
        }

        chooseRaceC.Races = [
            {
                ID: 0,
                Name: "Dwarf",
                RaceImage: "https://vignette.wikia.nocookie.net/forgottenrealms/images/b/b6/Dwarf-5e.png/revision/latest?cb=20180814005205",
                Description: "Bold and hardy, dwarves are known as skilled warriors, miners, and workers of stone and metal. Though they stand well under 5 feet tall, dwarves are so broad and compact that they can weigh as much as a human standing nearly two feet taller. Their courage and endurance are also easily a match for any of the larger folk.",
                ASIncrease: [
                    {
                        Type: "Constitution",
                        Amount: 2
                    }
                ],
                AgeRange: "50 to 350",
                Size: "4 to 5 feet tall | Medium",
                Speed: "25 feet",
                Languages: "Common & Dwarvish",
                Subtypes: "Hill Dwarf, Mountain Dwarf"
            },
            {
                ID: 1,
                Name: "Elf",
                RaceImage: "https://vignette.wikia.nocookie.net/forgottenrealms/images/6/6f/Elves_-_William_O'Connor.jpg/revision/latest/scale-to-width-down/302?cb=20090519183055",
                Description: "Elves are a magical people of otherworldly grace, living in the world but not entirely part of it. They live in places of ethereal beauty, in the midst of ancient forests or in silvery spires glittering with faerie light, where soft music drifts throught the air and gentle fragrances waft on the breeze.",
                ASIncrease: [
                    {
                        Type: "Dexterity",
                        Amount: 2
                    }
                ],
                AgeRange: "20 to 750",
                Size: "5 to 6 feet tall | Medium",
                Speed: "30 feet",
                Languages: "Common & Elvish",
                Subtypes: "High Elf, Dark Elf"
            },
            {
                ID: 2,
                Name: "Halfling",
                RaceImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/256/420/618/636271789409776659.png",
                Description: "The comforts of home are the goals of most halflings' lives: a place to settle in peace and quiet, far from marauding monsters and clashing armies; a blazing fire and a generous meal; fine drink and fine conversation. Though some halflings live out their days in remote agricultural communities, others form nomadic bands that travel constantly, lured by the open road.",
                ASIncrease: [
                    {
                        Type: "Dexterity",
                        Amount: 2
                    }
                ],
                AgeRange: "20 to 200",
                Size: "Around 3 feet tall | Small",
                Speed: "25 feet",
                Languages: "Common and Halfling",
                Subtypes: "Lightfoot Halfling, Stout Halfling"
            },
            {
                ID: 3,
                Name: "Human",
                RaceImage: "https://vignette.wikia.nocookie.net/forgottenrealms/images/9/98/Human-5e.png/revision/latest?cb=20171222050434",
                Description: "In the reckonings of most worlds, humans are the youngest of the common races, late to arrive on the world scene and short-lived in comparison to the dwarves, elves, and dragons. Perhaps it is because of their shorter lives that they strive to achieve as much as they can in the years they are given. Humans are the innovators, the achievers, and the pioneers of the worlds.",
                ASIncrease: [
                    {
                        Type: "Consitution",
                        Amount: 1
                    },
                    {
                        Type: "Dexterity",
                        Amount: 1
                    },
                    {
                        Type: "Strength",
                        Amount: 1
                    },
                    {
                        Type: "Wisdom",
                        Amount: 1
                    },
                    {
                        Type: "Intelligence",
                        Amount: 1
                    },
                    {
                        Type: "Charisma",
                        Amount: 1
                    }
                ],
                AgeRange: "18 to 80",
                Size: "5 to 6 feet tall | Medium",
                Speed: "30 feet",
                Languages: "Common and 1 Extra"
            },
            {
                ID: 4,
                Name: "Dragonborn",
                RaceImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/340/420/618/636272677995471928.png",
                Description: "Born of dragons, as their name proclaims, the dragonborn walk proudly through a world that greets them with fearful incomprehension. Shaped by draconic gods of the dragons themselves, dragonborn originally hatched from dragon eggs as a unique race, combining the best attributes of dragons and humanoids.",
                ASIncrease: [
                    {
                        Type: "Strength",
                        Amount: 2
                    },
                    {
                        Type: "Charisma",
                        Amount: 1
                    }
                ],
                AgeRange: "15 to 80",
                Size: "Around 6 feet tall | Medium",
                Speed: "30 feet",
                Languages: "Common and Draconic"
            },
            {
                ID: 5,
                Name: "Gnome",
                RaceImage: "https://vignette.wikia.nocookie.net/theofficialbestiary/images/5/5f/GnomeProfileD%26D.jpg/revision/latest?cb=20150819163211",
                Description: "A constant hum of busy activity pervades the warrens and neighborhoods where gnomes form their closeknit communities. Louder sounds punctuate the hum : a crunch of grinding gears here, a minor explosion there, a yelp of surprise or triumph, and especially bursts of laughter.",
                ASIncrease: [
                    {
                        Type: "Intelligence",
                        Amount: 2
                    }
                ],
                AgeRange: "40 to 500",
                Size: "3 to 4 feet tall | Small",
                Speed: "25 feet",
                Languages: "Common & Gnomish",
                Subtypes: "Forest Gnome, Rock Gnome"
            },
            {
                ID: 6,
                Name: "Half-Elf",
                RaceImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/6/481/420/618/636274618102950794.png",
                Description: "Walking in two worlds but truly belonging to neither, half-elves combine what some say are the best qualities of their elf and human parents: human curiosity, inventiveness, and ambition tempered by the refined senses, love and nature, and artistic tastes of the elves.",
                ASIncrease: [
                    {
                        Type: "Charisma",
                        Amount: 2
                    },
                    {
                        Type: "2 Extras",
                        Amount: 1
                    }
                ],
                AgeRange: "20 to 180",
                Size: "5 to 6 feet tall | Medium",
                Speed: "30 feet",
                Languages: "Common, Elvish & 1 Extra"
            },
            {
                ID: 7,
                Name: "Half-Orc",
                RaceImage: "https://vignette.wikia.nocookie.net/forgottenrealms/images/0/03/Half-orc-5e.png/revision/latest?cb=20180814011230",
                Description: "Whether united under the leadership of a mighty warlock or having fought to a standstill after years of conflict, orc and human tribes sometimes form alliances, joining forces into a larger horde to the terror of civilized lands nearby. When these alliances are sealed by marriages, half-orcs are born.",
                ASIncrease: [
                    {
                        Type: "Strength",
                        Amount: 2
                    },
                    {
                        Type: "Constitution",
                        Amount: 1
                    }
                ],
                AgeRange: "14 to 75",
                Size: "5 to 6 feet tall| Medium",
                Speed: "30 feet",
                Languages: "Common & Orcish"
            },
            {
                ID: 8,
                Name: "Teifling",
                RaceImage: "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/641/420/618/636287076637981942.png",
                Description: "To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the teifling. And to twist the knife, teiflings know that this is because a pact struck generations ago infused the essence of Asmodeus - overlord of the Nine Hells - into their bloodline.",
                ASIncrease: [
                    {
                        Type: "Intelligence",
                        Amount: 1
                    },
                    {
                        Type: "Charisma",
                        Amount: 2
                    }
                ],
                AgeRange: "18 to 80",
                Size: "5 to 6 feet tall | Medium",
                Speed: "30 feet",
                Languages: "Common & Infernal"
            }
        ];

        chooseRaceC.ChooseRace = chooseRace;

        return chooseRaceC;

        function chooseRace(inRace) {
            characterCreateHelper.setRace(inRace);
            $state.go("characterSheet.add.chooseClass");
        }
    }

})();