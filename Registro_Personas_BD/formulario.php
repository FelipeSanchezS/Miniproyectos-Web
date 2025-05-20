<?php include 'bases.php'; ?>

<h2>Formulario de Personas</h2>
<form action="insertar.php" method="POST">
    <label for="">Nombre</label>
    <input type="text" name="nombre" placeholder="Nombre" required><br>
    <label for="">Apellido</label>
    <input type="text" name="apellido" placeholder="Apellido" required><br>
    <label for="">Email</label>
    <input type="email" name="email" placeholder="Correo" required><br>
    <label for="">Teléfono</label>
    <input type="text" name="telefono" placeholder="Teléfono" required><br>
    <label for="">Dirección</label>
    <input type="text" name="direccion" placeholder="Dirección" required><br>
    <label for="">Fecha nacimiento</label>
    <input type="text" name="fecha_nacimiento" required><br>
    <button type="submit">Guardar</button>
</form>

    <h2>Buscar persona</h2>
    <input type="text" id="busqueda" placeholder="Buscar por nombre o apellido">

    <div id="tabla-dinamica">
        <!-- Aquí se cargará la tabla actualizada automáticamente -->
    </div>

<h2>Lista de personas</h2>
<table border="1">
    <tr>
        <th>ID</th><th>Nombre</th><th>Apellido</th><th>Email</th>
        <th>Teléfono</th><th>Dirección</th><th>Fecha</th><th>Acciones</th>
    </tr>
    <?php
    $sql = "SELECT * FROM personas";
    $result = $conn->query($sql);
    while($row = $result->fetch_assoc()) {
        echo "<tr>
                <td>{$row['id']}</td>
                <td>{$row['nombre']}</td>
                <td>{$row['apellido']}</td>
                <td>{$row['email']}</td>
                <td>{$row['telefono']}</td>
                <td>{$row['direccion']}</td>
                <td>{$row['fecha_nacimiento']}</td>
                <td>
                    <a href='actualizar.php?id={$row['id']}'>Editar</a> |
                    <a href='eliminar.php?id={$row['id']}'>Eliminar</a>
                </td>
            </tr>";
    }
    ?>
</table>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Formulario CRUD</title>
    <style>
        * {
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', sans-serif;
            background: #f4f6f8;
            margin: 0;
            padding: 20px;
        }

        .container {
            max-width: 600px;
            margin: auto;
            background: white;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 25px;
        }

        label {
            display: block;
            margin-bottom: 6px;
            color: #555;
            font-weight: bold;
        }

        input[type="text"],
        input[type="email"],
        input[type="date"],
        input[type="tel"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 18px;
            border: 1px solid #ccc;
            border-radius: 8px;
            transition: border-color 0.3s;
        }

        input[type="text"]:focus,
        input[type="email"]:focus,
        input[type="date"]:focus,
        input[type="tel"]:focus {
            border-color: #3a7ff6;
            outline: none;
        }

        .botones {
            display: flex;
            justify-content: space-between;
        }

        .botones input {
            background-color: #3a7ff6;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            transition: background-color 0.3s;
        }

        .botones input:hover {
            background-color: #2d64d3;
        }

        table{
            justify-content: center;
            margin: 20px auto;
            width: 100%;
            max-width: 800px;
            background: white;
            border-radius: 12px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
            border-collapse: collapse;
            border: 1px solid #ccc;
        }

        th, td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        button {
            background-color: #3a7ff6;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            transition: background-color 0.3s;
        }
    </style>
</head>
<body>
        <script>
            function cargarDatos() {
                const busqueda = document.getElementById('busqueda').value;
                const xhr = new XMLHttpRequest();
                xhr.open("GET", "obtener_datos.php?busqueda=" + encodeURIComponent(busqueda), true);
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        document.getElementById("tabla-dinamica").innerHTML = xhr.responseText;
                    }
                };
                xhr.send();
            }

            setInterval(cargarDatos, 4000); // Actualiza cada 4 segundos
            document.getElementById("busqueda").addEventListener("input", cargarDatos);
            window.onload = cargarDatos; // Primera carga
        </script>

</body>
</html>
