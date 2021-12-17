'use strict';
let button3 = document.getElementById("task3");
let goodAnswer = 'Ваш браузер поддерживается';
let ифвAnswer = 'Ваш браузер не поддерживается';

function enterBrowser(){
    let data = '';
    let answer = '';
    data = prompt('Введите ваш браузер', 'Google');
    switch (data){
        case 'Google':
        case 'Opera':
        case 'Yandex':
        case 'FireFox':
        case 'Safari':
            answer = goodAnswer + ' ' + data;
            break;
        default:
            answer = badAnswer + ' ' + data;
            break;
    }
    alert(answer);
}

button3.addEventListener('click', enterBrowser);