//Establecemos variables
let displayValue = '';
let currentOperation = null;
let firstOperand = null;

//Función para agregar numero en la pantalla
function appendNumber(number){
    displayValue += number;
    updateDisplay();
}

//establecemos la operación
function setOperation(operation){
    if(currentOperation != null){
        calculate();
    }
    firstOperand = parseFloat(displayValue);
    currentOperation = operation;
    displayValue = '';
}

// función para calcular y obtener segundo numero ingresado
function calculate(){
    if(currentOperation == null || displayValue == ''){
        return;
    }
    const secondOperand = parseFloat(displayValue);
    switch(currentOperation){
        case '+':
            displayValue = (firstOperand + secondOperand).toString();
            break;
        case '-':
            displayValue = (firstOperand - secondOperand).toString();
            break;
        case '*':
            displayValue = (firstOperand * secondOperand).toString();
            break;
        case '/':
            if(firstOperand == 0){
                alert('No se puede dividir entre 0')
            }
            displayValue = (firstOperand / secondOperand).toString();
            break;
    }
}

