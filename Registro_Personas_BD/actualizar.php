<?php
include 'bases.php';

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $id = $_GET['id'];
    $sql = "SELECT * FROM personas WHERE id = $id";
    $result = $conn->query($sql);
    $row = $result->fetch_assoc();
?>
<form action="actualizar.php" method="POST">
    <input type="hidden" name="id" value="<?= $row['id'] ?>">
    <input type="text" name="nombre" value="<?= $row['nombre'] ?>"><br>
    <input type="text" name="apellido" value="<?= $row['apellido'] ?>"><br>
    <input type="email" name="email" value="<?= $row['email'] ?>"><br>
    <input type="text" name="telefono" value="<?= $row['telefono'] ?>"><br>
    <input type="text" name="direccion" value="<?= $row['direccion'] ?>"><br>
    <input type="date" name="fecha_nacimiento" value="<?= $row['fecha_nacimiento'] ?>"><br>
    <button type="submit">Actualizar</button>
</form>

<?php } 

else {
    $id = $_POST['id'];
    $nombre = $_POST['nombre'];
    $apellido = $_POST['apellido'];
    $email = $_POST['email'];
    $telefono = $_POST['telefono'];
    $direccion = $_POST['direccion'];
    $fecha = $_POST['fecha_nacimiento'];

    $sql = "UPDATE personas SET nombre='$nombre', apellido='$apellido', email='$email',
            telefono='$telefono', direccion='$direccion', fecha_nacimiento='$fecha'
            WHERE id=$id";

    $conn->query($sql);
    header("Location: formulario.php");
}
?>

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

</body>
</html>
