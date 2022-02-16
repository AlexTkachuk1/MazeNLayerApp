var Labirint = (function () {
    var labyrinth = [];
    heroX = 0;
    heroY = 0;

    hight = 10;
    width = 10;


    function setSize(_hight, _width) {
        if (hight > 0 && width > 0) {
            hight = _hight;
            width = _width;
        }
    }

    function generateLab(value) {
        for (var y = 0; y < value[1].mazeHeight; y++) {
            var line = [];
            for (var x = 0; x < value[1].mazeWidth; x++) {
                line[x] = null;
            }
            labyrinth.push(line);
        }
        for (var i = 0; i < value.length; i++) {
            var cell = value[i];
            labyrinth[cell.cordinateX][cell.cordinateY] = cell.typeName;
        }
        value.some(cell => cell.cordinateX == x && cell.cordinateY == y).typeName;
    }

    function getLabyrinth(value) {
        /*  let cells = JSON.parse(JSON.stringify(labyrinth));*/
        let labyrinthWithHero = [];
        for (var y = 0; y < value[1].mazeHeight; y++) {
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
        if (heroYPossible >= 0 && heroYPossible < hight
            && heroXPossible >= 0 && heroXPossible < width
            && labyrinth[heroYPossible][heroXPossible] !== "Wall") {
            heroX = heroXPossible;
            heroY = heroYPossible;
            switch (labyrinth[heroYPossible][heroXPossible]) {
                case "GoldHeap":
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "Gate":
                    window.location = "https://localhost:44328/Maze/DrawJs";
                    break;
            }

        }
    }

    return {
        getHight: function () { return hight; },
        getWidth: function () { return width; },
        generateLab: generateLab,
        getLabyrinth: getLabyrinth,
        heroStep: heroStep,
        setSize: setSize,
        drawLab: drawLab,
    };
})();