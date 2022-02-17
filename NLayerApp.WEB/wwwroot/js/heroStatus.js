var HeroStatus = (function () {

    var hero = {};
    //function createHeroStatusFromAjax() {
    //    var heroData = HeroStatus.Fetch();
        
    //    hero.cordinateX = heroData.cordinateX;
    //    hero.cordinateY = heroData.cordinateY;
    //    hero.damage = heroData.damage;
    //    hero.gold = heroData.gold;
    //    hero.hp = heroData.hp;
    //    hero.stamina = heroData.stamina;
    //    hero.inventory = [];
    //    for (var i = 0; i < value.hero.inventory.length; i++) {
    //        hero.inventory.push(value.hero.inventory[i])
    //    }
        
    //    return hero;
    //}
    function createHeroStatus(value) {
        hero.cordinateX = value.hero.cordinateX;
        hero.cordinateY = value.hero.cordinateY;
        hero.damage = value.hero.damage;
        hero.gold = value.hero.gold;
        hero.hp = value.hero.hp;
        hero.stamina = value.hero.stamina;
        hero.inventory = [];
        for (var i = 0; i < value.hero.inventory.length; i++) {
            hero.inventory.push(value.hero.inventory[i])
        }
        return hero;
    }

    function updateHeroStatus(value) {
        var hero
        hero.Damage
        value.hero.cordinateX = Labirint.getHeroX();
        value.hero.cordinateY = Labirint.getHeroY();
    }
    function addGold(number) {
        hero.Gold += number;
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

    function getHero() {
        return hero;
    }

    return {
        Fetch: fetch,
        AddGold: addGold,
        GetHero: getHero,
        SaveHeroStatusСhanges: saveHeroStatusСhanges,
        CreateHeroStatus: createHeroStatus,
        UpdateHeroStatus: updateHeroStatus
    };
})();