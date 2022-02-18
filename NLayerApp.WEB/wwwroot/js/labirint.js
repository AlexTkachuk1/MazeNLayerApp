var Labirint = (function () {
    var labyrinth = [];
    heroX = 0;
    heroY = 0;

    mazeHight = 10;
    mazeWidth = 20;


    function setSize(hight, width) {
        if (hight > 0 && width > 0) {
            mazeHight = hight;
            mazeWidth = width;
        }
    }

    function generateLab(value) {
        for (var y = 0; y < value.mazeHeight; y++) {
            var line = [];
            for (var x = 0; x < value.mazeWidth; x++) {
                line[x] = null;
            }
            labyrinth.push(line);
        }
        for (var i = 0; i < value.cellViewModels.length; i++) {
            var cell = value.cellViewModels[i];
            labyrinth[cell.cordinateY][cell.cordinateX] = cell.typeName;
        }
    }

    function getLabyrinth(value) {
        /*  let cells = JSON.parse(JSON.stringify(labyrinth));*/
        let labyrinthWithHero = [];
        for (var y = 0; y < value.mazeHeight; y++) {
            let copyLine = labyrinth[y].slice();
            labyrinthWithHero.push(copyLine);
        }
        labyrinthWithHero[heroY][heroX] = "CellWithHero";
        return labyrinthWithHero;
    }

    function drawLab(selector, labyrinth) {
        var mainBlock = $(selector);
        oldBlock = $('div').remove('.maze');
        var maze = $('<div>');
        maze.addClass('maze');
        for (var x = 0; x < Labirint.getHight(); x++) {
            var mazeRow = $('<div>');
            mazeRow.addClass('row');
            for (var y = 0; y < Labirint.getWidth(); y++) {
                var cellType = 'cell ' + labyrinth[x][y];
                var mazeCell = $('<span>');
                mazeCell.addClass(cellType);
                mazeRow.append(mazeCell);
            }
            maze.append(mazeRow);
        }

        mainBlock.append(maze);
    }

    function sleep(milliseconds) {
        const date = Date.now();
        let currentDate = null;
        do {
            currentDate = Date.now();
        } while (currentDate - date < milliseconds);
    }

    function heroStep(direction, value) {
        let heroXPossible = heroX;
        let heroYPossible = heroY;
        switch (direction) {
            case 0:
                heroYPossible--;
                break;
            case 1:
                heroXPossible++;
                break;
            case 2:
                heroYPossible++;
                break;
            case 3:
                heroXPossible--;
                break;
        }
        if (heroYPossible >= 0 && heroYPossible < mazeHight
            && heroXPossible >= 0 && heroXPossible < mazeWidth) {

            switch (labyrinth[heroYPossible][heroXPossible]) {
                case "Сhest":
                    HeroStatus.heroStepOnCell("Сhest");
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "Wall":
                    if (HeroIndicators.GetHasGiganHammer()) {
                        HeroStatus.heroStepOnCell("Wall");
                        labyrinth[heroYPossible][heroXPossible] = "Ground";
                    }
                    else {
                        heroXPossible = heroX;
                        heroYPossible = heroY;
                    }
                    break;
                case "Trap":
                    HeroStatus.heroStepOnCell("Trap");
                    labyrinth[heroYPossible][heroXPossible] = "BrokenTrap";
                    break;
                case "GoldHeap":
                    HeroStatus.heroStepOnCell("GoldHeap");
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "Gate":
                    window.location = "https://localhost:44328/Maze/DrawJs";
                    break;
                case "BrokenTrap":

                    break;
                case "Legionary":
                    if (HeroIndicators.GetInvisible())
                    {
                        sleep(50);
                        HeroStatus.heroStepOnCell("Legionary");
                        labyrinth[heroYPossible][heroXPossible] = "Legionary";
                    }
                    else
                    {
                        HeroStatus.heroStepOnCell("Legionary");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "Boss":
                    if (HeroIndicators.GetInvisible()) {
                        sleep(50);
                        HeroStatus.heroStepOnCell("Boss");
                        labyrinth[heroYPossible][heroXPossible] = "Boss";
                    }
                    else
                    {
                        HeroStatus.heroStepOnCell("Boss");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "Rip":

                    break;
            }
            heroX = heroXPossible;
            heroY = heroYPossible;
        }
    }

    return {
        getHight: function () { return mazeHight; },
        getWidth: function () { return mazeWidth; },
        getHeroX: function () { return heroX; },
        getHeroY: function () { return heroY; },
        generateLab: generateLab,
        getLabyrinth: getLabyrinth,
        heroStep: heroStep,
        setSize: setSize,
        drawLab: drawLab,
    };
})();