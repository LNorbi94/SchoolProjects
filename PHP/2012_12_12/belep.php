<html>
    <head>
	  <title>Belépés</title>
  	  <link href="urlap.css" rel="stylesheet" type="text/css">
    </head>
<body>
	<?
		if ($_POST['nev'] == "" || $_POST['pw'] == "")
		{
	?>
<div id="form">
	<form action="" method="post">
	Név:
	<?
	if(isset($_POST['kuldes']))
		{
			if($_POST['nev'] == "")
			{
				echo "<input type='text' name='nev'> <font color='red'>!</font>";
			}
			else
			{
				echo "<input type='text' name='nev' value='".$_POST['nev']."'>";
			}
		}
	if (!isset($_POST['kuldes']))
	{
		echo "<input type='text' name='nev'>";
	}
	?>
<br>
Jelszó: 
	<?
	if(isset($_POST['kuldes']))
		{
			if($_POST['pw'] == "")
			{
				echo "<input type='password' name='pw'> <font color='red'>!</font>";
			}
			else
			{
				echo "<input type='password' name='pw' value='".$_POST['pw']."'>";
			}
		}	
	if (!isset($_POST['kuldes']))
	{
		echo "<input type='password' name='pw'>";
	}
	?>
<br><br>
<input type="submit" value="Küldés" name="kuldes"></form>
</div>
</body></html>
<?
} else {
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
	echo "<div id='form'>";
	echo "<font color='#009933' size='+5'>Sikeresen beléptél!</font><br><br>";
	echo "Név: ".$_POST['nev']."<br>\n";
	echo "Jelszó: ";
		for ($i=0;$i<strlen($_POST['pw']);$i++)
		{
			echo "*";
		}
	echo "<br>\n";
	echo "<a href='belep.php'>Kilépés!</a>";
	echo "</div>";
	}
	else {
	echo "<div id='form'>";
	echo "<font color='#990000' size='+3'>Sikertelen belépés!</font><br><br>";
	echo "<a href='belep.php'>Új próba!</a>";
	echo "<br>\n";
	echo "</div>";
	}
}
?>