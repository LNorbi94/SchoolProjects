<?php
	$f1 = fopen("felhasznalok.txt", r);
	$hiba = 0;
	while(!feof($f1))
	{
	$valami = explode(",",fgets($f1));
	if ($_POST['nev'] == trim($valami[0]))
	{
	if (md5($_POST['pw']) != trim($valami[1]))
	{
	$hiba = 1;
	}
	}
	}
	fclose($f1);
	if ($hiba == 0)
	{
		if ($_POST['suti'] == "")
		{
			session_start();
			$_SESSION['ln_log'] = $_POST['nev'];
		}
		else {
			setcookie("ln_log", $_POST['nev']);
		}
	}
	else {
	}
?>
<html>
    <head>
	  <title>Bel�p�s</title>
  	  <link href="urlap.css" rel="stylesheet" type="text/css">
    </head>
<body>
<?php
if ($hiba == 0)
	{
	echo "<div id='form'>";
	echo "<font color='#009933' size='+5'>Sikeresen bel�pt�l!</font><br><br>";
	echo "N�v: ".$_POST['nev']."<br>\n";
	echo "Jelsz�: ";
		for ($i=0;$i<strlen($_POST['pw']);$i++)
		{
			echo "*";
		}
	echo "<br>\n";
	echo "<a href='index.php'>Tov�bb a fooldalra!</a>";
	echo "</div>";
	} else {
	echo "<div id='form'>";
	echo "<font color='#990000' size='+3'>Sikertelen bel�p�s!</font><br><br>";
	echo "<a href='index.php'>�j pr�ba!</a>";
	echo "<br>\n";
	echo "</div>";
	}
?>
</body></html>