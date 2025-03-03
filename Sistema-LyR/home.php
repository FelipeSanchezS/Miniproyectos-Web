<?php
    session_start();
    include("php/config.php");
    if(!isset($_SESSION['valid'])){
        header("location: index.php");
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/Sistema-LyR/Estilos/style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Raleway:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
    <title>Home</title>
</head>
<body>
    <div class="nav">
        <div class="logo">
            <a href="/Sistema-LyR/home.php"> <p>Logo</p> </a>
        </div>

        <div class="right-links">
        <?php
            $id = $_SESSION['id'];
            $query = mysqli_query($con, "SELECT * FROM users WHERE Id = $id");

            while($result = mysqli_fetch_assoc($query)){
                $res_Uname = $result['Username'];
                $res_Email = $result['Email'];
                $res_Age = $result['Age'];
                $res_id = $result['Id'];
                $res_Profesión = $result['Profesion'];
            }

        ?>
            <!-- <p class="welcome">Bienvenido <?php echo $res_Uname; ?></p> -->
            <a href='editar.php?Id=<?php echo $res_id; ?>'>Modificar perfil</a>
            <a href="/Sistema-LyR/cerrarS.php"><button class="btn">Cerrar sesión</button></a>
        </div>
    </div>

    <main>
        <div class="main-box top">
            <div class="top">
                <div class="box">
                    <p>Hola!: <b><?php echo $res_Uname ?></b></p>
                </div>
                <div class="box">
                    <p>Tu email es: <b><?php echo $res_Email ?></b></p>
                </div>
                <div class="box">
                    <p>Tu edad es: <b><?php echo $res_Age ?></b></p>
                </div>
            </div>
            <div class="bottom">
                <div class="box">
                    <p>Tu profesión es:  <b><?php echo $res_Profesión ?></b></p>
                </div>
            </div>
        </div>
            
    </main>
</body>
</html>