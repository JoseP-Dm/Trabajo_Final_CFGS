
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HelpPet_App</title>
</head>
<style>
body{
    background-color: lavenderblush;
}
div{
    float:center;
    background-color: lavenderblush;
    height: 260px;
    width: 340px;
    display: block;
    text-align: center;
    margin-top:112px;
}
h1{
    text-align: center;
    color: lime;
    margin-top:20px;
}
h3{
    text-align: center;
    color: lime;
    margin-top:20px;
}
h5{
    text-align: center;
    color: lime;
    margin-top:40px;
}
</style>
<body>
<h1>HelpPet-APP</h1>
<h3>Pagina web para permitir <br> el acceso a la app</h3>
<div>
<form action="https://drive.google.com/file/d/18HbOdikWYd5ez2hgC0T0AguWFW68RWcS/view?usp=sharing">
<Label>DNI:</Label>
<br>
<input type="text" name="dni" id="" required>
<br>
<Label>gmail:</Label>
<br>
<input type="text" name="mail" id="" required>
<br>
<Label>contraseña:</Label>
<br>
<input type="password" name="pass" id="" required>
<br>
<br>
<input type="submit" value="Registrarse" name="registro" required>
</form>
</div>
<?php
$HOST="br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com";
$USER="upc64zf66fxq8gq9";
$PASS="hqD9cgVKNkL0zGpLCSoJ";
$DB="br6yuhxjtf6d9t43hrii";
    $mysql = new mysqli($HOST,$USER,$PASS,$DB);
    if($mysql->connect_error){
        die(``);
    }
  if(isset($_REQUEST["registro"])) {
    $dni=$_REQUEST['dni'];
    $gmail=$_REQUEST['mail'];
    $pass=$_REQUEST['pass'];
    $sql="UPDATE `propietari` SET `gmail`='$gmail',`pass`='$pass' WHERE `DNI`='$dni'";
    $resultado=$mysql->query($sql);
    $file_url = 'helppet.apk';
    header('Content-Type: application/octet-stream');
    header("Content-Transfer-Encoding: Binary"); 
    header("Content-disposition: attachment; filename=\"" . basename($file_url) . "\""); 
    readfile($file_url); 
  }
?>
</form>
</body>
<footer>
</footer>
</html>
