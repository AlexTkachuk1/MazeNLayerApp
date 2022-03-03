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

    function BuildHpIcon(value) {
        var statusIconForHp = $('<div>');
        statusIconForHp.addClass('statusIcon');

        var Hp = $('<span>');
        Hp.addClass("status Hp");
        Hp.addClass("status");
        statusIconForHp.append(Hp);

        var HpValue = $('<h1>');
        HpValue.addClass('HpValue');
        HpValue.addClass("text");
        HpValue.text(value.hp);
        statusIconForHp.append(HpValue);
        return statusIconForHp;
    }

    function BuildArmorIcon(value) {
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
        return statusIconForArmor;
    }

    function BuildStaminaIcon(value) {
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
        return statusIconForStamina;
    }

    function BuildGoldIcon(value) {
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
        return statusIconForGold;
    }

    function BuildDamageIcon(value) {
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
        return statusIconForDamage;
    }

    function BuildInvisibleIcon(value) {
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
        return statusIconInvisible;
    }

    function BuildHasGiganHammerIcon(value) {
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
        return statusIconHasGiganHammer;
    }

    function BuildCanJumpIcon(value) {
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
        return statusIconCanJump;
    }

    function DisplayIndicators(value) {
        var mainBlock = $("div.heroIndicators");
        oldBlock = $('div').remove('.heroStatus');
        var status = $('<div>');
        status.addClass('heroStatus');

        // Создание иконки для HP
        var statusIconForHp = BuildHpIcon(value);
        status.append(statusIconForHp);

        // Создание иконки для Armor
        var statusIconForArmor = BuildArmorIcon(value);
        status.append(statusIconForArmor);

        // Создание иконки для Stamina
        var statusIconForStamina = BuildStaminaIcon(value);
        status.append(statusIconForStamina);

        // Созлание иконки для Gold
        var statusIconForGold = BuildGoldIcon(value);
        status.append(statusIconForGold);

        
        var statusForAbilitiPower = $('<div>');
        statusForAbilitiPower.addClass('statusForAbilitiPower');

        // Созлание иконки для Damage
        var statusIconForDamage = BuildDamageIcon(value);
        statusForAbilitiPower.append(statusIconForDamage);

        // Созлание иконки для Invisible
        var statusIconInvisible = BuildInvisibleIcon(value);
        statusForAbilitiPower.append(statusIconInvisible);

        // Созлание иконки для HasGiganHammer
        var statusIconHasGiganHammer = BuildHasGiganHammerIcon(value);
        statusForAbilitiPower.append(statusIconHasGiganHammer);

        // Созлание иконки для CanJump
        var statusIconCanJump = BuildCanJumpIcon(value);
        statusForAbilitiPower.append(statusIconCanJump);

        status.append(statusForAbilitiPower);

        mainBlock.append(status);
    }

    return {
        Update: Update,
        DisplayIndicators: DisplayIndicators,
        GetHasGiganHammer: function () { return HasGiganHammer; },
        GetInvisible: function () { return Invisible; },
        GetCanJumpValue: function () { return CanJumpValue; },
        HeroHP: function () { return HeroHP; },
        HeroGold: function () { return HeroGold; },
        HeroStamina: function () { return Stamina; }
    };
})();

HeroIndicators.Update();