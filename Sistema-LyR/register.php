<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/Sistema-LyR/Estilos/style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Raleway:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
    <title>Register</title>
</head>
<body>
    <div class="container">
        <div class="form-box box">

        <?php 
            include("php/config.php");
            if(isset($_POST['submit'])){
                $username = $_POST['username'];
                $email = $_POST['email'];
                $age = $_POST['age'];
                $profesion = $_POST['profesion'];
                $password = $_POST['password'];

                //verificamos el email

                $verify_query = mysqli_query($con, "SELECT Email FROM users WHERE Email='$email'" );

                if(mysqli_num_rows($verify_query) !=0 ){
                    echo    "<div class= 'message'>
                                <p>Este email ya esta en uso, intenta otro correo</p>
                            </div> <br>";
                    echo "<a href='javascript:self.history.back()'><button class='btn'> Vuelve </button>";
                }
                else{
                    mysqli_query($con, "INSERT INTO users(Username, Email, Age, Profesion, Password) VALUES ('$username','$email','$age','$profesion','$password')") or die("No es posible ingresar los valores");

                    echo "<div class= 'message'>
                            <p>Registro correcto</p>
                        </div> <br>";
                    echo "<a href='index.php'><button class='btn'> Ingresa </button>";
                }
            }
            else{
        ?>


            <header>regístrate</header>
            <form action="" method="post">
                <div class="field input">
                    <label for="username">Username</label>
                    <input type="text" name="username" id="username" required>
                </div>

                <div class="field input">
                    <label for="email">Email</label>
                    <input type="email" name="email" id="email" required>
                </div>

                <div class="field input">
                    <label for="age">Edad</label>
                    <input type="number" name="age" id="age" required>
                </div>

                <div class="field input">
                    <label for="profesion">Profesión</label>
                    <input type="text" name="profesion" id="profesion" required>
                </div>

                <div class="field input">
                    <label for="password">Password</label>
                    <input type="password" name="password" id="password" required>
                </div>

                <div class="field">
                    <input type="submit" class="btn" name="submit" value="Register" required>
                </div>
                <div class="links">
                    ¿Ya tienes cuenta? <a href="/Sistema-LyR/index.php">Inicia Sesión</a>
                </div>
            </form>
        </div>
        <?php } ?>
    </div>
</body>
</html>