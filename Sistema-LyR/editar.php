<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/Sistema-LyR/Estilos/style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Raleway:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
    <title>Editar usuario</title>
</head>
<body>
    
    <div class="nav">
        <div class="logo">
            <a href="/Sistema-LyR/home.php"> <p>Logo</p> </a>
        </div>

        <div class="right-links">
            <a href="#">Modifica tu perfil</a>
            <a href="#"><button class="btn">Cerrar sesión</button></a>
        </div>
    </div>

    <div class="container">
        <div class="form-box box">
            <header>Modifica tu perfil</header>
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
                    <label for="profesión">Profesión</label>
                    <input type="text" name="profesión" id="profesión" required>
                </div>

                <div class="field">
                    <input type="submit" class="btn" name="submit" value="Update" required>
                </div>
            </form>
        </div>
    </div>

</body>
</html>