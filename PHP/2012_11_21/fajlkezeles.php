<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Fájl kezelés</title>
<style type="text/css">
#formegy {
	background-color: #FFF;
	border: thin solid #000;
	width: 50%;
	text-align: center;
	padding: 5px;
	margin-left: 25%;
}
body {
	background-color: #999;
}
</style>
</head>
<body>
<?php
if (!isset($_POST['vege']))
{
?>
<div align="center" id="formegy">
<form action="" method="post">
<input type="text" name="alap">
<input type="text" name="modosit"><br>
<input type="submit" name="hozzaad" value="Hozzáadás">
<input type="submit" name="eltavolit" value="Eltávolítás">
<input type="submit" name="modositg" value="Módosítás">
<input type="submit" name="vege" value="Bezárás">
</form>
</div>
<?
global $tomb;
function olvasas()
{
	$f = fopen("fajl.txt", r);
		while(!feof($f))
		{
			global $tomb;
			$tomb[] = trim(fgets($f));
		}
	fclose($f);
}
function ElemeE($elem)
{
	global $tomb;
	$l = false;
	foreach($tomb as $ind => $ertek)
	{
		if ($ertek == $elem)
		{
			$l = true;
		}
	}
	
	return $l;
}
function iras($elem)
{
	global $tomb;
		if (!ElemeE($elem))
		{
			$f = fopen("fajl.txt", a);
			fwrite($f, $elem."\r\n");
			fclose($f);
		}
		else { }
}
function torles($elem)
{
	if (ElemeE($elem))
	{
	global $tomb;
	$f = fopen("fajl.txt", w);
	foreach($tomb as $ind => $ert)
	{
		if ($ert == $elem)
		{
		}
		elseif ($ind == count($tomb)-1)
		{
			fwrite($f, $ert);
		}
		else
		{
			fwrite($f, $ert."\r\n");
		}	
	}
	fclose($f);
	} else { }
}
function modosite($elem, $elem2)
{
if (ElemeE($elem) && !ElemeE($elem2))
{
torles($elem);
iras($elem2);
} else { }
}
olvasas();
if (isset($_POST['hozzaad']))
{
iras($_POST['alap']);
}
elseif (isset($_POST['eltavolit']))
{
torles($_POST['alap']);
}
elseif (isset($_POST['modositg']))
{
modosite($_POST['alap'], $_POST['modosit']);
}
foreach($tomb as $ind => $ert)
{
if ($ind == count($tomb)-1)
{
}
else {
echo $ind.". ".$ert."<br>";
}
}
}
else { 
}
?>
</body>
</html>