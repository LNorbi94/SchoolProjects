<html>
<head>
<title>Dolgozat - Regisztráció</title>
<link href="dolg_reg.css" rel="stylesheet" type="text/css">
</head>
<body>
<?php
if (!isset($_POST['kuldes']))
{
?>
<div class="keret">
<form action="" method="post">
Felhasználónév: <input type="text" name="nev"><br>
Jelszó: <input type="password" name="pw"><br>
<input type="submit" value="Mehet!" name="kuldes">
</form>
</div>
<?php
} else {
$hiba_nev = 0;
$f = fopen("felhasznalok.txt", r);
	while(!feof($f))
	{
		if (trim(fgets($f)) == $_POST['nev'])
		{
		$hiba_nev = 1;
		}
	fgets($f);
	}
fclose($f);
if ($hiba_nev == 1)
	{
	echo "<div class='keret'><font color='red' size='+1'>Hiba! Ez a felhasználónév már létezik.</font></div>";
	}
else {
	if ($_POST['pw'] < 4 && !preg_match("/[0-9]+/", $_POST['pw']))
	{
	echo "<div class='keret'><font color='red' size='+1'>Hiba! A jelszó kevesebb mint 4 karaktert tartalmaz, vagy nem tartalmaz egy számot se.</font></div>";
	}
else {
$fi = fopen("felhasznalok.txt", a);
fwrite($fi, $_POST['nev']."\r\n");
fwrite($fi, $_POST['pw']."\r\n");
fclose($fi);
echo "<div class='keret'><font color='green' size='+1'>Sikeres regisztráció!</font></div>";
}
}
}
?>
</body>
</html>