<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Minimum / Eldöntés</title>
<link href="progtetelek.css" rel="stylesheet" type="text/css" />
</head>
<body>
<table class="tabla">
  <tr>
    <td colspan="2" class="fejlec">Minimum</td>
  </tr>
  <tr>
    <td class="kod2">
   	 <img src="min.jpg" />
    </td>
    <td class="kod">
 <?
	for($i=1;$i<50;$i++)
	{
		$a[] = rand(5, 100);
	}
 echo "A tömb elemei: (Minden frissitésnél más, és más)<br>\n";
	foreach($a as $index => $ertek)
	{
		if ($index==48)
		{
			echo $ertek."<br>\n";
			
		}
		else {
			echo $ertek.", ";
		}
	}
 $j = 1;
	foreach($a as $index => $ertek)
	{
		if($a[$index] < $a[$j])
		{
			$j = $index;
		}
	}
 echo "A legkisebb érték: ".$a[$j];
 ?>    
    </td>
  </tr>
  <tr>
    <td class="fejlec" colspan="2">Eldöntés</td>
  </tr>
  <tr>
    <td class="kod2"><img src="eldont.png" /></td>
    <td class="kod">
 <?
 if (isset($_POST['kuldes']))
 {
    for($j=1;$j<50;$j++)
	{
		$b[] = rand(5, 100);
	}
 echo "B tömb elemei: (Minden frissitésnél más, és más)<br>\n";
	foreach($b as $index => $ertek)
	{
		if ($index==48)
		{
			echo $ertek."<br>\n<br>\n";
			
		}
		else {
			echo $ertek.", ";
		}
	}
	$l = false;
	foreach ($b as $index => $ertek)
	{
		if($ertek==$_POST['eldont'])
		{
			$l = true;
		}
	}
	if($l == true)
	{
		echo "Van ilyen elem a tömbben.";
	}
	else
	{
		echo "Nincs ilyen elem a tömbben.";
	}
 }
 else
 {
	 ?>
     <form method="post" action="">
     Megtalálható-e a következő elem a tömbben?<br />
     <input type="text" name="eldont" />
     <input type="submit" name="kuldes" value="Küldés!" />
     </form>
     <?
 }
 ?>
    </td>
  </tr>
</table>
</body>
</html>