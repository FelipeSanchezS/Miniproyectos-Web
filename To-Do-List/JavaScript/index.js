const inputBox = document.getElementById('input-box');
const listContainer = document.getElementById('list-container');
const eliminar = document.getElementById('eliminar');

//Agrega tarea
function addTask(){
    if(inputBox.value === ''){
        alert('Debes ingresar una tarea');
    }
    else{
        let li = document.createElement("li");
        li.innerHTML = inputBox.value;
        listContainer.appendChild(li);
        let span = document.createElement("span");
        span.innerHTML = "\u00d7";
        li.appendChild(span);
    }
    inputBox.value = '';
    saveData();
}

//funcion para marcas como hechas las tareas o liminarlas
listContainer.addEventListener("click", function(e){
    if(e.target.tagName === "LI"){
        e.target.classList.toggle("checked");
        saveData();
    }
    else if(e.target.tagName === "SPAN"){
        e.target.parentElement.remove();
        saveData();
    }
}, false);

//funcion de guardar datos
function saveData(){
    localStorage.setItem('data', listContainer.innerHTML);
}

//funcion para mostrar tareas guardadas
function showTask(){
    listContainer.innerHTML = localStorage.getItem("data");
}
showTask();

//Funcion para eliminar todo el contenido
eliminar.addEventListener('click', function() {
    listContainer.innerHTML = '';  // Vaciamos el contenedor de tareas
    localStorage.removeItem('data');  // Borramos los datos de localStorage
});