<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Főoldal</title>
<link href="urlap.css" rel="stylesheet" type="text/css" />
</head>
<body>
<?php
if (isset($_COOKIE['ln_log']))
{
	echo "<div id='form'>";
	echo "Üdvözöllek, ".$_COOKIE['ln_log']."!<br>";
	echo "<a href='kijelentkezes.php'>Kijelentkezés</a>";
	echo "</div>";
}
elseif (isset($_SESSION['ln_log']))
{
	echo "<div id='form'>";
	echo "Üdvözöllek, ".$_SESSION['ln_log']."!<br>";
	echo "<a href='kijelentkezes.php'>Kijelentkezés</a>";
	echo "</div>";	
}
else {
?>
<div id="form">
Üdv idegen! A honlap használatához be kell lépned, avagy regisztrálnod kell.<br />
<form method="post">
Felhasználónév: <input type="text" name="nev" value=""/><br />
Jelszó: <input type="password" name="pw" value=""/><br />
<input type="checkbox" name="suti" /> Emlékezzen rám (süti használata)<br />
<input type="submit" value="Belépés" name="belep" formaction="belep.php" /> <input type="submit" value="Regisztráció" name="reg" formaction="regisztracio.php" /><br />
<font size="-2">Megjegyzés: Üresen hagyott felhasználónév nem megengedett, <br />valamint a jelszónak tartalmaznia kell legalább 6 karaktert, egy számot, és egy speciális (?, !) karaktert.</font>
</form>
</div>
<?php } ?>
</body>
</html>