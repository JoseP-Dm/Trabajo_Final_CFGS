<?php
 $HOST="br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com";
 $USER="upc64zf66fxq8gq9";
 $PASS="hqD9cgVKNkL0zGpLCSoJ";
 $DB="br6yuhxjtf6d9t43hrii";

     $mysql = new mysqli($HOST,$USER,$PASS,$DB);
     if($mysql->connect_error){
         die(``);
     }
    //$Chipee=filter_input(INPUT_POST,"chip");
    $Chipee=$_REQUEST["chip"];
    $chips="SELECT `codi_cas` ,`enfermetats` FROM `casos` WHERE `codi_mascota` = $Chipee ";
    $resultado=$mysql->query($chips);
    while($e=mysqli_fetch_assoc($resultado)){
    echo $e['codi_cas']." ".$e['enfermetats'];
    echo "<br>";
    }
    
    $mysql->close();
    
?>