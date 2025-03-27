class product{
    constructor(name, price, year){
        this.name = name;
        this.price = price;
        this.year = year;
    }
}

class ui{
    addproduct(){

    }

    deleteproduct(){

    }

    showmessage(){
        
    }
}

//Elementos del DOM
//Aca cuando se envían los elementos en el form
document.getElementById('product-form')
    .addEventListener('submit', function(e){ 
        alert('Enviando formulario')
        const name = document.getElementById('name').value;
        const price = document.getElementById('price').value;
        const year = document.getElementById('year').value;

        const product = new product(name, price, year)

        


        e.preventDefault();
});