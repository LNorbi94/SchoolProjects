<?
$f = fopen("login/passwds2.txt","r");
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
	if ($nev.":".$pw == trim(fgets($f, 200))) {
	$siker = true;
	@$fn = fopen("login/".$nev.".txt","r");
	$a = 0;
	@$a = fgets($fn,200)+1;
	@fclose($fn);
	@$fa = fopen("login/".$nev.".txt","w");
	fwrite($fa,$a);
	fclose($fa);
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