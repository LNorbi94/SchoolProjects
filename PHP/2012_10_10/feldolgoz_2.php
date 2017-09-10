<?php
$fa = fopen("login/passwds2.txt","r");
$siker = true;
  while (!feof($fa))
  {
	  if ($nev == array_shift(explode(':', fgets($fa,200)))) {
		  echo "Ez a felhasználónév már foglalt.<br><a href='reg1.php'>Vissza a regisztrációhoz.</a>";
		  $siker = false;
	  }
	  fgets($fa, 200);
  }
 fclose($fa);
  if ($siker == true)
  {
  $f = fopen("login/passwds2.txt","a");
  fwrite($f, $nev.":".$pw."\r\n");
  fclose($f);
  echo "Sikeres regisztráció!<br><a href='login2.php'>Tovább a bejelentkezéshez.</a>";
  }
?>