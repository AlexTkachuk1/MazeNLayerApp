var HeroIndicators = (function () {

    var HasGiganHammer;
    var Invisible;
    var CanJumpValue;
    var HeroHP;
    var HeroGold;
    var Stamina;

    var Update = (async function () {
        var value = null;
        const requestURL = 'https://localhost:44328/Maze/HeroIndicators';

        var response = await fetch(requestURL);

        if (response.ok) { // если HTTP-статус в диапазоне 200-299
            // получаем тело ответа (см. про этот метод ниже)
            value = await response.json();
            HasGiganHammer = value.hasGiganHammer;
            Invisible = value.invisible;
            CanJumpValue = value.canJump;
            HeroHP = value.hp;
            HeroGold = value.gold;
            Stamina = value.stamina
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

    function GetHasGiganHammer() {
        return HasGiganHammer;
    }
    function CanJumpValue() {
        return CanJumpValue;
    }

    function DisplayIndicators(value) {
        var mainBlock = $("div.heroIndicators");
        oldBlock = $('div').remove('.heroStatus');
        var status = $('<div>');
        status.addClass('heroStatus');




        var statusIconForHp = $('<div>');
        statusIconForHp.addClass('statusIcon');

        var statusIconForMyHp = $('<div>');
        statusIconForMyHp.addClass('statusIconForMyHp');

        var Hp = $('<span>');
        Hp.addClass("status Hp");
        Hp.addClass("status");
        statusIconForMyHp.append(Hp);
        statusIconForHp.append(statusIconForMyHp);

        var HpValue = $('<h1>');
        HpValue.addClass('HpValue');
        HpValue.addClass("text");
        HpValue.text(value.hp);
        statusIconForHp.append(HpValue);

        status.append(statusIconForHp);






        var statusIconForArmor = $('<div>');
        statusIconForArmor.addClass('statusIcon');

        var Armor = $('<span>');
        Armor.addClass("status Armor");
        Armor.addClass("status");
        statusIconForArmor.append(Armor);

        var ArmorValue = $('<h1>');
        ArmorValue.addClass('ArmorValue');
        ArmorValue.addClass('text');
        ArmorValue.text(value.armor);
        statusIconForArmor.append(ArmorValue);

        status.append(statusIconForArmor);



        var statusIconForStamina = $('<div>');
        statusIconForStamina.addClass('statusIcon');

        var Stamina = $('<span>');
        Stamina.addClass("status Stamina");
        Stamina.addClass("status");
        statusIconForStamina.append(Stamina);

        var StaminaValue = $('<h1>');
        StaminaValue.addClass('StaminaValue');
        StaminaValue.addClass('text');
        StaminaValue.text(value.stamina);
        statusIconForStamina.append(StaminaValue);

        status.append(statusIconForStamina);


        

        var statusIconForGold = $('<div>');
        statusIconForGold.addClass('statusIcon');

        var Gold = $('<span>');
        Gold.addClass("status Gold");
        Gold.addClass("status");
        statusIconForGold.append(Gold);

        var GoldValue = $('<h1>');
        GoldValue.addClass('GoldValue');
        GoldValue.addClass('text');
        GoldValue.text(value.gold);
        statusIconForGold.append(GoldValue);

        status.append(statusIconForGold);


        var statusForAbilitiPower = $('<div>');
        statusForAbilitiPower.addClass('statusForAbilitiPower');

        var statusIconForDamage = $('<div>');
        statusIconForDamage.addClass('statusIcon');

        var Damage = $('<span>');
        Damage.addClass("status Damage");
        Damage.addClass("status");
        statusIconForDamage.append(Damage);

        var DamageValue = $('<h1>');
        DamageValue.addClass('DamageValue');
        DamageValue.addClass('text');
        DamageValue.text(value.damage);
        statusIconForDamage.append(DamageValue);

        statusForAbilitiPower.append(statusIconForDamage);



        

        var statusIconInvisible = $('<div>');
        statusIconInvisible.addClass('statusIcon');

        var Invisible = $('<span>');
        Invisible.addClass("status Invisible");
        Invisible.addClass("status");
        statusIconInvisible.append(Invisible);

        var InvisibleValue = $('<h1>');
        InvisibleValue.addClass('InvisibleValue');
        InvisibleValue.addClass('text');
        InvisibleValue.text(value.invisible);
        statusIconInvisible.append(InvisibleValue);

        statusForAbilitiPower.append(statusIconInvisible);



        var statusIconHasGiganHammer = $('<div>');
        statusIconHasGiganHammer.addClass('statusIcon');

        var HasGiganHammer = $('<span>');
        HasGiganHammer.addClass("status HasGiganHammer");
        HasGiganHammer.addClass("status");
        statusIconHasGiganHammer.append(HasGiganHammer);

        var HasGiganHammerValue = $('<h1>');
        HasGiganHammerValue.addClass('HasGiganHammerValue');
        HasGiganHammerValue.addClass('text');
        HasGiganHammerValue.text(value.hasGiganHammer);
        statusIconHasGiganHammer.append(HasGiganHammerValue);

        statusForAbilitiPower.append(statusIconHasGiganHammer);


        var statusIconCanJump = $('<div>');
        statusIconCanJump.addClass('statusIcon');

        var CanJump = $('<span>');
        CanJump.addClass("status CanJump");
        CanJump.addClass("status");
        statusIconCanJump.append(CanJump);

        var CanJumpValue = $('<h1>');
        CanJumpValue.addClass('CanJumpValue');
        CanJumpValue.addClass('text');
        CanJumpValue.text(value.canJump);
        statusIconCanJump.append(CanJumpValue);

        statusForAbilitiPower.append(statusIconCanJump);

        status.append(statusForAbilitiPower);

        mainBlock.append(status);
    }
    function HeroHP() {
        return HeroHP;
    }
    function HeroGold() {
        return HeroGold;
    }
    function HeroStamina() {
        return Stamina;
    }
    return {
        Update: Update,
        DisplayIndicators: DisplayIndicators,
        GetHasGiganHammer: GetHasGiganHammer,
        GetInvisible: GetInvisible,
        GetCanJumpValue: CanJumpValue,
        HeroHP: HeroHP,
        HeroGold: HeroGold,
        HeroStamina: HeroStamina
    };
})();

HeroIndicators.Update();