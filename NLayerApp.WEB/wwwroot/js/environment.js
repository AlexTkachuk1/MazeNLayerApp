var Environment = (function () {

    var environment = ["barrel", "tree", "tree1", "tree2", "tree3", "tree4", "tree5", "tree6"
        , "tree7", "tree8", "fence", "fence2", "fence3", "stone", "stone1", "stone2", "stone3"
        , "stone4", "stone5", "stone6", "bush", "bush1", "stub", "bush2", "stub1", "stub2", "flower", "flower1"
        , "flower2", "flower3", "flower4"];


    function GetEnvironment() {
        return environment;
    }


    return {
        GetEnvironment: GetEnvironment
    };
})();