<?php
if (isset($_COOKIE['webshop_ker']))
{
	include("mysql.php");
	if (isset($_POST['uj']))
	{
	mysql_select_db('webshop');
	$target_path = "img/";
	$target_path = $target_path . basename( $_FILES['uploadedfile']['name']); 
	mysql_query("INSERT INTO `webshop`.`termekek` (`nev`, `kep`, `raktaron`, `darabar`) VALUES ('".$_POST['termek_nev']."', '".$target_path."', '".$_POST['raktaron']."', '".$_POST['darab_ar']."')"); 
	move_uploaded_file($_FILES['uploadedfile']['tmp_name'], $target_path);
	}
	if (isset($_POST['torol']))
	{
	mysql_select_db('webshop');
	mysql_query("DELETE FROM `webshop`.`termekek` WHERE `termekek`.`nev` = '".$_POST['termeknev']."'");
	}
	if (isset($_POST['logout'])) { setcookie("webshop_ker", "", time() -3600); Header("Location:belepes.php"); }
	mysql_select_db('webshop');
	$m = mysql_query("SELECT * FROM termekek");
	echo "<table class='termekek_fotabla'>";
	echo "<tr><td colspan='2' align='center'>�dv <b>".$_COOKIE['webshop_ker']."</b>!</td></tr>";
	echo "<tr><td colspan='2' align='left'><b>�j term�k felv�tele:</b></td></tr>";
	echo "<tr><td colspan='2' align='right'><form action='' method='post' enctype='multipart/form-data'>
	Term�k neve: <input type='text' name='termek_nev'><br>
	Darab �r: <input type='text' name='darab_ar'><br>
	�sszesen rakt�ron: <input type='text' name='raktaron'><br>
	K�p felt�lt�se: <input name='uploadedfile' type='file' />
	<input type='submit' value='Mehet!' name='uj'>
	</form></td></tr>";
		while ($row = mysql_fetch_assoc($m)) { 
			echo "
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla' rowspan='3' width='150px'><img width='150px' height='100px' src='".$row["kep"]."'></td>
			  <td class='termekek_tabla'><b>Term�k neve: </b>".$row["nev"]."</td></tr>
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla'><b>Darab �r:</b> ".$row["darabar"]." Ft</td></tr>
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla'><b>�sszesen rakt�ron: </b>".$row["raktaron"]." db </td>
			  </tr><tr class='termekek_tabla'>
			  <form action='' method='post'>
			  <td class='termekek_tabla' colspan='2' align='right'><input type='hidden' name='db' value='".$row["raktaron"]."'>
			  <input type='hidden' name='termeknev' value='".$row["nev"]."'>
			  <input type='submit' value='Term�k t�rl�se!' name='torol'>
			  </form></td></tr>
			";
		}
	 echo "<tr><td align='right' colspan='2'><br><form action='' method='post'><input type='submit' value='Kijelentkez�s!' name='logout'></form></td></tr>";
	 echo "</table>";
	 mysql_close($db);
} else { 
echo "Nem vagy bel�pve! <a href='belepes.php'>Bejelentkez�s...</a>";
}
?>
<html>
    <head>
	  <title>Term�kek</title>
      <link href="webshop.css" rel="stylesheet" type="text/css">
    </head>
<body></body></html>