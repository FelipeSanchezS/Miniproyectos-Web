<?php
include 'bases.php';

$nombre = $_POST['nombre'];
$apellido = $_POST['apellido'];
$email = $_POST['email'];
$telefono = $_POST['telefono'];
$direccion = $_POST['direccion'];
$fecha = $_POST['fecha_nacimiento'];

$sql = "INSERT INTO personas (nombre, apellido, email, telefono, direccion, fecha_nacimiento) 
        VALUES ('$nombre', '$apellido', '$email', '$telefono', '$direccion', '$fecha')";

$conn->query($sql);
header("Location: formulario.php");
?>
