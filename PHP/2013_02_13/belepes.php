<?php
	if (!$_POST['elkuldve'])
	{
	?>
<form method="post" action="">
Felhasználónév: <input type="text" name="nev" value=""/><br />
Jelszó: <input type="password" name="pw" value=""/><br />
<input type="submit" value="Mehet!" name="elkuldve"/><br />
</form>
	<?php
	}
	else {
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('forum');
	$m = mysql_query("SELECT * FROM users");
	$error_name = 1;
	while ($row = mysql_fetch_assoc($m)) { 
	if ($row["username"] == $_POST['nev']) { 
	$error_name = 0; 
	if ($row["password"] == md5($_POST['pw']))
	{
	$error_pw = 0;
	} else { $error_pw = 1; } }
	}
	if ($error_name == 1) { echo "Nincs ilyen felhasználónév az adatbázisban.<br><a href='belepes.php'>Vissza a belépéshez</a>"; } 
	elseif ($error_pw == 1) { echo "Nem jó jelszót adtál meg.<br><a href='belepes.php'>Vissza a belépéshez</a>"; } 
	else { 
	setcookie("forum", $_POST['nev']);
	Header("Location:forum.php"); }
	mysql_close($db);
	}
?>
<html>
    <head>
	  <title>Belépés</title>
    </head>
<body></body></html>