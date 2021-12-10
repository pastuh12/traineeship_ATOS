'use strict';
let button1 = document.getElementById("task1");
let word1 = 'срочно', word2 = 'безотлагательный', word3 = 'деньги';

function enterMessange(){
    let messange = '';
    messange = prompt('введите сообщение', 'Ваше письмо');
    if(messange.includes(' ' + word1 + ' ')
     || messange.includes(' ' + word2 + ' ')
     || messange.includes(' ' + word3 + ' ')){
        alert('Данное сообщение подозрительно');
    } else {
        alert('Сообщение не подозрительное');
    }

    if(messange.length > 20){
        alert(messange.slice(0, 20) + '...');
    } else {
        alert(messange);
    }
}

button1.addEventListener('click', enterMessange);
