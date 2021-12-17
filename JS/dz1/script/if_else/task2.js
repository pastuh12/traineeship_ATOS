'use strict';
let button2_1 = document.getElementById("task2.1");
let button2_2 = document.getElementById("task2.2");

function enterAge(){
    let answer = '';
    answer = prompt('Введите ваш возраст', '20') > checkAge ? 'Взрослый' : 'Ребенок !';
    alert(`Вы: ${answer}`);
}

function rewrittenCode(){
    let data = '';
    let role = '';
    
    role = prompt('введите вашу роль: ', 'Student');
    data = role === 'Admin' ? 'Admin access level'
                            : role === 'Teacher' ? 'Teacher access level'
                            : role === 'Student' ? 'Student access level'
                            : 'Access denied'; 
    alert(data);
}

button2_1.addEventListener('click', enterAge);
button2_2.addEventListener('click', rewrittenCode);