<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Számkitaláló</title>
</head>
<body>
<h3>Gondolj egy számot, és a program kitalálja!</h3>
<form action="" method="post">
<select name="select">
<option value="kisebb">Kisebb</option>
<option value="egyenlo">Egyenlo</option>
<option value="nagyobb">Nagyobb</option>
</select>
<input type="submit" value="Küldés!" name="kuldd">
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
echo "A kitalált szám a(z) ".$szam."?";
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
echo "A kitalált szám a(z) ".$szam."?";
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
echo "A kitalált szám a(z) ".$szam."?";
}
else {
$f = fopen("szam2.txt", r);
$szam = fgets($f);
fclose($f);
echo "Ha! Kitaláltam a számod, ami a következo: ".$szam;
}
}
?>
</body>
</html>