var Labirint = (function () {
    var labyrinth = [];
    heroX = 1;
    heroY = 1;

    var teleport = [];

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
            if (cell.typeName == "Teleport") {
                var teleportCell = [];
                teleportCell.push(cell.cordinateY);
                teleportCell.push(cell.cordinateX);
                teleport.push(teleportCell);
            }
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
    function getRandomInt(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min)) + min; //Максимум не включается, минимум включается
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
                    else if (HeroIndicators.GetCanJumpValue() > 0) {
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
                            && labyrinth[heroYPossible][heroXPossible] == "Ground") {
                            HeroStatus.heroStepOnCell("Wall");
                            heroX = heroXPossible;
                            heroY = heroYPossible;
                        }
                        else {
                            heroXPossible = heroX;
                            heroYPossible = heroY;
                        }

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
                    var val = getRandomInt(1, 4);
                    switch (val) {
                        case 1:
                            window.location = "https://localhost:44328/Maze/DrawJs";
                            break;
                        case 2:
                            window.location = "https://localhost:44328/Maze/DrawCursedForest";
                            break;
                        case 3:
                            window.location = "https://localhost:44328/Maze/DrawPoisonSwamps";
                            break;
                    }

                    break;
                case "BrokenTrap":

                    break;
                case "Legionary":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Legionary");
                        labyrinth[heroYPossible][heroXPossible] = "Legionary";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Legionary");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "Boss":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Boss");
                        labyrinth[heroYPossible][heroXPossible] = "Boss";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Boss");
                        labyrinth[heroYPossible][heroXPossible] = "DethBoss";
                    }
                    break;
                case "Rip":

                    break;
                case "Teleport":
                    if (teleport[0][0] == heroYPossible && teleport[0][1] == heroXPossible) {
                        heroYPossible = teleport[1][0];
                        heroXPossible = teleport[1][1];
                    }
                    else if (teleport[1][0] == heroYPossible && teleport[1][1] == heroXPossible) {
                        heroYPossible = teleport[0][0];
                        heroXPossible = teleport[0][1];
                    }
                    break;
                case "MiracleShop":
                    $('.Choice').show();
                    $('.drawer').hide();
                    heroXPossible = heroX;
                    heroYPossible = heroY;
                    break;
                case "DethBoss":

                    break;
                case "Killer":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Killer");
                        labyrinth[heroYPossible][heroXPossible] = "Killer";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Killer");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "InvisibleTrap":
                    HeroStatus.heroStepOnCell("InvisibleTrap");
                    break;
                case "Assassin":
                    if (HeroIndicators.HeroGold() > 60) {
                        HeroStatus.heroStepOnCell("Assassin");
                        labyrinth[heroYPossible][heroXPossible] = "Ground";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Assassin");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "AverageTreatmentPotion":
                    HeroStatus.heroStepOnCell("AverageTreatmentPotion");
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "BagOfGold":
                    HeroStatus.heroStepOnCell("BagOfGold");
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "Champion":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Champion");
                        labyrinth[heroYPossible][heroXPossible] = "Champion";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Champion");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "DamnEarth":
                    HeroStatus.heroStepOnCell("DamnEarth");
                    break;
                case "DeadMan":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("DeadMan");
                        labyrinth[heroYPossible][heroXPossible] = "DeadMan";
                    }
                    else {
                        HeroStatus.heroStepOnCell("DeadMan");
                        labyrinth[heroYPossible][heroXPossible] = "DecomposedCorpse";
                    }
                    break;
                case "DecomposedCorpse":
                    HeroStatus.heroStepOnCell("DecomposedCorpse");
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "Draconian":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Draconian");
                        labyrinth[heroYPossible][heroXPossible] = "Draconian";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Draconian");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "Dragon":
                    if (HeroIndicators.HeroGold() > 100) {
                        HeroStatus.heroStepOnCell("Dragon");
                        labyrinth[heroYPossible][heroXPossible] = "Dragon";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Dragon");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "Elf":
                    HeroStatus.heroStepOnCell("Elf");
                    labyrinth[heroYPossible][heroXPossible] = "Rip";
                    break;
                case "ExperiencedWarrior":
                    HeroStatus.heroStepOnCell("ExperiencedWarrior");
                    labyrinth[heroYPossible][heroXPossible] = "Rip";
                    break;
                case "Goblin":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Goblin");
                        labyrinth[heroYPossible][heroXPossible] = "Goblin";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Goblin");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "Mutant":
                    HeroStatus.heroStepOnCell("Mutant");
                    labyrinth[heroYPossible][heroXPossible] = "Rip";
                    break;
                case "Robot":
                    if (HeroIndicators.GetInvisible() > 0) {
                        HeroStatus.heroStepOnCell("Robot");
                        labyrinth[heroYPossible][heroXPossible] = "Robot";
                    }
                    else {
                        HeroStatus.heroStepOnCell("Robot");
                        labyrinth[heroYPossible][heroXPossible] = "Rip";
                    }
                    break;
                case "SmallPotionTreatment":
                    HeroStatus.heroStepOnCell("SmallPotionTreatment");
                    labyrinth[heroYPossible][heroXPossible] = "Ground";
                    break;
                case "SwampCreature":
                    HeroStatus.heroStepOnCell("SwampCreature");
                    labyrinth[heroYPossible][heroXPossible] = "Rip";
                    break;
            }
            $('#end').click(function () {
                $('.Choice').hide();
                $('.drawer').show();
            });
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