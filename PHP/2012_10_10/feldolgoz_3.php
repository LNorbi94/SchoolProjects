<?
$f = fopen("login/passwds2.txt","r");
if (trim($nev) == "")
{
echo "Nem adtál meg felhasználónevet.";
}
else
{
if (trim($pw) == "")
{
echo "Nem adtál meg jelszavat.";
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
	echo "Sikeres bejelentkezés, <a href='bent.php'>tovább</a>.";
}
else
{
echo "Sikertelen bejelentkezés, <a href='kint.php'>tovább</a>. ";
}
}
}
fclose($f);
?>