<?php
	if (!$_POST['elkuldve'])
	{
?>
	<div class="regisztracio">
	<form method="post" action="">
	Felhaszn�l�n�v: <input type="text" name="nev" value=""/><br />
	Jelsz�: <input type="password" name="pw" value=""/><br />
	<input type="submit" value="Mehet!" name="elkuldve"/><br />
	</form>
	</div>
<?php
	}
	else {
	include("mysql.php");
	mysql_select_db('webshop');
	$user_check = mysql_query("SELECT users.user FROM users");
	while ($row = mysql_fetch_assoc($user_check)) { if ($row["user"] == $_POST['nev']) { $error = 1; } }
	if ($error == 1)
	{ echo "<div class='regisztracio'>M�r van ilyen felhaszn�l�n�v!<br><a href='regisztracio.php'>Vissza a regisztr�ci�hoz..</a></div>"; } else {
	mysql_query("INSERT INTO `webshop`.`users` (`user`, `password`, `tipus`) VALUES ('".$_POST['nev']."', '".md5($_POST['pw'])."', 'felhasznalo')"); }
	mysql_close($db);
	@Header("Location:belepes.php");
	}
?>
<html>
    <head>
	  <title>Regisztr�ci�</title>
      <link href="webshop.css" rel="stylesheet" type="text/css">
    </head>
<body></body></html>