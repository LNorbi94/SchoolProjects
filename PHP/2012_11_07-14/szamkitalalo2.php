<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Sz�mkital�l�</title>
</head>
<body>
<h3>Gondolj egy sz�mot, �s a program kital�lja!</h3>
<form action="" method="post">
<select name="select">
<option value="kisebb">Kisebb</option>
<option value="egyenlo">Egyenlo</option>
<option value="nagyobb">Nagyobb</option>
</select>
<input type="submit" value="K�ld�s!" name="kuldd">
</form>
<?
if(!isset($_POST['kuldd']))
{
$f = fopen("szam2.txt", w);
fwrite($f, 50);
fclose($f);
$f = fopen("szam2.txt", r);
$szam = fgets($f);
fclose($f);
echo "A kital�lt sz�m a(z) ".$szam."?";
}
else {
if ($_POST['select'] == "kisebb")
{
$f = fopen("szam2.txt", r);
$szam = fgets($f);
fclose($f);
$szam = (int)($szam / 2);
$f = fopen("szam2.txt", w);
fwrite($f, $szam);
fclose($f);
echo "A kital�lt sz�m a(z) ".$szam."?";
}
elseif($_POST['select'] == "nagyobb")
{
$f = fopen("szam2.txt", r);
$szam = fgets($f);
fclose($f);
$szam = $szam + (int)($szam / 2);
$f = fopen("szam2.txt", w);
fwrite($f, $szam);
fclose($f);
echo "A kital�lt sz�m a(z) ".$szam."?";
}
else {
$f = fopen("szam2.txt", r);
$szam = fgets($f);
fclose($f);
echo "Ha! Kital�ltam a sz�mod, ami a k�vetkezo: ".$szam;
}
}
?>
</body>
</html>