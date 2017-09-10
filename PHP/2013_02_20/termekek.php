<?php
if (isset($_COOKIE['webshop']))
{
	include("mysql.php");
	if (isset($_POST['vasarlas_torlese']))
	{
	mysql_select_db('webshop');
	mysql_query("DELETE FROM webshop.kosar WHERE `kosar`.`user`='".$_COOKIE['webshop']."'");
	}
	if (isset($_POST['vasarol']))
	{
	mysql_select_db('webshop');
	$m = mysql_query("SELECT * FROM termekek");
		while ($row = mysql_fetch_assoc($m)) { 
		if ($row["nev"] == $_POST["termeknev"])
		{
			$db = $row["raktaron"];
		} }
	$m = mysql_query("SELECT * FROM kosar");
	while ($row = mysql_fetch_assoc($m)) { 
			if ($row["termek"] == $_POST["termeknev"])
			{
			$db_kosarban = $row["darab"];
			$letezik = 1;
			}
	}
	if ($db-$_POST['hany_vasarlasa'] < 0)
	{
	}
	elseif ($db-$_POST['hany_vasarlasa'] == 0) {
		mysql_query("DELETE FROM `webshop`.`termekek` WHERE `termekek`.`nev` = '".$_POST['termeknev']."'");
		if ($letezik == 1) {
		mysql_query("UPDATE `webshop`.`kosar` SET `darab` = '".($db_kosarban+$_POST['hany_vasarlasa'])."' WHERE `kosar`.`termek` = '".$_POST['termeknev']."'");
		} else {
		mysql_query("INSERT INTO `webshop`.`kosar` (`user`, `termek`, `darab`) VALUES ('".$_COOKIE['webshop']."', '".$_POST['termeknev']."', '".$_POST['hany_vasarlasa']."')"); }
	}
	else {
	if ($letezik == 1) {
		mysql_query("UPDATE `webshop`.`kosar` SET `darab` = '".($db_kosarban+$_POST['hany_vasarlasa'])."' WHERE `kosar`.`termek` = '".$_POST['termeknev']."'");
		mysql_query("UPDATE `webshop`.`termekek` SET `raktaron` = '".($db-$_POST['hany_vasarlasa'])."' WHERE `termekek`.`nev` = '".$_POST['termeknev']."'");
		} else {
		mysql_query("INSERT INTO `webshop`.`kosar` (`user`, `termek`, `darab`) VALUES ('".$_COOKIE['webshop']."', '".$_POST['termeknev']."', '1')"); }
		mysql_query("UPDATE `webshop`.`termekek` SET `raktaron` = '".($db-$_POST['hany_vasarlasa'])."' WHERE `termekek`.`nev` = '".$_POST['termeknev']."'");
	}
	}
	if (isset($_POST['logout'])) { setcookie("webshop", "", time() -3600); Header("Location:belepes.php"); }
	mysql_select_db('webshop');
	$m = mysql_query("SELECT * FROM termekek");
	echo "<table class='termekek_fotabla' >";
	echo "<tr><td colspan='2' align='center'>Üdv <b>".$_COOKIE['webshop']."</b>!</td></tr>";
		while ($row = mysql_fetch_assoc($m)) { 
			echo "
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla' rowspan='3' width='150px'><img width='150px' height='100px' src='".$row["kep"]."'></td>
			  <td class='termekek_tabla'><b>Termék neve: </b>".$row["nev"]."</td></tr>
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla'><b>Darab ár:</b> ".$row["darabar"]." Ft</td></tr>
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla'><b>Összesen raktáron: </b>".$row["raktaron"]." db </td>
			  </tr><tr class='termekek_tabla'>
			  <form action='' method='post'>
			  <td class='termekek_tabla' colspan='2' align='right'><input type='hidden' name='db' value='".$row["raktaron"]."'>
			  <input type='hidden' name='termeknev' value='".$row["nev"]."'>
			  <select name='hany_vasarlasa'><option>1</option><option>2</option><option>3</option>><option>4</option><option>5</option></select>
			  <input type='submit' value='Vásárlás!' name='vasarol'>
			  </form></td></tr>
			";
		}
	 echo "<tr><td colspan='2' align='center'>Kosarad tartalma:</td></tr>";
	 mysql_select_db('webshop');
	$m = mysql_query("SELECT * FROM kosar WHERE kosar.user='".$_COOKIE['webshop']."'");
		while ($row = mysql_fetch_assoc($m)) { 
			echo "
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla' colspan='2'><b>Termék neve: </b>".$row["termek"]."</td></tr>
			  <tr class='termekek_tabla'>
			  <td class='termekek_tabla' colspan='2'><b>Összesen:</b> ".$row["darab"]." db</td></tr>
			  <tr class='termekek_tabla'>
			  </tr>
			";
		}
		echo "<tr class='termekek_tabla'>
			  <form action='' method='post'>
			  <td class='termekek_tabla' colspan='2' align='right'>
			  <input type='submit' value='Vásárlás visszavonása!' name='vasarlas_torlese'>
			  </form></td></tr>";
	 echo "<tr><td align='right' colspan='2'><br><form action='' method='post'><input type='submit' value='Kijelentkezés!' name='logout'></form></td></tr>";
	 echo "</table>";
} else { 
echo "Nem vagy belépve! <a href='belepes.php'>Bejelentkezés...</a>";
}
?>
<html>
    <head>
	  <title>Termékek</title>
      <link href="webshop.css" rel="stylesheet" type="text/css">
    </head>
<body>
</body></html>