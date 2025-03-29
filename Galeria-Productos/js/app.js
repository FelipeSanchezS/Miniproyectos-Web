class Product {
    constructor(name, price, year) {
        this.name = name;
        this.price = price;
        this.year = year;
    }
}

class UI {
    addproduct(product) {
        const productlist = document.getElementById("product-list");
        const element = document.createElement("div");
        element.innerHTML = `
            <div class="card text-center mb-4">
                <div class="card-body">
                    <strong>Producto</strong>: ${product.name} - 
                    <strong>Precio</strong>: ${product.price} - 
                    <strong>Año</strong>: ${product.year}
                    <button class="btn btn-danger btn-sm delete">Eliminar</button>
                </div>
            </div>
        `;
        productlist.appendChild(element);

        // Agregar evento para eliminar productos
        element.querySelector(".delete").addEventListener("click", function () {
            element.remove();
        });
    }
}

// Captura del evento submit
document.getElementById("product-form").addEventListener("submit", function (e) {
    e.preventDefault(); // Evita la recarga de la página

    const name = document.getElementById("name").value;
    const price = document.getElementById("price").value;
    const year = document.getElementById("year").value;

    if (name === "" || price === "" || year === "") {
        alert("Por favor, llena todos los campos.");
        return;
    }

    const product = new Product(name, price, year);

    // Agregar producto a la interfaz
    const ui = new UI();
    ui.addproduct(product);

    // Limpiar formulario
    document.getElementById("product-form").reset();
});
