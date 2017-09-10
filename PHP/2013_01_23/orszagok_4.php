<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Orszagok');
$m = mysql_query('Select `orszagok`.`orszag`,`orszagok`.`terulet`,`orszagok`.`allamforma` From `orszagok` Where `orszagok`.`allamforma` Like "%monarchia%"');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='150px' style='border:thin solid black'><b>Ország</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Terület</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Államforma</b></td>
	</tr>";
while ($row = mysql_fetch_assoc($m)) {
	echo "<tr>";
    echo "<td style='border:thin solid black'>".$row["orszag"]."</td>";
    echo "<td style='border:thin solid black'>".$row["terulet"]."</td>";
    echo "<td style='border:thin solid black'>".$row["allamforma"]."</td>";
	echo "</tr>";
	$osszes += $row["terulet"];
}
	echo "</table>";
	
	echo "Összes terület: ".$osszes;
mysql_close($link);
?>