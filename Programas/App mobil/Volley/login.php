<?php
$HOST="br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com";
$USER="upc64zf66fxq8gq9";
$PASS="hqD9cgVKNkL0zGpLCSoJ";
$DB="br6yuhxjtf6d9t43hrii";
    $mysql = new mysqli($HOST,$USER,$PASS,$DB);
    if($mysql->connect_error){
        die(``);
    }
    $user=filter_input(INPUT_POST,"username");
    $pass=filter_input(INPUT_POST,"password");
    $sql="SELECT gmail,pass FROM propietari WHERE gmail='$user'";
    $resultado=$mysql->query($sql);
    $content=$resultado->fetch_array();
    if($content[0]==$user && $content[1]==$pass){
        echo '1';
    }else{
        echo '0';
    }
    $mysql->close();

?>