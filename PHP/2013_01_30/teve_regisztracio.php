<html>
    <head>
	  <title>Tevenevelde - Regisztráció</title>
    </head>
<body></body></html>
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
	mysql_select_db('tevenevelde');
	$m = mysql_query("SELECT users.felhasznalonev FROM users");
	while ($row = mysql_fetch_assoc($m)) { if ($row["felhasznalonev"] == $_POST['nev']) { $error = 1; } }
	if ($error == 1)
	{ echo "Már van ilyen felhasználónév."; } else {
	mysql_query("INSERT INTO `tevenevelde`.`users` (`felhasznalonev`, `jelszo`) VALUES ('".$_POST['nev']."', '".$_POST['pw']."')"); }
	mysql_close($db);
	}
?>