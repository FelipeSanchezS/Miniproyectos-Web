<?php
include 'bases.php';

$busqueda = $_GET['busqueda'] ?? '';

$sql = "SELECT * FROM personas WHERE nombre LIKE '%$busqueda%' OR apellido LIKE '%$busqueda%'";
$result = $conn->query($sql);

echo "<table border='1'>
<tr>
    <th>ID</th><th>Nombre</th><th>Apellido</th><th>Email</th>
    <th>Teléfono</th><th>Dirección</th><th>Fecha</th>
</tr>";

while ($row = $result->fetch_assoc()) {
    echo "<tr>
            <td>{$row['id']}</td>
            <td>{$row['nombre']}</td>
            <td>{$row['apellido']}</td>
            <td>{$row['email']}</td>
            <td>{$row['telefono']}</td>
            <td>{$row['direccion']}</td>
            <td>{$row['fecha_nacimiento']}</td>
        </tr>";
}
echo "</table>";
?>
