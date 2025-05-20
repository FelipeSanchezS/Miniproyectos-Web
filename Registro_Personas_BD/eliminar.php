<?php
include 'bases.php';

$id = $_GET['id'];
$sql = "DELETE FROM personas WHERE id = $id";
$conn->query($sql);

header("Location: formulario.php");
?>
