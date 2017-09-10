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
	$m = mysql_query("SELECT users.username FROM users");
	while ($row = mysql_fetch_assoc($m)) { if ($row["username"] == $_POST['nev']) { $error = 1; } }
	if ($error == 1)
	{ echo "Már van ilyen felhasználónév."; } else {
	mysql_query("INSERT INTO `forum`.`users` (`username`, `password`) VALUES ('".$_POST['nev']."', '".md5($_POST['pw'])."')"); }
	mysql_close($db);
	Header("Location:belepes.php");
	}
?>
<html>
    <head>
	  <title>Regisztráció</title>
    </head>
<body></body></html>