<?php
if (!isset($kuldve))
{
?>
<html>
<form enctype="multipart/form-data" method="post" action="">
<label for="">admin.txt: </label>
<input type="file" name="admintxt" id="admintxt"><br> 
<input type="submit" name="kuldve">
</form>
</html>
<? 
} else
{
	$fnev = $_FILES["admintxt"]["name"];
	$f=fopen($fnev, "r");
	$admin = array(
	"id" => fgets($f),
	"nev" => fgets($f),
	"jelszo" => fgets($f),
	"email" => fgets($f),
	"kor" => fgets($f)
	);
	fclose($f);
	foreach($admin as $kulcs => $ertek)
	{
		if ($kulcs=="jelszo")
		{
			echo $kulcs.": ";
			for ($i=0;$i<strlen($ertek);$i++)
			{
			echo "*";
			}
			echo "<br>\n";
		}
		else
		{
	  		echo $kulcs.": ".$ertek."<br>\n";
	  	}
	}
} ?>