var HeroIndicators = (function () {

    var Update = (async function () {
        var value = null;
        const requestURL = 'https://localhost:44328/Maze/HeroIndicators';

        var response = await fetch(requestURL);

        if (response.ok) { // если HTTP-статус в диапазоне 200-299
            // получаем тело ответа (см. про этот метод ниже)
            value = await response.json();
            HeroIndicators.DisplayIndicators(value);
        } else {
            alert("Ошибка HTTP: " + response.status);
        }
    });

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

        mainBlock.append(status);
    }

    return {
        Update: Update,
        DisplayIndicators: DisplayIndicators
    };
})();

HeroIndicators.Update();