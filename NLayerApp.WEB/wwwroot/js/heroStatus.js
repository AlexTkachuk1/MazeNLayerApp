var HeroStatus = (function () {

    function heroStepOnCell(cellTypeName) {

        // данные для отправки
        const user = cellTypeName;

        const xhr = new XMLHttpRequest();
        // POST-запрос к ресурсу /user
        xhr.open("POST", "https://localhost:44328/Maze/HeroStepOnGold?Name="+user);

        // обработчик получения ответа сервера
        xhr.onload = () => {
            if (xhr.status == 200) {
                console.log(xhr.responseText);
          } else {
                console.log("Server response: ", xhr.statusText);
            }
        };
        xhr.send(user);

        //var cellTypeName = JSON.stringify(cellTypeName);
        //$.ajax({
        //    url: "/Maze/HeroStepOnGold/",
        //    method: "POST",
        //    contentType: 'application/json',
        //    data: cellTypeName,
        //    success: function (response) {
        //        console.log(response);
        //    }
        //});
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

    return {
        heroStepOnCell: heroStepOnCell,
        SaveHeroStatusСhanges: saveHeroStatusСhanges
    };
})();