<?
$f = fopen("login/passwds1.txt","r");
if (trim($nev) == "")
{
echo "Nem adt�l meg felhaszn�l�nevet.";
}
else
{
if (trim($pw) == "")
{
echo "Nem adt�l meg jelszavat.";
}
else
{
while (!feof($f))
{
	if ($nev == trim(fgets($f, 200))) {
	if ($pw == trim(fgets($f, 200))) {
	$siker = true;
	}
	}
}

if ( $siker == true )
{
	echo "Sikeres bejelentkez�s, <a href='bent.php'>tov�bb</a>.";
}
else
{
echo "Sikertelen bejelentkez�s, <a href='kint.php'>tov�bb</a>. ";
}
}
}
fclose($f);
?>