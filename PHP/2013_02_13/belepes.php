<?php
	if (!$_POST['elkuldve'])
	{
	?>
<form method="post" action="">
Felhaszn�l�n�v: <input type="text" name="nev" value=""/><br />
Jelsz�: <input type="password" name="pw" value=""/><br />
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
	if ($error_name == 1) { echo "Nincs ilyen felhaszn�l�n�v az adatb�zisban.<br><a href='belepes.php'>Vissza a bel�p�shez</a>"; } 
	elseif ($error_pw == 1) { echo "Nem j� jelsz�t adt�l meg.<br><a href='belepes.php'>Vissza a bel�p�shez</a>"; } 
	else { 
	setcookie("forum", $_POST['nev']);
	Header("Location:forum.php"); }
	mysql_close($db);
	}
?>
<html>
    <head>
	  <title>Bel�p�s</title>
    </head>
<body></body></html>