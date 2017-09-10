<?php
	if (!$_POST['elkuldve'])
	{
?>
	<div class="regisztracio">
	<form method="post" action="">
	Felhasználónév: <input type="text" name="nev" value=""/><br />
	Jelszó: <input type="password" name="pw" value=""/><br />
	<input type="submit" value="Mehet!" name="elkuldve"/><br />
	</form>
	</div>
<?php
	}
	else {
	include("mysql.php");
	mysql_select_db('webshop');
	$m = mysql_query("SELECT * FROM users");
	$error_name = 1;
	while ($row = mysql_fetch_assoc($m)) { 
	if ($row["user"] == $_POST['nev']) { 
	$error_name = 0; 
	if ($row["password"] == md5($_POST['pw']))
	{
	$error_pw = 0;
	if ($row["tipus"] == "kereskedo") { $kereskedo = 1; }
	} else { $error_pw = 1; } }
	}
	if ($error_name == 1) { echo "<div class='regisztracio'>Nincs ilyen felhasználónév az adatbázisban.<br><a href='belepes.php'>Vissza a belépéshez..</a></div>"; } 
	elseif ($error_pw == 1) { echo "<div class='regisztracio'>Nem jó jelszót adtál meg.<br><a href='belepes.php'>Vissza a belépéshez..</a></div>"; } 
	else { 
	if ($kereskedo == 1) {
	setcookie("webshop_ker", $_POST['nev']);
	@Header("Location:termekek_kereskedo.php");
	} else {
	setcookie("webshop", $_POST['nev']);
	@Header("Location:termekek.php"); }
	}
	mysql_close($db);
	}
?>
<html>
    <head>
	  <title>Belépés</title>
      <link href="webshop.css" rel="stylesheet" type="text/css">
    </head>
<body></body></html>