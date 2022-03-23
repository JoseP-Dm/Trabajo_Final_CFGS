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
    $dni="SELECT `DNI` FROM `propietari` WHERE `gmail`='$user'";
    $resultado1=$mysql->query($dni);
    $resultado2= mysqli_fetch_assoc($resultado1);
    $sql="SELECT `codi`,`nom` FROM `mascota` WHERE `Propietari`="."'".$resultado2['DNI']."'";
    $resultado=$mysql->query($sql);
    while($e=mysqli_fetch_assoc($resultado)){
    echo $e['codi']." ".$e['nom'];
    echo "<br>";
    }
    
    $mysql->close();
    
?>