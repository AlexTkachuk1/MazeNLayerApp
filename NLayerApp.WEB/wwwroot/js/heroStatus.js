var HeroStatus = (function () {

    function heroStepOnGold() {
        var step = JSON.stringify("step");
        $.ajax({
            url: "/Maze/HeroStepOnGold/",
            method: "POST",
            contentType: 'application/json',
            data: step,
            success: function (response) {
                console.log(response);
            }
        });
    }

    function saveHeroStatusСhanges() {
        var heroViewModel = JSON.stringify(hero);
        $.ajax({
            url: "/Maze/UpdateHeroStatus/",
            method: "POST",
            contentType: 'application/json',
            data: heroViewModel,
            success: function (response) {
                console.log(response);
            }
        });
    }

    return {
        heroStepOnGold: heroStepOnGold,
        SaveHeroStatusСhanges: saveHeroStatusСhanges
    };
})();