document.getElementById('todoForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Evita que el formulario se envíe de la manera tradicional

    var tarea = document.querySelector('input[name="tarea"]').value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "coBase.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onload = function() {
        if (xhr.status == 200) {
            // Muestra un mensaje si la tarea fue añadida correctamente
            alert(xhr.responseText);
        }
    };

    xhr.send("tarea=" + encodeURIComponent(tarea));
});