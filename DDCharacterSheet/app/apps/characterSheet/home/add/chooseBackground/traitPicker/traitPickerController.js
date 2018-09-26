(function () {
    "use strict";

    angular
        .module("CharacterSheetApp")
        .controller("TraitPickerController", TraitPickerController);

    //Injected Dependencies
    TraitPickerController.$inject = ["$scope", "$state", "$mdDialog", "traitHelper", "characterCreateHelper"];

    // Controller
    function TraitPickerController($scope, $state, $mdDialog, traitHelper, characterCreateHelper) {
        /* jshint validthis:true */

        var traitC = this;

        traitC.Trait = traitHelper.getTraitByName(traitC.Background.Name);

        traitC.Close = close;
        traitC.Submit = submit;

        return traitC;

        function submit() {
            characterCreateHelper.setBackground(traitC.Background);
            $mdDialog.hide();
        }

        function close() {
            $mdDialog.cancel();  
        }

    }

})();