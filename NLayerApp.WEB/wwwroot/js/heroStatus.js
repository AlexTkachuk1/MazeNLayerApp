var HeroStatus = (function () {

    async function heroStepOnCell(cellTypeName) {

        // данные для отправки
        const user = cellTypeName;

        const xhr = new XMLHttpRequest();
        // POST-запрос к ресурсу /user
        xhr.open("POST", "https://localhost:44328/Maze/HeroStepOnCell?Name="+user);

        // обработчик получения ответа сервера
        xhr.onload = () => {
            if (xhr.status == 200) {
                console.log(xhr.responseText);
          } else {
                console.log("Server response: ", xhr.statusText);
            }
        };
        xhr.send(user);
    }
    return {
        heroStepOnCell: heroStepOnCell,
    };
})();