<?php
 $HOST="br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com";
 $USER="upc64zf66fxq8gq9";
 $PASS="hqD9cgVKNkL0zGpLCSoJ";
 $DB="br6yuhxjtf6d9t43hrii";

     $mysql = new mysqli($HOST,$USER,$PASS,$DB);
     if($mysql->connect_error){
         die(``);
     }
    $caso=$_REQUEST["cas"];
    //  veterinario,fecha_caso
     //fecha_revision,Observacion
     // peso ,medicamento,enfermedad
    $sql="SELECT `nom`,`Data_Registre`,`Data_Revisio`,`Observacio`,`pes`,`tractament`,`medicaments`,`enfermetats` FROM `casos` inner join veterinari on veterinari.codi=casos.codi_veterinari WHERE `codi_cas`=$caso";
    $resultado=$mysql->query($sql);
    
    while($e=mysqli_fetch_assoc($resultado)){
    echo $e['nom']."<br>".$e['Data_Registre']."<br>".$e['Data_Revisio']."<br>".$e['Observacio']."<br>".$e['pes']."<br>".$e['tractament']."<br>".$e['medicaments']."<br>".$e['enfermetats'];
    
    }
    
    $mysql->close();
    
?>