<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Számkitaláló</title>
</head>

<body>
<h3>Tippelj egy számot!</h3>
<form action="" method="post">
<input type="text" name="tipp">
<input type="submit" value="Küldés!" name="kuldd">
</form>
<?
if(!isset($_POST['kuldd']))
{
$f = fopen("szam.txt", w);
fwrite($f, rand(1,100));
fclose($f);
}
else {
$f2 = fopen("szam.txt", r);
$szam = fgets($f2);
if ($_POST['tipp'] > $szam)
{ echo "A tippelt szám nagyobb."; }
elseif ($_POST['tipp'] < $szam)
{ echo "A tippelt szám kisebb."; }
else { echo "Gratulálok! Eltaláltad a gondolt számot."; }
fclose($f2);
}

?>
</body>
</html>