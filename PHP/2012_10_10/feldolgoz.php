<?
$f = fopen("login/passwds1.txt","r");
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
	if ($nev == trim(fgets($f, 200))) {
	if ($pw == trim(fgets($f, 200))) {
	$siker = true;
	}
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