<?php
if (isset($_COOKIE['pizza']))
{
if (isset($_POST['logout'])) { setcookie("pizza", "", time() -3600); Header("Location:belepes.php"); }
if (isset($_POST['torles']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('pizza');
	mysql_query("DELETE FROM `pizza`.`rendeles` WHERE `rendeles`.`pizzanev` = '".$_POST['pizzanev']."'"); 
	mysql_close($db);
}
if (isset($_POST['valtoztatas']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('pizza');
    mysql_query("UPDATE `pizza`.`rendeles` SET `DB` = '".($_POST['ujdb'])."' WHERE `rendeles`.`pizzanev` = '".$_POST['pizzanev']."' AND `rendeles`.`felhasznalonev` = '".$_COOKIE['pizza']."'");
	mysql_close($db);
}
if (isset($_POST['uj_rendeles']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('pizza');
	mysql_query("INSERT INTO `pizza`.`rendeles` (`pizzanev`, `felhasznalonev`, `DB`, `ar`) VALUES ('".$_POST['rendeles_neve']."', '".$_COOKIE['pizza']."', '1', '1000')"); 
	mysql_close($db);
}
if	($_COOKIE['pizza'] == "admin")
{
echo "�dv <b>".$_COOKIE['pizza']."</b>! ";
echo "Mit szeretn�l csin�lni?";
?>
<br>�sszes rendel�s list�ja:<br>
<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('pizza');
	$m = mysql_query("SELECT * FROM rendeles");
		while ($row = mysql_fetch_assoc($m)) { 
			echo $row["pizzanev"].", ".$row["DB"]."db
			<form action='' method='post'>
			<input type='submit' name='torles' value='Rendel�s t�rl�se'>
			<br>Rendelt pizz�k sz�ma:<select name='ujdb'>
			<option>1</option>
			<option>2</option>
			<option>3</option>
			<option>4</option>
			</select>
			<input type='submit' name='valtoztatas' value='Mehet!'>
			<input type='hidden' name='db' value='".$row['DB']."'>
			<input type='hidden' name='pizzanev' value='".$row['pizzanev']."'>
			</form><br>";
			}
	 mysql_close($db);
	 echo "<form action='' method='post'><input type='submit' value='Kijelentkez�s!' name='logout'></form>";
}
else {
echo "�dv <b>".$_COOKIE['pizza']."</b>! ";
echo "Mit szeretn�l csin�lni?";
?>
<form action="" method="post">
�j pizza rendel�se:<br>
<select name="rendeles_neve">
<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('pizza');
	$m = mysql_query("SELECT * FROM pizzak");
	while ($row = mysql_fetch_assoc($m)) {
	echo "<option>".$row["pizzanev"]."</option>";
	}
	mysql_close($db);
?>
</select>
<input type="submit" name="uj_rendeles" value="Mehet!">
</form>

<br>Rendel�seid list�ja:<br>
<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('pizza');
	$m = mysql_query("SELECT * FROM rendeles WHERE rendeles.felhasznalonev='".$_COOKIE["pizza"]."'");
		while ($row = mysql_fetch_assoc($m)) { 
			echo $row["pizzanev"].", ".$row["DB"]."db
			<form action='' method='post'>
			<input type='submit' name='torles' value='Rendel�s t�rl�se'>
			<br>Rendelt pizz�k sz�ma:<select name='ujdb'>
			<option>1</option>
			<option>2</option>
			<option>3</option>
			<option>4</option>
			</select>
			<input type='submit' name='valtoztatas' value='Mehet!'>
			<input type='hidden' name='db' value='".$row['DB']."'>
			<input type='hidden' name='pizzanev' value='".$row['pizzanev']."'>
			</form><br>";
			}
	 mysql_close($db);
	 echo "<form action='' method='post'><input type='submit' value='Kijelentkez�s!' name='logout'></form>";
	}
} else { 
echo "Nem vagy bel�pve! <a href='belepes.php'>Bejelentkez�s...</a>";
}
?>
<html>
    <head>
	  <title>Rendel�s</title>
    </head>
<body>
</body></html>