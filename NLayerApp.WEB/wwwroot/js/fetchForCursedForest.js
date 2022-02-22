﻿$(document).ready(function () {
    var Fetch = (async function () {
        var value = null;
        const requestURL = 'https://localhost:44328/Maze/MazeDataForCursedForest';

        var response = await fetch(requestURL);

        if (response.ok) { // если HTTP-статус в диапазоне 200-299
            // получаем тело ответа (см. про этот метод ниже)
            value = await response.json();
            Site.Init(value);
        } else {
            alert("Ошибка HTTP: " + response.status);
        }
    })();
});