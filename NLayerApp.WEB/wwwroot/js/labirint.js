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
        mainBlock = $(selector);
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

    function heroStep(direction) {
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
            && heroXPossible >= 0 && heroXPossible < mazeWidth
            && labyrinth[heroYPossible][heroXPossible] !== "Wall") {
            heroX = heroXPossible;
            heroY = heroYPossible;
            switch (labyrinth[heroY][heroX]) {
                case "GoldHeap":
                    labyrinth[heroY][heroX] = "Ground";
                    break;
                case "Gate":
                    window.location = "https://localhost:44328/Maze/DrawJs";
                    break;
                case "Trap":
                    labyrinth[heroY][heroX] = "BrokenTrap";
                    break;
            }

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