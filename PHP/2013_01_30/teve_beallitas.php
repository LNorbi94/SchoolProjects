<?php
if (isset($_COOKIE['tevenevelde']))
{
if (isset($_POST['logout'])) { setcookie("tevenevelde", "", time() -3600); Header("Location:teve_belepes.php"); }
if (isset($_POST['torles']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('tevenevelde');
	mysql_query("DELETE FROM `tevenevelde`.`pets` WHERE `pets`.`tevenev` = '".$_POST['rejtett']."'"); 
	mysql_close($db);
}
if (isset($_POST['etet']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('tevenevelde');
	$dat = mysql_query("SELECT `pets`.`datolyaszam` FROM pets WHERE `pets`.`tevenev` = '".$_POST['rejtett']."'");
	while ($row = mysql_fetch_assoc($dat)) { $datolyadb = $row["datolyaszam"]; }
	mysql_query("UPDATE `tevenevelde`.`pets` SET `datolyaszam` = '".($datolyadb-1)."' WHERE `pets`.`tevenev` = '".$_POST['rejtett']."'"); 
	mysql_close($db);
}
if (isset($_POST['uj_teve']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('tevenevelde');
	$m = mysql_query("SELECT pets.tevenev FROM pets");
	while ($row = mysql_fetch_assoc($m)) { if ($row["tevenev"] == $_POST['uj_teve_neve']) { $error = 1; } }
	if ($error == 1)
	{ echo "<font color='red' size='+2'>Hiba!</font> M�r van ilyen nevu tev�d.<br>"; } else {
	mysql_query("INSERT INTO `tevenevelde`.`pets` (`tevenev`, `datolyaszam`, `felhasznalonev`) VALUES ('".$_POST['uj_teve_neve']."', 50, '".$_COOKIE['tevenevelde']."')"); 
	}
	mysql_close($db);
}
echo "�dv <b>".$_COOKIE['tevenevelde']."</b>! ";
echo "Mit szeretn�l csin�lni?";
?>
<form action="" method="post">
�j teve felv�tele:<br>
<input type="text" name="uj_teve_neve">
<input type="submit" name="uj_teve" value="Mehet!">
</form>

<br>Tev�id list�ja:<br>
<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('tevenevelde');
	
	$m = mysql_query("SELECT Count(*) FROM pets");
	if ($m == 0)
	{
	echo "Nincs m�g egy tev�d sem!";
	}
	else {
	$m = mysql_query("SELECT * FROM pets");
		while ($row = mysql_fetch_assoc($m)) { 
			echo $row["tevenev"].", Datoly�k sz�ma: ".$row["datolyaszam"]."
			<form action='' method='post'>
			<input type='submit' name='torles' value='Teve t�rl�se'>
			<input type='hidden' name='rejtett' value='".$row['tevenev']."'>
			<input type='submit' name='etet' value='Teve etet�se'>
			</form><br>";
		}
		
	}
	 mysql_close($db);
	 echo "<form action='' method='post'><input type='submit' value='Kijelentkez�s!' name='logout'></form>";
} else { 
echo "Nem vagy bel�pve! <a href='teve_belepes.php'>Bejelentkez�s...</a>";
}
?>
<html>
    <head>
	  <title>Tevenevelde</title>
    </head>
<body></body></html>