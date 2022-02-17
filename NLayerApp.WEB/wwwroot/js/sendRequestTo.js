var Request = (function () {

    function toMazeDataForJs()
    {
        const requestURL = 'https://localhost:44328/Maze/MazeDataForJs';
        var value = null;
        SendRequest.sendRequest('GET', requestURL)
            .then(data => value = data)
            .catch(err => console.log(err))
        return value;
    }

    function toGetBaseLabyrinth() {
        const requestURL = 'https://localhost:44328/Maze/GetBaseLabyrinth';
        var value = null;
        SendRequest.sendRequest('GET', requestURL)
            .then(data => value = data)
            .catch(err => console.log(err))
        return value;
    }

    return {
        ToMazeDataForJs: toMazeDataForJs,
        ToGetBaseLabyrinth: toGetBaseLabyrinth
    };
})();