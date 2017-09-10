<?php
	if (!$_POST['elkuldve'])
	{
	?>
<form method="post" action="">
Felhasználónév: <input type="text" name="nev" value=""/><br />
Jelszó: <input type="password" name="pw" value=""/><br />
<input type="submit" value="Messsshet!" name="elkuldve"/><br />
</form>
	<?php
	}
	else {
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('tevenevelde');
	$m = mysql_query("SELECT users.felhasznalonev, users.jelszo FROM users");
	$error_name = 1;
	while ($row = mysql_fetch_assoc($m)) { 
	if ($row["felhasznalonev"] == $_POST['nev']) { 
	$error_name = 0; 
	if ($row["jelszo"] == $_POST['pw'])
	{
	$error_pw = 0;
	} else { $error_pw = 1; } }
	}
	if ($error_name == 1) { echo "Nincs ilyen felhasználónév az adatbázisban."; } elseif ($error_pw == 1) { echo "Nem jó jelszót adtál meg."; } 
	else { 
	setcookie("tevenevelde", $_POST['nev']);
	Header("Location:teve_beallitas.php"); }
	mysql_close($db);
	}
?>
<html>
    <head>
	  <title>Tevenevelde - Beslépés</title>
    </head>
<body></body></html>