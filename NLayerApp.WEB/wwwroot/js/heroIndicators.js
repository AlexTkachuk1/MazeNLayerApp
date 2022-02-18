var HeroIndicators = (function () {

    var HasGiganHammer;
    var Invisible;

    var Update = (async function () {
        var value = null;
        const requestURL = 'https://localhost:44328/Maze/HeroIndicators';

        var response = await fetch(requestURL);

        if (response.ok) { // если HTTP-статус в диапазоне 200-299
            // получаем тело ответа (см. про этот метод ниже)
            value = await response.json();
            HasGiganHammer = value.hasGiganHammer;
            Invisible = value.invisible;
            if (value.gameOver) {
                window.location = "https://localhost:44328/Maze/GameOver";
            }
            HeroIndicators.DisplayIndicators(value);
        } else {
            alert("Ошибка HTTP: " + response.status);
        }
    });

    function GetInvisible() {
        return Invisible;
    }

    function GetHasGiganHammer()
    {
        return HasGiganHammer;
    }

    function DisplayIndicators(value) {
        var mainBlock = $("div.heroIndicators");
        oldBlock = $('div').remove('.heroStatus');
        var status = $('<div>');
        status.addClass('heroStatus');

        var Hp = $('<span>');
        Hp.addClass("status Hp");
        status.append(Hp);

        var HpValue = $('<span>');
        HpValue.addClass(HpValue);
        HpValue.text(value.hp);
        status.append(HpValue);

        var Gold = $('<span>');
        Gold.addClass("status Gold");
        status.append(Gold);

        var GoldValue = $('<span>');
        GoldValue.addClass(GoldValue);
        GoldValue.text(value.gold);
        status.append(GoldValue);

        var Damage = $('<span>');
        Damage.addClass("status Damage");
        status.append(Damage);

        var DamageValue = $('<span>');
        DamageValue.addClass(DamageValue);
        DamageValue.text(value.damage);
        status.append(DamageValue);

        var Armor = $('<span>');
        Armor.addClass("status Armor");
        status.append(Armor);

        var ArmorValue = $('<span>');
        ArmorValue.addClass(ArmorValue);
        ArmorValue.text(value.armor);
        status.append(ArmorValue);

        var Invisible = $('<span>');
        Invisible.addClass("status Invisible");
        status.append(Invisible);

        var InvisibleValue = $('<span>');
        InvisibleValue.addClass(InvisibleValue);
        InvisibleValue.text(value.invisible);
        status.append(InvisibleValue);

        var HasGiganHammer = $('<span>');
        HasGiganHammer.addClass("status HasGiganHammer");
        status.append(HasGiganHammer);

        var HasGiganHammerValue = $('<span>');
        HasGiganHammerValue.addClass(HasGiganHammerValue);
        HasGiganHammerValue.text(value.hasGiganHammer);
        status.append(HasGiganHammerValue);

        mainBlock.append(status);
    }

    return {
        Update: Update,
        DisplayIndicators: DisplayIndicators,
        GetHasGiganHammer: GetHasGiganHammer,
        GetInvisible: GetInvisible
    };
})();

HeroIndicators.Update();