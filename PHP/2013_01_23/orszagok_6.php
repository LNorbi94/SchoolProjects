<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Orszagok');
$m = mysql_query('Select `orszagok`.`orszag`,`orszagok`.`nepesseg`,`orszagok`.`fovaros` From `orszagok` Order by `orszagok`.`nepesseg`');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='150px' style='border:thin solid black'><b>Ország</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Népesség</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Fováros</b></td>
	</tr>";
while ($row = mysql_fetch_assoc($m)) {
	if ($row["orszag"] == "PORTUGÁLIA")
	{
		$nepesseg = $row["nepesseg"];
	}
	if ($row["nepesseg"] == ($nepesseg+1000))
	{
	echo "<tr>";
    echo "<td style='border:thin solid black'>".$row["orszag"]."</td>";
    echo "<td style='border:thin solid black'>".$row["nepesseg"]."</td>";
    echo "<td style='border:thin solid black'>".$row["fovaros"]."</td>";
	echo "</tr>";
	}
}
	echo "</table>";
mysql_close($link);
?>