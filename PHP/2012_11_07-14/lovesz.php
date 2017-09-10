<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Lövész verseny</title>
</head>
<body>
<?
$f = fopen("lovesz.txt", r);
while(!feof($f))
{
$tomb[] = fgets($f);
}
$max = 0;
$min = 0;
$szam = 0;
foreach($tomb as $ind => $ertek)
{
echo $ertek."<br>\n";
}
foreach($tomb as $ind => $ertek)
{ if ($ertek > $max) {
$max = $ertek;
echo "A(z) ".($ind+1).". számú versenyzonél 0 versenyzo ért el jobb eredményt<br>\n";
$szam++;
$tomb2[$ind] = 1;
} else {
echo "A(z) ".($ind+1).". számú versenyzonél ".$szam." versenyzo ért el jobb eredményt<br>\n";
} 
if ($ertek < $min) {
$min = $ertek;
$tomb3[$ind] = 1;
} elseif($min == 0) {
$min = $ertek;
} }
foreach($tomb as $index => $ertek)
{ if (max($tomb) == $ertek) {
echo "A(z) ".($index+1).". számú versenyzo nyert<br>\n";
} }
echo "A következo versenyzok voltak elsok valamikor a verseny során:<br>\n";
foreach($tomb2 as $index => $ertek)
{ if ($ertek == 1) {
echo ($index+1).".<br>\n";
} }
echo "A következo versenyzok voltak utolsók valamikor a verseny során:<br>\n";
foreach($tomb3 as $index => $ertek)
{ if ($ertek == 1) {
echo ($index+1).".<br>\n";
} }
?>
</body>
</html>