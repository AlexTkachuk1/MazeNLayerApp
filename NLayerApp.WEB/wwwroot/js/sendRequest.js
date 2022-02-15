const requestURL = 'https://localhost:44328/Maze/MazeDataForJs';

function sendRequest(metod, url) {
    return new Promise((resolved, reject) => {
        const xhr = new XMLHttpRequest();
        xhr.open(metod, url);
        xhr.responseType = 'json';


        xhr.onload = () => {
            if (xhr.status >= 400) {
                reject(xhr.response)
            } else {
                resolved(xhr.response)
            }
        }

        xhr.onerror = () => {
            reject(xhr.response)
        }
        xhr.send();
    })
}
var value = null;
sendRequest('GET', requestURL)
    .then(data => value = data)
    .catch(err => console.log(err))

