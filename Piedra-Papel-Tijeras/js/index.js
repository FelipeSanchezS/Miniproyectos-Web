//Creamos las variables

let playerScore = 0;
let computerScore = 0;

//Creamos función de lógica de juego

function playGame(userChoice){
    //elige las opciones de forma aleatoria
    const choices = ['piedra', 'papel', 'tijera'];
    const computerChoice = choices[Math.floor(Math.random()*3)];

    let result = '';
    if(userChoice == computerChoice){
        result = 'Han sacado lo mismo, es un empate de '+userChoice;
    }
    else if((userChoice == 'piedra' && computerChoice == 'tijera') ||
            (userChoice == 'tijera' && computerChoice == 'papel') ||
            (userChoice == 'papel' && computerChoice == 'piedra') ){
                result = 'Haz ganado la ronda con '+userChoice+' contra '+computerChoice;
                playerScore++;
    }
    else{
        result = 'Haz perdido con '+userChoice+' contra '+computerChoice;
        computerScore++;
    }

    //Enlazamos a nuestro HTML y ponemos el contenido de la variable result
    document.getElementById('result').textContent = result;
    document.getElementById('score').textContent = 'Jugador: '+playerScore+ ' | Computadora: '+computerScore;

    //lógica para acabar el juego
    if(playerScore == 3 || computerScore == 3){
        endGame();
    }
}

//función de acabar el juego
function endGame(){
    const finalResult = playerScore == 3 ? 'Felicidades, haz ganado' : 'lo siento, haz perdido';
    document.getElementById('result').textContent = finalResult;

    //Aca deshabilitamos los botones cuando est en  3
    document.getElementById('btnPiedra').disabled = true;
    document.getElementById('btnPapel').disabled = true;
    document.getElementById('btnTijera').disabled = true;
}