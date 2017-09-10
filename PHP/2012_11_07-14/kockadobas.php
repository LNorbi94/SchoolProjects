<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Kockadobás</title>
</head>
<body>
<?
for ($i=0;$i<=100;$i++) {
$tomb[] = rand(1, 6);
}
asort($tomb);
print_r($tomb);
echo "<br>A kockadobások átlaga:<br>\n";
$ossz = 0;
$db = 0;
foreach($tomb as $index => $ertek)
{
$ossz += $ertek;
$db++;
}
$atlag = $ossz / $db;
echo $atlag;
echo "<br>A kockadobások mediánja:<br>\n";
$db0 = 0;
foreach ($tomb as $index => $ertek)
{
$db0++;
if ($db0 == 50)
{
echo $ertek;
}
}
echo "<br>A kockadobások módusza:<br>\n";
foreach($tomb as $index => $ertek)
{ $db2[$ertek]++; }
$index2 = 0;
$ertek2 = 0;
foreach($db2 as $index => $ertek)
{ if($ertek>$ertek2) { 
$ertek2 = $ertek;
$index2 = $index;
}
}
echo $index2;
?>
</body>
</html>
