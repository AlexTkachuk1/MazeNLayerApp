var Labirint = (function () {
    var labyrinth = [];
    heroX = 0;
    heroY = 0;

    hight = 10;
    width = 10;
    size = 50;
    space = 3;

    function setSize(hight, width, size, space) {
        if (hight > 0 && width > 0 && size > 0 && space > 0) {
            hight = hight;
            width = width;
            size = size;
            space = space;
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

        }
    }

    return {
        getHight: function () { return hight; },
        getWidth: function () { return width; },
        getSize: function () { return size; },
        getSpace: function () { return space; },
        generateLab: generateLab,
        getLabyrinth: getLabyrinth,
        heroStep: heroStep,
        setSize: setSize,
    };
})();