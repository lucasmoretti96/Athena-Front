/*A função quando ativada pelo botão, alterna entre as 3 variáveis declaradas abaixo e definando seu display*/

function newUser() {
    if (document.getElementById('box2').style.display == 'none') {
        document.getElementById('box2').style.display = 'block';
        document.getElementById('box1').style.display = 'none';
    }
    return false;
}

function cancelEdit() {
    if (document.getElementById('box1').style.display == 'none' && document.getElementById('box3').style.display =='block') {
        document.getElementById('box1').style.display = 'block';
        document.getElementById('box3').style.display = 'none';
    }
    return false;
}

function cancelUser() {
    if (document.getElementById('box1').style.display == 'none' && document.getElementById('box2').style.display == 'block') {
        document.getElementById('box1').style.display = 'block';
        document.getElementById('box2').style.display = 'none';
    }
    return false;
}   

function userEdit() {
    if (document.getElementById('box3').style.display == 'none') {
        document.getElementById('box3').style.display = 'block';
        document.getElementById('box1').style.display = 'none';
    }
    return false;
}   