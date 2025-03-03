// Creamos variables y arreglos necesarios
let events =[]; 
let arr = []; 
const eventName = document.querySelector("#eventName"); 
const eventDate = document.querySelector("#eventDate"); 
const buttonAdd = document.querySelector("#bAdd"); 
const eventsContainer = document.querySelector("#eventsContainer"); 

const json = load(); // Llama a la función 'load' para obtener los datos almacenados en el localStorage.
try {
    arr = JSON.parse(json); // Intenta parsear los datos JSON almacenados en localStorage a un array.
} catch (error) {
    arr = []; // Si hay un error (por ejemplo, si los datos no están bien formateados), asigna un array vacío.
}

events = arr ? [...arr] : []; // Si 'arr' tiene contenido (es decir, no es null ni undefined), copia su contenido en 'events'. Si no, asigna un array vacío.

renderEvents(); // Llama a la función 'renderEvents' para mostrar los eventos en la interfaz.

document.querySelector("form").addEventListener("submit", (e) => { 
    e.preventDefault(); // Previene la acción predeterminada del formulario (que sería recargar la página).
    addEvent(); // Llama a la función 'addEvent' para agregar un nuevo evento.
});

buttonAdd.addEventListener("click", (e) => { 
    e.preventDefault(); // Previene la acción predeterminada del botón (que también recargaría la página).
    addEvent(); // Llama a la función 'addEvent' para agregar un nuevo evento.
});

function addEvent() {
    if (eventName.value === "" || eventDate.value === "") {
        return; // Si el campo 'nombre del evento' o 'fecha' están vacíos, no agrega el evento.
    }
    if (dateDiff(eventDate.value) < 0) {
        return; // Si la fecha del evento es en el pasado, no agrega el evento.
    }
    
    const newEvent = {
        id: (Math.random() * 100).toString(36).slice(3), // Genera un id único para el evento (usando un número aleatorio).
        name: eventName.value, // Asigna el valor del campo 'eventName' al nombre del evento.
        date: eventDate.value // Asigna el valor del campo 'eventDate' a la fecha del evento.
    };
    
    events.unshift(newEvent); // Agrega el nuevo evento al principio del array 'events'.
    save(JSON.stringify(events)); // Guarda los eventos en el localStorage después de convertirlos a formato JSON.
    eventName.value = ""; // Limpia el campo de nombre del evento.
    renderEvents(); // Vuelve a renderizar los eventos para mostrar el nuevo.
}

function dateDiff(d) {
    const targetDate = new Date(d); // Crea un objeto Date con la fecha proporcionada.
    const today = new Date(); // Crea un objeto Date con la fecha y hora actual.
    const difference = targetDate.getTime() - today.getTime(); // Calcula la diferencia en milisegundos entre las dos fechas.
    const days = Math.ceil(difference / (1000 * 3600 * 24)); // Convierte la diferencia de milisegundos a días.
    return days; // Devuelve la diferencia en días.
}

function renderEvents() {
    const eventsHTML = events.map((event) => { // Mapea el array de eventos y genera el HTML correspondiente.
        return `
        <div class="task">
            <div class="days">
                <span class="days-number">${dateDiff(event.date)}</span>
                <span class="days-text">días</span>
            </div>

            <div class="event-name">${event.name}</div>
            <div class="event-date">${event.date}</div>
            <div class="actions">
            <button class="bDelete" data-id="${event.id}">Eliminar</button>
            </div>
        </div>`;
    });

    eventsContainer.innerHTML = eventsHTML.join(""); // Inserta el HTML generado dentro del contenedor 'eventsContainer'.
    
    // Asocia un evento de click a cada botón "Eliminar" para eliminar un evento.
    document.querySelectorAll(".bDelete").forEach(button => {
        button.addEventListener("click", e => {
            const id = button.getAttribute("data-id"); // Obtiene el id del evento a eliminar.
            events = events.filter(event => event.id != id); // Filtra el evento con ese id del array 'events'.
            save(JSON.stringify(events)); // Guarda los eventos actualizados en el localStorage.
            renderEvents(); // Vuelve a renderizar los eventos para reflejar la eliminación.
        });
    });
}

function save(data) {
    localStorage.setItem("items", data); // Guarda los datos en localStorage bajo la clave "items".
}

function load() {
    return localStorage.getItem("items"); // Obtiene los datos almacenados en localStorage bajo la clave "items".
}
