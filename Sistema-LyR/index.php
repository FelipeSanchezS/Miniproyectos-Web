<?php
session_start();
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
    <title>Login</title>
</head>
<body>
    <div class="container">
        <div class="form-box box">
        <?php 
        
        include("php/config.php");
        if(isset($_POST['submit'])){
            $email = mysqli_real_escape_string($con, $_POST['email']);
            $password = mysqli_real_escape_string($con, $_POST['password']);

            $result = mysqli_query($con, "SELECT * FROM users WHERE Email = '$email' AND Password='$password'") or die ("Error al iniciar sesión");
            $row = mysqli_fetch_assoc($result);

            if(is_array($row) && !empty($row)){
                $_SESSION['valid'] = $row['Email'];
                $_SESSION['username'] = $row['Username'];
                $_SESSION['age'] = $row['Age'];
                $_SESSION['Profesion'] = $row['Profesion'];
                $_SESSION['id'] = $row['Id'];
            }
            else{
                echo   "<div class= 'message'>
                            <p>Error en el usuario o contraseña</p>
                        </div> <br>";
                echo "<a href='index.php'><button class='btn'> Vuelve </button>";
            }
            if(isset($_SESSION['valid'])){
                header("Location: home.php");
            }
        }
        else{
        
        ?>
            <header>Login</header>
            <form action="" method="post">
                <div class="field input">
                    <label for="email">Correo</label>
                    <input type="text" name="email" id="email" required>
                </div>

                <div class="field input">
                    <label for="password">Password</label>
                    <input type="password" name="password" id="password" required>
                </div>

                <div class="field">
                    <input type="submit" class="btn" name="submit" value="submit" required>
                </div>
                <div class="links">
                    ¿No tienes cuenta? <a href="/Sistema-LyR/register.php">Regístrate</a>
                </div>
            </form>
        </div>
        <?php } ?>
    </div>
</body>
</html>