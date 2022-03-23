<?php
 $HOST="br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com";
 $USER="upc64zf66fxq8gq9";
 $PASS="hqD9cgVKNkL0zGpLCSoJ";
 $DB="br6yuhxjtf6d9t43hrii";

     $mysql = new mysqli($HOST,$USER,$PASS,$DB);
     if($mysql->connect_error){
         die(``);
     }
    $Chipee=$_REQUEST["chip"];
    $sql="SELECT  `codi`,`edat`,`Especie`,`raza`,`sexo`,`castrado` FROM mascota WHERE `codi`=$Chipee";
    $resultado=$mysql->query($sql);
    while($e=mysqli_fetch_assoc($resultado)){
    echo $e['codi']."<br>".$e['edat']."<br>".$e['Especie']."<br>".$e['raza']."<br>".$e['sexo']."<br>".$e['castrado'];
    
    }
    
    $mysql->close();
    
?>