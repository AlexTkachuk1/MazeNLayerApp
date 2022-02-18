var Site = (function () {
    function init(value) {
        var selector = '.drawer';
        Labirint.setSize(value.mazeHeight, value.mazeWidth);
        Labirint.generateLab(value);
        let labyrinth = Labirint.getLabyrinth(value);

        Labirint.drawLab(selector, labyrinth);


        step(selector, value);
    }

    function step(selector, value) {
        $(document).keydown(function (e) {
            if (e.keyCode >= 37 && e.keyCode <= 40) {
                //left
                if (e.keyCode == 37) {
                    dtoweStep(3, selector, value);
                }
                //right
                if (e.keyCode == 39) {
                    dtoweStep(1, selector, value);
                }
                //up
                if (e.keyCode == 38) {
                    dtoweStep(0, selector, value);
                }
                //down
                if (e.keyCode == 40) {
                    dtoweStep(2, selector, value);
                }
                e.preventDefault();
            }
        });
    }

    function sleep(milliseconds) {
        const date = Date.now();
        let currentDate = null;
        do {
            currentDate = Date.now();
        } while (currentDate - date < milliseconds);
    }

    function dtoweStep(dir, selector, value) {
        Labirint.heroStep(dir);
        let lab = Labirint.getLabyrinth(value);
        Labirint.drawLab(selector, lab);
        sleep(50);
        HeroIndicators.Update();
    }
    return {
        Init: init
    };
})();