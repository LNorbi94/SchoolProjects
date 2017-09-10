<?php
$fa = fopen("login/passwds1.txt","r");
$siker = true;
while (!feof($fa))
{
	if ($nev == trim(fgets($fa, 200))) {
		echo "Ez a felhasználónév már foglalt.<br><a href='reg1.php'>Vissza a regisztrációhoz.</a>";
		$siker = false;
	}
	fgets($fa, 200);
}
fclose($fa);
if ($siker == true)
{
$f = fopen("login/passwds1.txt","a");
fwrite($f, $nev."\r\n");
fwrite($f, $pw."\r\n");
fclose($f);
echo "Sikeres regisztráció!<br><a href='login1.php'>Tovább a bejelentkezéshez.</a>";
}
?>