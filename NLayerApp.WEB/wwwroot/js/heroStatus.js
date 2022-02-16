var HeroStatus = (function () {

    var hero = {};

    function createHeroStatus(value)
    {
        hero.cordinateX = value.hero.cordinateX;
        hero.cordinateY = value.hero.cordinateY;
        hero.Damage = value.hero.Damage;
        hero.Gold = value.hero.Gold;
        hero.HP = value.hero.HP;
        hero.Stamina = value.hero.Stamina;
        hero.Inventory = [];
        for (var i = 0; i < value.hero.inventory.length; i++) {
            hero.Inventory.push(value.hero.inventory[i])
        }
    }

    function updateHeroStatus(value)
    {
        var hero
        hero.Damage
        value.hero.cordinateX = Labirint.getHeroX();
        value.hero.cordinateY = Labirint.getHeroY();
    }

    function saveHeroStatusСhanges(value)
    {
        
    }













    return {
        SaveHeroStatusСhanges: saveHeroStatusСhanges,
        CreateHeroStatus: createHeroStatus,
        UpdateHeroStatus: updateHeroStatus
    };
})();