$(document).ready(function () {
    if (value !== null) {
        init('.drawer', value);
    }

    function init(selector, value) {
        var jfba = false;
        Labirint.generateLab(value);
        let labyrinth = Labirint.getLabyrinth(value);

        if (!jfba)
        {
            jfba = true;
            drawLab(selector, labyrinth);
        }

        /*step();*/
    }

    function drawLab(selector, labyrinth) {
        mainBlock = $(selector);

        var maze = $('<div>');
        maze.addClass('maze');
        for (var x = 0; x < 10; x++) {
            var mazeRow = $('<div>');
            mazeRow.addClass('row');
            for (var y = 0; y < 10; y++) {
                var cellType = 'cell ' + labyrinth[x][y];
                var mazeCell = $('<span>');
                mazeCell.addClass(cellType);
                mazeRow.append(mazeCell);
            }
            maze.append(mazeRow);
        }

        mainBlock.append(maze);
    }

    function step() {
        $(document).keydown(function (e) {
            if (e.keyCode >= 37 && e.keyCode <= 40) {
                //left
                if (e.keyCode == 37) {
                    dtoweStep(3);
                }
                //right
                if (e.keyCode == 39) {
                    dtoweStep(1);
                }
                //up
                if (e.keyCode == 38) {
                    dtoweStep(0);
                }
                //down
                if (e.keyCode == 40) {
                    dtoweStep(2);
                }
                e.preventDefault();
            }
        });
    }

    function dtoweStep(dir) {
        Labirint.heroStep(dir);
        labyrinth  = Labirint.getLabyrinth();
        drawLab(labyrinth);
    }
});