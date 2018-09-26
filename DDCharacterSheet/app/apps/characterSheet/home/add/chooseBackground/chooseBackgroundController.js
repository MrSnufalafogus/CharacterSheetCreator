(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("ChooseBackgroundController", ChooseBackgroundController);

    //Injected Dependencies
    ChooseBackgroundController.$inject = ["$scope", "$state", "$mdDialog", "characterCreateHelper"];

    // Controller
    function ChooseBackgroundController($scope, $state, $mdDialog, characterCreateHelper) {
        /* jshint validthis:true */

        var backgroundC = this;

        if (!characterCreateHelper.getClass()) {
            $state.go("characterSheet.add.chooseClass");
        }

        var emitter = $scope.$emit('title-change', {
            Title: "Choose your Background",
            PercentComplete: 70,
            Step: 4
        });

        backgroundC.Backgrounds = [
            {
                Name: "Acolyte",
                Description: "You have spent your life in the service of a temple to a specific god or pantheon of gods.",
                SkillProf: "Insight and Religion",
                Languages: "Any two of your choice",
                Equipment: "A holy symbol (a gift to you when you entered the priesthood), a prayer book or prayer wheel, 5 sticks of incense, vestements, a set of common clothes",
                Gold: 15
            },
            {
                Name: "Charlatan",
                Description: "You have always had a way with people. You know what makes them tick, you can tease out their hearts' desires after a few minutes of conversation, and with a few leading questions you can read them like they were children's books.",
                SkillProf: "Deception and Sleight of Hand",
                ToolProf: "Disguise Kit and Forgery Kit",
                Equipment: "A set of fine clothes, a disguise kit, tools of the con of your choice (ten stoppered bottles filled with colored liquid, a set of weighted dice, a deck of marked cards, or a signet ring of an imaginary duke)",
                Gold: 15
            },
            {
                Name: "Criminal",
                Description: "You are an experienced criminal with a history of breaking the law.",
                SkillProf: "Deception and Stealth",
                ToolProf: "One type of gaming set and thieves' tools",
                Equipment: "A crowbar, a set of dark common clothes including a hood",
                Gold: 15
            },
            {
                Name: "Entertainer",
                Description: "You thrive in front of an audience. You know how to entrance them, entertain them, and even inspire them. Your poetics can stir the hearts of those who hear you, awakening grief or joy, laughter or anger.",
                SkillProf: "Acrobatics and Performance",
                ToolProf: "Disguise Kit and one type of musical instrument",
                Equipment: "A musical instument (one of your choice), the favor of an admirer (love letter, lock of hair, or trinket), a costume",
                Gold: 15
            },
            {
                Name: "Folk Hero",
                Description: "You come from a humble social rank, but you are destined for so much more. Already the people of your home village regard you as their champion.",
                SkillProf: "Animal Handling and Survival",
                ToolProf: "One type of artisan's tools and vehicles (land)",
                Equipment: "A set of artisan’s tools (one of your choice), a shovel, an iron pot, a set of common clothes",
                Gold: 10
            },
            {
                Name: "Guild Artisan",
                Description: "You are a member of an artisan’s guild, skilled in a particular field and closely associated with other artisans. You are a well-established part of the mercantile world, freed by talent and wealth from the constraints of a feudal social order.",
                SkillProf: "Insight and Persuasion",
                ToolProf: "One type of artisan's tools",
                Language: "One of your choice",
                Equipment: "A set of artisan’s tools (one of your choice), a letter of introduction from your guild, a set of traveler’s clothes",
                Gold: 10
            },
            {
                Name: "Hermit",
                Description: "You lived in seclusion — either in a sheltered community such as a monastery, or entirely alone — for a formative part of your life.",
                SkillProf: "Medicine and Religion",
                ToolProf: "Herbalism Kit",
                Language: "One of your choice",
                Equipment: "A scroll case stuffed full of notes from your studies or prayers, a winter blanket, a set of common clothes, a herbalism kit",
                Gold: 5
            },
            {
                Name: "Noble",
                Description: "You understand wealth, power, and privilege. You carry a noble title, and your family owns land, collects taxes, and wields significant political influence.",
                SkillProf: "History and Persuasion",
                ToolProf: "One type of gaming set",
                Language: "One of your choice",
                Equipment: "A set of fine clothes, a signet ring, a scroll of pedigree",
                Gold: 25
            },
            {
                Name: "Outlander",
                Description: "You grew up in the wilds, far from civilization and the comforts of town and technology. You’ve witnessed the migration of herds larger than forests, survived weather more extreme than any city-dweller could comprehend, and enjoyed the solitude of being the only thinking creature for miles in any direction.",
                SkillProf: "Athletics and Survival",
                ToolProf: "One type of musical instrument",
                Language: "One of your choice",
                Equipment: "A staff, a hunting trap, a trophy from an animal you killed, a set of traveler’s clothes",
                Gold: 10
            },
            {
                Name: "Sage",
                Description: "You spent years learning the lore of the multiverse. You scoured manuscripts, studied scrolls, and listened to the greatest experts on the subjects that interest you. Your efforts have made you a master in your fields of study.",
                SkillProf: "Arcana and History",
                Language: "Two of your choice",
                Equipment: "A bottle of black ink, a quill, a small knife, a letter from a dead colleague posing a question you have not yet been able to answer, a set of common clothes",
                Gold: 10
            },
            {
                Name: "Sailor",
                Description: "You sailed on a seagoing vessel for years. In that time, you faced down mighty storms, monsters of the deep, and those who wanted to sink your craft to the bottomless depths.",
                ToolProf: " Navigator’s tools, vehicles (water)",
                SkillProf: "Athletics and Perception",
                Equipment: "A belaying pin (club), 50 feet of silk rope, a lucky charm such as a rabbit foot or a small stone with a hole in the center (or you may roll for a random trinket on the Trinkets table in chapter 5), a set of common clothes",
                Gold: 10
            },
            {
                Name: "Soldier",
                Description: "War has been your life for as long as you care to remember. You trained as a youth, studied the use of weapons and armor, learned basic survival techniques, including how to stay alive on the battlefield.",
                ToolProf: "One type of gaming set, vehicles (land)",
                SkillProf: "Athletics and Intimidation",
                Equipment: "An insignia of rank, a trophy taken from a fallen enemy (a dagger, broken blade, or piece of a banner), a set of bone dice or deck of cards, a set of common clothes",
                Gold: 10
            },
            {
                Name: "Urchin",
                Description: "You grew up on the streets alone, orphaned, and poor. You had no one to watch over you or to provide for you, so you learned to provide for yourself.",
                ToolProf: "Disguise kit and thieves' tools",
                SkillProf: "Sleight of Hand and Stealth",
                Equipment: "A small knife, a map of the city you grew up in, a pet mouse, a token to remember your parents by, a set of common clothes",
                Gold: 10
            }
        ];

        backgroundC.ChooseBackground = choose;

        return backgroundC;

        function choose(background) {
            $mdDialog.show({
                controller: "TraitPickerController",
                controllerAs: "TraitPickerVC",
                templateUrl: 'app/apps/characterSheet/home/add/chooseBackground/traitPicker/traitPickerView.html',
                parent: angular.element(document.body),
                clickOutsideToClose: false,
                bindToController: true,
                fullscreen: true,
                locals: {
                    Background: background
                }
            }).then(function (response) {
                $state.go("characterSheet.add.finalize");
            }, function () {
                //Do nothing?
            });
        }
    }

})();