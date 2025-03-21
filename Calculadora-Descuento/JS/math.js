
////////////////////////////////////////////////////////

function calcularPrecio() {
    const precio = parseFloat(document.getElementById('precio').value);
    const descuento = parseFloat(document.getElementById('descuento').value);
    
    if (!isNaN(precio) && !isNaN(descuento)) {
        const precioFinal = precio - (precio * (descuento / 100));
        document.getElementById('resultado').value = precioFinal.toFixed(2);
    } else {
        alert("Por favor, ingresa valores válidos.");
    }
}