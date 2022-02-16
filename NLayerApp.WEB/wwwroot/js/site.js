$(document).ready(function () {
    if (value !== null) {
        init('.drawer', value);
    }

    function init(selector, value) {
        Labirint.generateLab(value);
        let labyrinth = Labirint.getLabyrinth(value);

        drawLab(selector, labyrinth);


        step(selector, value);
    }

    function drawLab(selector, labyrinth) {
        mainBlock = $(selector);
        oldBlock = $('div').remove('.maze');
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

    function dtoweStep(dir, selector, value) {
        Labirint.heroStep(dir);
        let lab = Labirint.getLabyrinth(value);
        drawLab(selector, lab);
    }
});