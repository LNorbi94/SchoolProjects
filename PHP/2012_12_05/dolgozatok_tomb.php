<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Dolgozatok</title>
</head>
<body>
<?
function darabszam($tomb)
{
	$db = 0;
		foreach ($tomb as $ind => $ert)
		{
		$db++;
		}
	return $db;
}
function osszegzes($tomb)
{
	$osszeg = 0;
		foreach ($tomb as $ind => $ert)
		{
		$osszeg += $ert;
		}
	return $osszeg;
}
function nagyobbmintatlag($tomb, $atlag)
{
$db = 0;
	foreach ($tomb as $ind => $ert)
	{
		if ($ert > $atlag)
		{
		$db++;
		}
	}
return $db;
}
function kereses($tomb, $szam)
{
$db = 0;
	foreach ($tomb as $ind => $ert)
	{
		if ($ert == $szam)
		{
		$db++;
		}
	}
return $db;
}
function kovatljobb($tomb)
{
$index = -1;
$seged = 0;
	foreach($tomb as $ind => $ert)
	{
		$osszn=0;
		$dbn=0;
		for ($i=$ind;$i<count($tomb);$i++)
		{
		$osszn += $tomb[$i];
		$dbn++;
		}
		$atlag = 1.0*$osszn / $dbn;
		if (($ert > $atlag) && ($seged == 0))
		{
		$index = $ind;
		$seged = 1;
		}
	}
return $index;
}
$f = fopen("adatok.txt", r);
$tomb0 = explode(" ", fgets($f));
$tomb1 = explode(" ", fgets($f));
$tomb2 = explode(" ", fgets($f));
$tomb3 = explode(" ", fgets($f));
fclose($f);
$atlag0 = osszegzes($tomb0) / darabszam($tomb0);
$atlag1 = osszegzes($tomb1) / darabszam($tomb1);
$atlag2 = osszegzes($tomb2) / darabszam($tomb2);
$atlag3 = osszegzes($tomb3) / darabszam($tomb3);
?>
<table width="60%"  border="0" cellpadding="10" align="center" style="border:thin solid black">
  <tr style="border:thin solid black">
    <td style="border:thin solid black" width="13%" align="center"><b>Dolgozat száma:</b></td>    
	<td style="border:thin solid black" width="13%" align="center"><b>Darabszám:</b></td>
	<td style="border:thin solid black" width="13%" align="center"><b>Átlag:</b></td>    
	<td style="border:thin solid black" width="13%" align="center"><b>Átlagtól jobb:</b></td>
	<td style="border:thin solid black" width="13%" align="center"><b>Hármasok száma:</b></td>    
	<td style="border:thin solid black" width="13%" align="center"><b>Ötösök száma:</b></td>
	<td style="border:thin solid black" width="13%" align="center"><b>Rákövetkezok átlagától jobb:</b></td>
  </tr>
  <tr style="border:thin solid black">
    <td style="border:thin solid black" align="right">1.</td>
    <td style="border:thin solid black" align="center"><? echo darabszam($tomb0); ?> db</td>
	<td style="border:thin solid black" align="center"><? echo round($atlag0, 2); ?></td>
    <td style="border:thin solid black" align="center"><? echo nagyobbmintatlag($tomb0, $atlag0); ?></td>
	<td style="border:thin solid black" align="center"><? if (kereses($tomb0, 3) == 0) { echo "Nem volt hármas"; } else { echo kereses($tomb0, 3); } ?></td>
    <td style="border:thin solid black" align="center"><? if (kereses($tomb0, 5) == 0) { echo "Nem volt ötös"; } else { echo kereses($tomb0, 5); } ?></td>
	<td style="border:thin solid black" align="center"><? if (kovatljobb($tomb0) == -1) { echo "Nem volt"; } else { echo "Volt, a(z) ".(kovatljobb($tomb0)+1)."."; } ?></td>
  </tr>
  <tr style="border:thin solid black">
    <td style="border:thin solid black" align="right">2.</td>
    <td style="border:thin solid black" align="center"><? echo darabszam($tomb1); ?> db</td>
	<td style="border:thin solid black" align="center"><? echo round($atlag1, 2); ?></td>
    <td style="border:thin solid black" align="center"><? echo nagyobbmintatlag($tomb1, $atlag1); ?></td>
	<td style="border:thin solid black" align="center"><? if (kereses($tomb1, 3) == 0) { echo "Nem volt hármas"; } else { echo kereses($tomb1, 3); } ?></td>
    <td style="border:thin solid black" align="center"><? if (kereses($tomb1, 5) == 0) { echo "Nem volt ötös"; } else { echo kereses($tomb1, 5); } ?></td>
	<td style="border:thin solid black" align="center"><? if (kovatljobb($tomb1) == -1) { echo "Nem volt"; } else { echo "Volt, a(z) ".(kovatljobb($tomb1)+1)."."; } ?></td>
  </tr>
  <tr style="border:thin solid black">
    <td style="border:thin solid black" align="right">3.</td>
    <td style="border:thin solid black" align="center"><? echo darabszam($tomb2); ?> db</td>
	<td style="border:thin solid black" align="center"><? echo round($atlag2, 2); ?></td>
    <td style="border:thin solid black" align="center"><? echo nagyobbmintatlag($tomb2, $atlag2); ?></td>
	<td style="border:thin solid black" align="center"><? if (kereses($tomb2, 3) == 0) { echo "Nem volt hármas"; } else { echo kereses($tomb2, 3); } ?></td>
    <td style="border:thin solid black" align="center"><? if (kereses($tomb2, 5) == 0) { echo "Nem volt ötös"; } else { echo kereses($tomb2, 5); } ?></td>
	<td style="border:thin solid black" align="center"><? if (kovatljobb($tomb2) == -1) { echo "Nem volt"; } else { echo "Volt, a(z) ".(kovatljobb($tomb2)+1)."."; } ?></td>
  </tr>
  <tr style="border:thin solid black">
    <td style="border:thin solid black" align="right">4.</td>
    <td style="border:thin solid black" align="center"><? echo darabszam($tomb3); ?> db</td>
	<td style="border:thin solid black" align="center"><? echo round($atlag3, 2); ?></td>
    <td style="border:thin solid black" align="center"><? echo nagyobbmintatlag($tomb3, $atlag3); ?></td>
	<td style="border:thin solid black" align="center"><? if (kereses($tomb3, 3) == 0) { echo "Nem volt hármas"; } else { echo kereses($tomb3, 3); } ?></td>
    <td style="border:thin solid black" align="center"><? if (kereses($tomb3, 5) == 0) { echo "Nem volt ötös"; } else { echo kereses($tomb3, 5); } ?></td>
	<td style="border:thin solid black" align="center"><? if (kovatljobb($tomb3) == -1) { echo "Nem volt"; } else { echo "Volt, a(z) ".(kovatljobb($tomb3)+1)."."; } ?></td>
  </tr>
</table>
</body>
</html>