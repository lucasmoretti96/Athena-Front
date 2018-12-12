/*A função quando ativada pelo botão, alterna entre as 3 variáveis declaradas abaixo e definando seu display*/

function newUser() {
    if (document.getElementById('box2').style.display === 'none') {
        document.getElementById('box2').style.display = 'block';
        document.getElementById('box1').style.display = 'none';
    }
 
}

function cancelEdit() {
    if (document.getElementById('box1').style.display === 'none' && document.getElementById('box3').style.display === 'block') {
        document.getElementById('box1').style.display = 'block';
        document.getElementById('box3').style.display = 'none';
    }
    
}

function cancelUser() {
    if (document.getElementById('box1').style.display === 'none' && document.getElementById('box2').style.display === 'block') {
        document.getElementById('box1').style.display = 'block';
        document.getElementById('box2').style.display = 'none';
    }
}

function cancelDelete() {
    if (document.getElementById('box1').style.display === 'none' && document.getElementById('box4').style.display === 'block') {
        document.getElementById('box1').style.display = 'block';
        document.getElementById('box4').style.display = 'none';
    }

}

function cancelAddMachine() {
    if (document.getElementById('box1').style.display === 'none' && document.getElementById('box5').style.display === 'block') {
        document.getElementById('box1').style.display = 'block';
        document.getElementById('box5').style.display = 'none';
    }

}


function userEdit() {
    if (document.getElementById('box3').style.display === 'none') {
        document.getElementById('box3').style.display = 'block';
        document.getElementById('box1').style.display = 'none';
    }
    
}   

function userDelete() {
    if (document.getElementById('box4').style.display === 'none') {
        document.getElementById('box4').style.display = 'block';
        document.getElementById('box1').style.display = 'none';
    }
}   

function userView() {
    if (document.getElementById('box5').style.display === 'none') {
        document.getElementById('box5').style.display = 'block';
        document.getElementById('box1').style.display = 'none';
    }
}   
